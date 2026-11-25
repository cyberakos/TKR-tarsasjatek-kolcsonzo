using System;
using System.Collections.Generic;
using System.Globalization;

namespace TKR
{
    // Bejelentkezés

    public static class AuthService
    {
        // Hibaüzenetet ad vissza, vagy null-t, ha sikerült (ilyenkor a Session ki van töltve)
        public static string Login(string id, string password)
        {
            id = (id ?? "").Trim();
            password = password ?? "";
            if (id.Length == 0) return "A felhasználói azonosító megadása kötelező!";
            if (password.Length == 0) return "A jelszó megadása kötelező!";

            const string bad = "Hibás felhasználói azonosító vagy jelszó!";
            if (!Rules.UserIdOk(id) || !Rules.PasswordOk(password)) return bad;

            using (DbConn c = new DbConn())
            {
                List<object[]> rows = c.Query(
                    "SELECT felhasznalo_id, vezeteknev, keresztnev, szerepkor, jelszo_hash FROM dolgozo WHERE felhasznalo_id = $p0 AND aktiv = 1", id);
                if (rows.Count == 0) return bad;
                object[] r = rows[0];
                if (!Security.Verify(password, Conv.ToStr(r[4]))) return bad;

                Session.UserId = Conv.ToStr(r[0]);
                Session.FullName = Conv.ToStr(r[1]) + " " + Conv.ToStr(r[2]);
                Session.Role = Conv.ToStr(r[3]);
                return null;
            }
        }
    }

    // Tagok

    public static class MemberService
    {
        private const string Cols = "tag_id, vezeteknev, keresztnev, szuletesi_datum, email, telefon, belepes_datuma, aktiv";

        private static MemberRow Map(object[] r)
        {
            MemberRow m = new MemberRow();
            m.Id = Conv.ToStr(r[0]);
            m.Vezeteknev = Conv.ToStr(r[1]);
            m.Keresztnev = Conv.ToStr(r[2]);
            m.Szuletes = Fmt.FromDb(r[3]).Value;
            m.Email = Conv.ToStr(r[4]);
            m.Telefon = Conv.ToStr(r[5]);
            m.Belepes = Fmt.FromDb(r[6]).Value;
            m.Aktiv = Conv.ToBool(r[7]);
            return m;
        }

        public static int AgeOn(DateTime birth, DateTime day)
        {
            int age = day.Year - birth.Year;
            if (birth.Date > day.Date.AddYears(-age)) age--;
            return age;
        }

        public static MemberRow GetOn(DbConn c, string id)
        {
            List<object[]> rows = c.Query("SELECT " + Cols + " FROM tag WHERE tag_id = $p0", id);
            return rows.Count == 0 ? null : Map(rows[0]);
        }

        public static MemberRow Get(string id)
        {
            using (DbConn c = new DbConn()) return GetOn(c, id);
        }

        public static int OpenTakeAwayCountOn(DbConn c, string id)
        {
            return Conv.ToInt(c.Scalar(
                "SELECT COUNT(*) FROM kolcsonzes WHERE tag_id = $p0 AND tipus = 'Elvitel' AND visszavetel_ideje IS NULL", id));
        }

        public static int OpenTakeAwayCount(string id)
        {
            using (DbConn c = new DbConn()) return OpenTakeAwayCountOn(c, id);
        }

        private static List<MemberRow> All(bool onlyActive)
        {
            List<MemberRow> list = new List<MemberRow>();
            using (DbConn c = new DbConn())
            {
                string sql = "SELECT " + Cols + " FROM tag" + (onlyActive ? " WHERE aktiv = 1" : "");
                foreach (object[] r in c.Query(sql)) list.Add(Map(r));
            }
            list.Sort(delegate (MemberRow a, MemberRow b)
            {
                int d = string.Compare(a.Vezeteknev, b.Vezeteknev, StringComparison.CurrentCultureIgnoreCase);
                if (d != 0) return d;
                return string.Compare(a.Keresztnev, b.Keresztnev, StringComparison.CurrentCultureIgnoreCase);
            });
            return list;
        }

        public static List<MemberRow> Active() { return All(true); }

        public static string ValidateSearch(string vn, string kn, string id)
        {
            foreach (string s in new string[] { vn, kn, id })
            {
                string t = (s ?? "").Trim();
                if (t.Length > 50) return "A keresőszöveg legfeljebb 50 karakter lehet!";
                if (!Rules.TextOk(t)) return "A keresőszöveg nem megengedett karaktert tartalmaz!";
            }
            return null;
        }

        private static bool Has(string value, string part)
        {
            part = (part ?? "").Trim();
            if (part.Length == 0) return true;
            return (value ?? "").IndexOf(part, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        public static List<MemberRow> Search(string vn, string kn, string id, bool onlyActive)
        {
            List<MemberRow> result = new List<MemberRow>();
            foreach (MemberRow m in All(onlyActive))
            {
                if (Has(m.Vezeteknev, vn) && Has(m.Keresztnev, kn) && Has(m.Id, id)) result.Add(m);
            }
            return result;
        }

        public static string Validate(MemberEdit e)
        {
            string vn = (e.Vezeteknev ?? "").Trim();
            string kn = (e.Keresztnev ?? "").Trim();
            if (vn.Length == 0) return "A vezetéknév megadása kötelező!";
            if (vn.Length > 50) return "A vezetéknév legfeljebb 50 karakter lehet!";
            if (!Rules.NameOk(vn)) return "A vezetéknév csak betűt, szóközt és kötőjelet tartalmazhat!";
            if (kn.Length == 0) return "A keresztnév megadása kötelező!";
            if (kn.Length > 50) return "A keresztnév legfeljebb 50 karakter lehet!";
            if (!Rules.NameOk(kn)) return "A keresztnév csak betűt, szóközt és kötőjelet tartalmazhat!";

            DateTime dob;
            if (!Fmt.TryDate(e.Szuletes, out dob)) return "A születési dátum formátuma: éééé.hh.nn.";
            if (dob > Clock.Today) return "A születési dátum nem lehet jövőbeli!";
            if (dob.Year < 1900) return "A születési dátum nem lehet 1900 előtti!";

            string email = (e.Email ?? "").Trim();
            if (email.Length > 0 && !Rules.EmailOk(email)) return "Az e-mail cím formátuma érvénytelen!";
            string tel = (e.Telefon ?? "").Trim();
            if (tel.Length > 0 && !Rules.PhoneOk(tel)) return "A telefonszám csak számot, +, szóközt és kötőjelet tartalmazhat (legfeljebb 20 karakter)!";

            if (e.Id != null && Session.IsManager && !e.Aktiv && OpenTakeAwayCount(e.Id) > 0)
                return "A tagnak nyitott elvitele van, ezért nem inaktiválható!";
            return null;
        }

        public static string Save(MemberEdit e, out string newId)
        {
            newId = e.Id;
            string err = Validate(e);
            if (err != null) return err;

            string vn = e.Vezeteknev.Trim();
            string kn = e.Keresztnev.Trim();
            DateTime dob;
            Fmt.TryDate(e.Szuletes, out dob);
            string email = (e.Email ?? "").Trim();
            string tel = (e.Telefon ?? "").Trim();
            object emailV = email.Length == 0 ? null : email;
            object telV = tel.Length == 0 ? null : tel;

            using (DbConn c = new DbConn())
            {
                c.Begin();
                if (e.Id == null)
                {
                    int max = Conv.ToInt(c.Scalar("SELECT MAX(CAST(SUBSTR(tag_id, 3) AS INTEGER)) FROM tag"));
                    newId = "T-" + (max + 1).ToString("D4");
                    int aktiv = Session.IsManager ? (e.Aktiv ? 1 : 0) : 1;
                    c.Exec("INSERT INTO tag (tag_id, vezeteknev, keresztnev, szuletesi_datum, email, telefon, belepes_datuma, aktiv) VALUES ($p0, $p1, $p2, $p3, $p4, $p5, $p6, $p7)",
                        newId, vn, kn, Fmt.ToDb(dob), emailV, telV, Fmt.ToDb(Clock.Today), aktiv);
                }
                else
                {
                    if (GetOn(c, e.Id) == null) return "A tag nem található!";
                    if (Session.IsManager)
                    {
                        c.Exec("UPDATE tag SET vezeteknev = $p0, keresztnev = $p1, szuletesi_datum = $p2, email = $p3, telefon = $p4, aktiv = $p5 WHERE tag_id = $p6",
                            vn, kn, Fmt.ToDb(dob), emailV, telV, e.Aktiv ? 1 : 0, e.Id);
                    }
                    else
                    {
                        // a pultos csak az e-mailt és a telefonszámot módosíthatja
                        c.Exec("UPDATE tag SET email = $p0, telefon = $p1 WHERE tag_id = $p2", emailV, telV, e.Id);
                    }
                }
                c.Commit();
            }
            return null;
        }
    }

    // Játékok

    public static class GameService
    {
        private const string Cols =
            "j.jatek_id, j.cim, j.kiado, j.kategoria_id, j.min_jatekos, j.max_jatekos, j.jatekido_perc, j.min_kor, j.nehezseg, j.napidij, j.kaucio";

        private const string CopySql = "SELECT p.leltari_szam, " + Cols + ", p.allapot, p.megjegyzes " +
            "FROM peldany p JOIN jatek j ON j.jatek_id = p.jatek_id";

        private static GameRow Map(object[] r)
        {
            GameRow g = new GameRow();
            g.Leltari = Conv.ToStr(r[0]);
            g.JatekId = Conv.ToInt(r[1]);
            g.Cim = Conv.ToStr(r[2]);
            g.Kiado = Conv.ToStr(r[3]);
            g.KategoriaId = Conv.ToInt(r[4]);
            g.MinJatekos = Conv.ToInt(r[5]);
            g.MaxJatekos = Conv.ToInt(r[6]);
            g.Perc = Conv.ToInt(r[7]);
            g.MinKor = Conv.ToInt(r[8]);
            g.Nehezseg = Conv.ToInt(r[9]);
            g.Napidij = Conv.ToInt(r[10]);
            g.Kaucio = Conv.ToInt(r[11]);
            g.Allapot = Conv.ToStr(r[12]);
            g.Megjegyzes = Conv.ToStr(r[13]);
            return g;
        }

        private static void SortItems(List<Item> l)
        {
            l.Sort(delegate (Item a, Item b) { return string.Compare(a.Text, b.Text, StringComparison.CurrentCultureIgnoreCase); });
        }

        public static List<Item> Categories()
        {
            List<Item> l = new List<Item>();
            using (DbConn c = new DbConn())
            {
                foreach (object[] r in c.Query("SELECT kategoria_id, nev FROM kategoria"))
                    l.Add(new Item(Conv.ToInt(r[0]), Conv.ToStr(r[1])));
            }
            SortItems(l);
            return l;
        }

        public static List<Item> Titles()
        {
            List<Item> l = new List<Item>();
            using (DbConn c = new DbConn())
            {
                foreach (object[] r in c.Query("SELECT jatek_id, cim FROM jatek"))
                    l.Add(new Item(Conv.ToInt(r[0]), Conv.ToStr(r[1])));
            }
            SortItems(l);
            return l;
        }

        public static GameRow CopyOn(DbConn c, string leltari)
        {
            List<object[]> rows = c.Query(CopySql + " WHERE p.leltari_szam = $p0", leltari);
            return rows.Count == 0 ? null : Map(rows[0]);
        }

        public static GameRow GetCopy(string leltari)
        {
            using (DbConn c = new DbConn()) return CopyOn(c, leltari);
        }

        // Játékcím adatai (példány nélkül)
        public static GameRow GetTitle(int jatekId)
        {
            using (DbConn c = new DbConn())
            {
                List<object[]> rows = c.Query(
                    "SELECT NULL, " + Cols + ", NULL, NULL FROM jatek j WHERE j.jatek_id = $p0", jatekId);
                return rows.Count == 0 ? null : Map(rows[0]);
            }
        }

        public static RentalRow OpenRentalOf(string leltari)
        {
            return RentalService.OpenOfCopy(leltari);
        }

        public static string Search(GameFilter f, out List<GameRow> rows)
        {
            rows = new List<GameRow>();
            string cim = (f.Cim ?? "").Trim();
            if (cim.Length > 80) return "A cím legfeljebb 80 karakter lehet!";
            if (!Rules.TextOk(cim)) return "A cím nem megengedett karaktert tartalmaz!";

            int players = 0;
            string pl = (f.Jatekosok ?? "").Trim();
            if (pl.Length > 0)
            {
                if (!int.TryParse(pl, NumberStyles.None, Fmt.Inv, out players) || players < 1 || players > 20)
                    return "A játékosszám 1 és 20 közötti egész szám lehet!";
            }

            List<GameRow> found = new List<GameRow>();
            using (DbConn c = new DbConn())
            {
                foreach (object[] r in c.Query(CopySql)) found.Add(Map(r));
            }

            foreach (GameRow g in found)
            {
                if (cim.Length > 0 && g.Cim.IndexOf(cim, StringComparison.CurrentCultureIgnoreCase) < 0) continue;
                if (f.KategoriaId.HasValue && g.KategoriaId != f.KategoriaId.Value) continue;
                if (pl.Length > 0 && (players < g.MinJatekos || players > g.MaxJatekos)) continue;
                if (!f.Allapotok.Contains(g.Allapot)) continue;
                rows.Add(g);
            }
            rows.Sort(delegate (GameRow a, GameRow b)
            {
                int d = string.Compare(a.Cim, b.Cim, StringComparison.CurrentCultureIgnoreCase);
                return d != 0 ? d : string.CompareOrdinal(a.Leltari, b.Leltari);
            });
            return null;
        }

        private static bool Num(string s, int min, int max, out int v)
        {
            return int.TryParse((s ?? "").Trim(), NumberStyles.None, Fmt.Inv, out v) && v >= min && v <= max;
        }

        private static string CheckData(GameEdit e)
        {
            string cim = (e.Cim ?? "").Trim();
            if (cim.Length == 0) return "A cím megadása kötelező!";
            if (cim.Length > 80) return "A cím legfeljebb 80 karakter lehet!";
            if (!Rules.TextOk(cim)) return "A cím nem megengedett karaktert tartalmaz!";
            string kiado = (e.Kiado ?? "").Trim();
            if (kiado.Length > 50) return "A kiadó legfeljebb 50 karakter lehet!";
            if (!Rules.TextOk(kiado)) return "A kiadó nem megengedett karaktert tartalmaz!";
            if (e.KategoriaId <= 0) return "A kategória kiválasztása kötelező!";

            int min, max, perc, kor, neh, nap, kauc;
            if (!Num(e.Min, 1, 20, out min)) return "A minimális játékosszám 1 és 20 közötti egész szám lehet!";
            if (!Num(e.Max, 1, 20, out max)) return "A maximális játékosszám 1 és 20 közötti egész szám lehet!";
            if (min > max) return "A minimális játékosszám nem lehet nagyobb a maximálisnál!";
            if (!Num(e.Perc, 1, 600, out perc)) return "A játékidő 1 és 600 perc közötti egész szám lehet!";
            if (!Num(e.MinKor, 0, 18, out kor)) return "A minimális kor 0 és 18 közötti egész szám lehet!";
            if (!Num(e.Nehezseg, 1, 5, out neh)) return "A nehézség 1 és 5 közötti egész szám lehet!";
            if (!Num(e.Napidij, 0, 9999, out nap)) return "A napidíj 0 és 9999 közötti egész szám lehet!";
            if (!Num(e.Kaucio, 0, 99999, out kauc)) return "A kaució 0 és 99999 közötti egész szám lehet!";
            return null;
        }

        public static string Validate(GameEdit e)
        {
            if (e.Mode != GameMode.Edit && !Session.IsManager)
                return "Új játék felvételéhez üzletvezetői jogosultság szükséges!";
            if (e.Mode == GameMode.Edit && !Session.IsManager && (e.ReEnable || e.Withdraw))
                return "Az állapotváltáshoz üzletvezetői jogosultság szükséges!";

            string err = Rules.CheckNote(e.Megjegyzes, false);
            if (err != null) return err;

            if (e.Mode == GameMode.NewTitle || (e.Mode == GameMode.Edit && Session.IsManager))
            {
                err = CheckData(e);
                if (err != null) return err;
            }

            if (e.Mode == GameMode.NewCopy && e.JatekId <= 0) return "A játékcím kiválasztása kötelező!";

            if (e.Mode != GameMode.Edit)
            {
                DateTime d;
                if (!Fmt.TryDate(e.Beszerzes, out d)) return "A beszerzés dátumának formátuma: éééé.hh.nn.";
                if (d > Clock.Today) return "A beszerzés dátuma nem lehet jövőbeli!";
                return null;
            }

            int flags = (e.MarkMissing ? 1 : 0) + (e.ReEnable ? 1 : 0) + (e.Withdraw ? 1 : 0);
            if (flags > 1) return "Egyszerre csak egy állapotváltás jelölhető!";

            GameRow g = GetCopy(e.Leltari);
            if (g == null) return "A példány nem található!";
            if (e.MarkMissing && g.Allapot != GameStates.Available)
                return "Hiányosnak csak készleten lévő példány jelölhető!";
            if (e.ReEnable && g.Allapot != GameStates.Missing && g.Allapot != GameStates.Withdrawn)
                return "Újra kölcsönözhetővé csak hiányos vagy kivont példány tehető!";
            if (e.Withdraw && g.Allapot != GameStates.Available && g.Allapot != GameStates.Missing)
                return "Kivonni csak készleten lévő vagy hiányos példányt lehet!";
            return null;
        }

        public static string Save(GameEdit e, out string newLeltari)
        {
            newLeltari = e.Leltari;
            string err = Validate(e);
            if (err != null) return err;

            string note = (e.Megjegyzes ?? "").Trim();
            object noteV = note.Length == 0 ? null : note;
            string kiado = (e.Kiado ?? "").Trim();
            object kiadoV = kiado.Length == 0 ? null : kiado;

            using (DbConn c = new DbConn())
            {
                c.Begin();

                if (e.Mode == GameMode.NewTitle || (e.Mode == GameMode.Edit && Session.IsManager))
                {
                    object[] data = {
                        e.Cim.Trim(), kiadoV, e.KategoriaId,
                        int.Parse(e.Min.Trim()), int.Parse(e.Max.Trim()), int.Parse(e.Perc.Trim()),
                        int.Parse(e.MinKor.Trim()), int.Parse(e.Nehezseg.Trim()),
                        int.Parse(e.Napidij.Trim()), int.Parse(e.Kaucio.Trim()) };

                    if (e.Mode == GameMode.NewTitle)
                    {
                        int jid = Conv.ToInt(c.Scalar("SELECT MAX(jatek_id) FROM jatek")) + 1;
                        c.Exec("INSERT INTO jatek (jatek_id, cim, kiado, kategoria_id, min_jatekos, max_jatekos, jatekido_perc, min_kor, nehezseg, napidij, kaucio) " +
                               "VALUES ($p0, $p1, $p2, $p3, $p4, $p5, $p6, $p7, $p8, $p9, $p10)",
                            jid, data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8], data[9]);
                        e.JatekId = jid;
                    }
                    else
                    {
                        GameRow g0 = CopyOn(c, e.Leltari);
                        if (g0 == null) return "A példány nem található!";
                        c.Exec("UPDATE jatek SET cim = $p0, kiado = $p1, kategoria_id = $p2, min_jatekos = $p3, max_jatekos = $p4, jatekido_perc = $p5, " +
                               "min_kor = $p6, nehezseg = $p7, napidij = $p8, kaucio = $p9 WHERE jatek_id = $p10",
                            data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8], data[9], g0.JatekId);
                    }
                }

                if (e.Mode == GameMode.Edit)
                {
                    GameRow g = CopyOn(c, e.Leltari);
                    if (g == null) return "A példány nem található!";
                    string state = g.Allapot;
                    if (e.MarkMissing) state = GameStates.Missing;
                    else if (e.ReEnable) state = GameStates.Available;
                    else if (e.Withdraw) state = GameStates.Withdrawn;
                    c.Exec("UPDATE peldany SET allapot = $p0, megjegyzes = $p1 WHERE leltari_szam = $p2", state, noteV, e.Leltari);
                }
                else
                {
                    if (Conv.ToInt(c.Scalar("SELECT COUNT(*) FROM jatek WHERE jatek_id = $p0", e.JatekId)) == 0)
                        return "A kiválasztott játékcím nem található!";
                    int max = Conv.ToInt(c.Scalar("SELECT MAX(CAST(SUBSTR(leltari_szam, 4) AS INTEGER)) FROM peldany"));
                    newLeltari = "JT-" + (max + 1).ToString("D4");
                    DateTime d;
                    Fmt.TryDate(e.Beszerzes, out d);
                    c.Exec("INSERT INTO peldany (leltari_szam, jatek_id, beszerzes_datuma, allapot, megjegyzes) VALUES ($p0, $p1, $p2, $p3, $p4)",
                        newLeltari, e.JatekId, Fmt.ToDb(d), GameStates.Available, noteV);
                }

                c.Commit();
            }
            return null;
        }
    }

    // Kölcsönzések

    public static class RentalService
    {
        public const int DefaultDays = 3;
        public const int MaxDays = 7;
        public const int MaxTakeAway = 2;
        public const int MinAge = 14;
        public const int LateMultiplier = 2;     // késedelmi díj = késedelmes napok x 2 x napidíj

        public class ReturnInput
        {
            public int Id;
            public string Visszavetel;      // üres = most
            public bool Hianyos;
            public bool KaucioVisszatartva;
            public string Megjegyzes;
        }

        private const string Sql =
            "SELECT k.kolcsonzes_id, k.leltari_szam, j.cim, k.tipus, k.tag_id, t.vezeteknev, t.keresztnev, k.asztalszam, k.kiado_dolgozo, " +
            "k.kivetel_ideje, k.hatarido, k.visszavetel_ideje, k.dij, k.kesedelmi_dij, k.hianyos, k.kaucio, k.napidij, k.kaucio_visszatartva, k.megjegyzes " +
            "FROM kolcsonzes k JOIN peldany p ON p.leltari_szam = k.leltari_szam JOIN jatek j ON j.jatek_id = p.jatek_id " +
            "LEFT JOIN tag t ON t.tag_id = k.tag_id";

        public static RentalRow Map(object[] r)
        {
            RentalRow x = new RentalRow();
            x.Id = Conv.ToInt(r[0]);
            x.Leltari = Conv.ToStr(r[1]);
            x.Cim = Conv.ToStr(r[2]);
            x.Tipus = Conv.ToStr(r[3]);
            x.TagId = Conv.ToStr(r[4]);
            x.TagNev = x.TagId == null ? null : Conv.ToStr(r[5]) + " " + Conv.ToStr(r[6]);
            x.Asztal = Conv.ToNullInt(r[7]);
            x.KiadoDolgozo = Conv.ToStr(r[8]);
            x.Kivetel = Fmt.FromDb(r[9]).Value;
            x.Hatarido = Fmt.FromDb(r[10]);
            x.Visszavetel = Fmt.FromDb(r[11]);
            x.Dij = Conv.ToInt(r[12]);
            x.KesedelmiDij = Conv.ToNullInt(r[13]);
            x.Hianyos = Conv.ToNullBool(r[14]);
            x.Kaucio = Conv.ToInt(r[15]);
            x.Napidij = Conv.ToInt(r[16]);
            x.KaucioVisszatartva = Conv.ToNullBool(r[17]);
            x.Megjegyzes = Conv.ToStr(r[18]);
            return x;
        }

        public static string BaseSql { get { return Sql; } }

        private static RentalRow GetOn(DbConn c, int id)
        {
            List<object[]> rows = c.Query(Sql + " WHERE k.kolcsonzes_id = $p0", id);
            return rows.Count == 0 ? null : Map(rows[0]);
        }

        public static RentalRow Get(int id)
        {
            using (DbConn c = new DbConn()) return GetOn(c, id);
        }

        public static RentalRow OpenOfCopy(string leltari)
        {
            using (DbConn c = new DbConn())
            {
                List<object[]> rows = c.Query(Sql + " WHERE k.leltari_szam = $p0 AND k.visszavetel_ideje IS NULL ORDER BY k.kivetel_ideje DESC", leltari);
                return rows.Count == 0 ? null : Map(rows[0]);
            }
        }

        // Kiadás

        private class Parsed
        {
            public GameRow Game;
            public MemberRow Member;
            public DateTime Kivetel;
            public DateTime? Hatarido;
            public int? Asztal;
            public int Napok;
            public bool Away;
        }

        // live = igaz: gépelés közbeni számítás, ilyenkor az asztalszám hiánya még nem hiba
        private static string CheckIssue(DbConn c, IssueInput x, bool live, out Parsed p)
        {
            p = new Parsed();
            p.Game = GameService.CopyOn(c, x.Leltari);
            if (p.Game == null) return "A kiválasztott példány nem található!";
            if (p.Game.Allapot != GameStates.Available)
                return "A példány nem kiadható (állapota: " + p.Game.Allapot + ")!";
            if (x.Tipus != RentalTypes.OnSite && x.Tipus != RentalTypes.TakeAway) return "Érvénytelen kölcsönzési típus!";
            p.Away = x.Tipus == RentalTypes.TakeAway;

            string kv = (x.Kivetel ?? "").Trim();
            if (kv.Length == 0) p.Kivetel = Clock.Now;
            else if (!Fmt.TryDateTime(kv, out p.Kivetel)) return "A kivétel ideje formátuma: éééé.hh.nn. óó:pp";

            string err = Rules.CheckNote(x.Megjegyzes, false);
            if (err != null) return err;

            string tagId = (x.TagId ?? "").Trim();
            if (p.Away && tagId.Length == 0) return "Elvitelhez tag megadása kötelező!";
            if (tagId.Length > 0)
            {
                p.Member = MemberService.GetOn(c, tagId);
                if (p.Member == null || !p.Member.Aktiv) return "Nem létező vagy inaktív tag-azonosító!";
            }

            if (p.Away)
            {
                if (MemberService.AgeOn(p.Member.Szuletes, Clock.Today) < MinAge)
                    return "14 éven aluli tag nem vihet el játékot!";

                DateTime h;
                if (!Fmt.TryDate(x.Hatarido, out h)) return "A határidő formátuma: éééé.hh.nn.";
                p.Hatarido = h;
                p.Napok = (h.Date - p.Kivetel.Date).Days;
                if (p.Napok < 1) return "A határidőnek a kivétel napja utáni napra kell esnie!";
                if (p.Napok > MaxDays) return "Az elvitel legfeljebb 7 napra lehetséges!";
                if (MemberService.OpenTakeAwayCountOn(c, tagId) >= MaxTakeAway)
                    return "Egy tag legfeljebb 2 játékot vihet el egyszerre!";
            }
            else if (!live)
            {
                int a;
                if (!int.TryParse((x.Asztal ?? "").Trim(), NumberStyles.None, Fmt.Inv, out a) || a < 1 || a > 20)
                    return "Az asztalszám 1 és 20 közötti egész szám lehet!";
                p.Asztal = a;
            }
            return null;
        }

        public static IssueCalc Calculate(IssueInput x)
        {
            IssueCalc res = new IssueCalc();
            try
            {
                using (DbConn c = new DbConn())
                {
                    Parsed p;
                    string err = CheckIssue(c, x, true, out p);
                    GameRow g = p.Game;
                    if (g != null && x.Tipus == RentalTypes.TakeAway)
                    {
                        DateTime kiv;
                        if (!Fmt.TryDateTime((x.Kivetel ?? "").Trim(), out kiv)) kiv = Clock.Now;
                        DateTime h;
                        if (Fmt.TryDate(x.Hatarido, out h))
                        {
                            int napok = (h.Date - kiv.Date).Days;
                            if (napok > 0)
                            {
                                res.Napok = napok;
                                res.Dij = napok * g.Napidij;
                            }
                        }
                        res.Kaucio = g.Kaucio;
                    }
                    if (err == null && p.Member != null && g != null &&
                        MemberService.AgeOn(p.Member.Szuletes, Clock.Today) < g.MinKor)
                    {
                        err = "Figyelem: a tag a játék ajánlott minimális kora (" + g.MinKor + " év) alatt van!";
                    }
                    res.Warning = err;
                }
            }
            catch (Exception ex)
            {
                res.Warning = "Hiba a számításnál: " + ex.Message;
            }
            return res;
        }

        public static string ValidateIssue(IssueInput x)
        {
            using (DbConn c = new DbConn())
            {
                Parsed p;
                return CheckIssue(c, x, false, out p);
            }
        }

        public static string Issue(IssueInput x, out int id)
        {
            id = 0;
            if (Session.UserId == null) return "Nincs bejelentkezett dolgozó!";

            using (DbConn c = new DbConn())
            {
                c.Begin();
                Parsed p;
                string err = CheckIssue(c, x, false, out p);
                if (err != null) return err;

                id = Conv.ToInt(c.Scalar("SELECT MAX(kolcsonzes_id) FROM kolcsonzes")) + 1;
                string tagId = (x.TagId ?? "").Trim();
                string note = (x.Megjegyzes ?? "").Trim();
                int dij = p.Away ? p.Napok * p.Game.Napidij : 0;
                int kaucio = p.Away ? p.Game.Kaucio : 0;

                c.Exec("INSERT INTO kolcsonzes (kolcsonzes_id, leltari_szam, tipus, tag_id, asztalszam, kiado_dolgozo, kivetel_ideje, hatarido, napidij, kaucio, dij, megjegyzes) " +
                       "VALUES ($p0, $p1, $p2, $p3, $p4, $p5, $p6, $p7, $p8, $p9, $p10, $p11)",
                    id, x.Leltari, x.Tipus,
                    tagId.Length == 0 ? null : tagId,
                    p.Away ? null : p.Asztal,
                    Session.UserId,
                    Fmt.ToDbTime(p.Kivetel),
                    p.Away ? Fmt.ToDb(p.Hatarido.Value) : null,
                    p.Game.Napidij, kaucio, dij,
                    note.Length == 0 ? null : note);

                c.Exec("UPDATE peldany SET allapot = $p0 WHERE leltari_szam = $p1",
                    p.Away ? GameStates.Taken : GameStates.InUse, x.Leltari);
                c.Commit();
            }
            return null;
        }

        // Visszavétel

        private static string CheckReturn(DbConn c, ReturnInput x, out RentalRow r, out DateTime when)
        {
            when = Clock.Now;
            r = GetOn(c, x.Id);
            if (r == null || !r.IsOpen) return "A kölcsönzés nem található vagy már le van zárva!";

            string vt = (x.Visszavetel ?? "").Trim();
            if (vt.Length > 0 && !Fmt.TryDateTime(vt, out when)) return "A visszavétel ideje formátuma: éééé.hh.nn. óó:pp";
            if (when < r.Kivetel) return "A visszavétel ideje nem lehet a kivétel ideje előtti!";

            string err = Rules.CheckNote(x.Megjegyzes, x.Hianyos);
            if (err != null) return err;

            if (x.KaucioVisszatartva)
            {
                if (!Session.IsManager) return "A kaució visszatartásához üzletvezetői jogosultság szükséges!";
                if (!r.IsTakeAway || !x.Hianyos) return "A kaució csak elvitelnél, hiányos játék esetén tartható vissza!";
            }
            return null;
        }

        public static ReturnCalc CalculateReturn(RentalRow r, ReturnInput x)
        {
            ReturnCalc res = new ReturnCalc();
            DateTime when;
            if (!Fmt.TryDateTime((x.Visszavetel ?? "").Trim(), out when)) when = Clock.Now;

            if (r.IsTakeAway)
            {
                if (r.Hatarido.HasValue)
                {
                    int late = (when.Date - r.Hatarido.Value.Date).Days;
                    if (late > 0)
                    {
                        res.KesedelmesNapok = late;
                        res.KesedelmiDij = late * LateMultiplier * r.Napidij;
                    }
                }
                res.VisszajaroKaucio = x.KaucioVisszatartva ? 0 : r.Kaucio;
            }
            return res;
        }

        public static string ValidateReturn(ReturnInput x)
        {
            using (DbConn c = new DbConn())
            {
                RentalRow r;
                DateTime when;
                return CheckReturn(c, x, out r, out when);
            }
        }

        public static string Return(ReturnInput x)
        {
            if (Session.UserId == null) return "Nincs bejelentkezett dolgozó!";

            using (DbConn c = new DbConn())
            {
                c.Begin();
                RentalRow r;
                DateTime when;
                string err = CheckReturn(c, x, out r, out when);
                if (err != null) return err;

                // a visszavétel idejét a számításhoz is a ténylegesen rögzített időből vesszük
                ReturnInput calcIn = new ReturnInput();
                calcIn.Visszavetel = Fmt.ShowTime(when);
                calcIn.KaucioVisszatartva = x.KaucioVisszatartva;
                ReturnCalc calc = CalculateReturn(r, calcIn);

                string ret = (x.Megjegyzes ?? "").Trim();
                string note = r.Megjegyzes;
                if (ret.Length > 0) note = string.IsNullOrEmpty(note) ? ret : note + " | " + ret;

                c.Exec("UPDATE kolcsonzes SET visszavetel_ideje = $p0, visszavevo_dolgozo = $p1, kesedelmi_dij = $p2, hianyos = $p3, " +
                       "kaucio_visszatartva = $p4, megjegyzes = $p5 WHERE kolcsonzes_id = $p6",
                    Fmt.ToDbTime(when), Session.UserId,
                    r.IsTakeAway ? (object)calc.KesedelmiDij : null,
                    x.Hianyos ? 1 : 0,
                    r.IsTakeAway ? (object)(x.KaucioVisszatartva ? 1 : 0) : null,
                    string.IsNullOrEmpty(note) ? null : note,
                    r.Id);

                if (x.Hianyos)
                {
                    c.Exec("UPDATE peldany SET allapot = $p0, megjegyzes = $p1 WHERE leltari_szam = $p2",
                        GameStates.Missing, ret.Length == 0 ? null : ret, r.Leltari);
                }
                else
                {
                    c.Exec("UPDATE peldany SET allapot = $p0 WHERE leltari_szam = $p1", GameStates.Available, r.Leltari);
                }
                c.Commit();
            }
            return null;
        }
    }

    // Napló

    public static class LogService
    {
        public static List<KeyValuePair<string, string>> AllCopies()
        {
            List<KeyValuePair<string, string>> l = new List<KeyValuePair<string, string>>();
            using (DbConn c = new DbConn())
            {
                foreach (object[] r in c.Query(
                    "SELECT p.leltari_szam, j.cim FROM peldany p JOIN jatek j ON j.jatek_id = p.jatek_id ORDER BY p.leltari_szam"))
                {
                    l.Add(new KeyValuePair<string, string>(Conv.ToStr(r[0]), Conv.ToStr(r[0]) + " – " + Conv.ToStr(r[1])));
                }
            }
            return l;
        }

        public static List<KeyValuePair<string, string>> AllMembers()
        {
            List<KeyValuePair<string, string>> l = new List<KeyValuePair<string, string>>();
            using (DbConn c = new DbConn())
            {
                foreach (object[] r in c.Query("SELECT tag_id, vezeteknev, keresztnev FROM tag ORDER BY tag_id"))
                {
                    l.Add(new KeyValuePair<string, string>(Conv.ToStr(r[0]), Conv.ToStr(r[0]) + " – " + Conv.ToStr(r[1]) + " " + Conv.ToStr(r[2])));
                }
            }
            return l;
        }

        public static string Query(LogFilter f, out List<RentalRow> rows)
        {
            rows = new List<RentalRow>();
            DateTime from, to;
            if (!Fmt.TryDateTime(f.From, out from)) return "Az időszak kezdete formátuma: éééé.hh.nn. óó:pp";
            if (!Fmt.TryDateTime(f.To, out to)) return "Az időszak vége formátuma: éééé.hh.nn. óó:pp";
            if (from > to) return "Az időszak kezdete nem lehet későbbi a végénél!";

            if (!f.OnSite && !f.TakeAway) return null;
            if (!f.Open && !f.Closed) return null;

            List<object> p = new List<object>();
            List<string> where = new List<string>();

            p.Add(Fmt.ToDbTime(from));
            where.Add("k.kivetel_ideje >= $p" + (p.Count - 1));
            p.Add(Fmt.ToDbTime(to));
            where.Add("k.kivetel_ideje <= $p" + (p.Count - 1));

            if (f.OnSite != f.TakeAway)
            {
                p.Add(f.OnSite ? RentalTypes.OnSite : RentalTypes.TakeAway);
                where.Add("k.tipus = $p" + (p.Count - 1));
            }
            if (f.Open != f.Closed)
            {
                where.Add(f.Open ? "k.visszavetel_ideje IS NULL" : "k.visszavetel_ideje IS NOT NULL");
            }
            if (!string.IsNullOrEmpty(f.Leltari))
            {
                p.Add(f.Leltari);
                where.Add("k.leltari_szam = $p" + (p.Count - 1));
            }
            if (!string.IsNullOrEmpty(f.TagId))
            {
                p.Add(f.TagId);
                where.Add("k.tag_id = $p" + (p.Count - 1));
            }

            string sql = RentalService.BaseSql + " WHERE " + string.Join(" AND ", where) +
                         " ORDER BY k.kivetel_ideje DESC, k.kolcsonzes_id DESC";
            using (DbConn c = new DbConn())
            {
                foreach (object[] r in c.Query(sql, p.ToArray())) rows.Add(RentalService.Map(r));
            }
            return null;
        }
    }
}
