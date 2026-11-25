using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.Sqlite;

namespace TKR
{
    // Az aktuális idő
    public static class Clock
    {
        public static DateTime Now
        {
            get
            {
                DateTime n = DateTime.Now;
                // másodperc nélkül, mert az adatbázisban is úgy tároljuk
                return new DateTime(n.Year, n.Month, n.Day, n.Hour, n.Minute, 0);
            }
        }

        public static DateTime Today { get { return Now.Date; } }
    }

    // A bejelentkezett dolgozó adatai
    public static class Session
    {
        public static string UserId;
        public static string FullName;
        public static string Role;   // "pultos" vagy "uzletvezeto"

        public static bool IsManager { get { return Role == "uzletvezeto"; } }

        public static void Clear()
        {
            UserId = null;
            FullName = null;
            Role = null;
        }
    }

    // Adatbázisból jövő értékek átalakítása (a NULL DBNull-ként érkezik)
    public static class Conv
    {
        public static string ToStr(object o)
        {
            if (o == null || o is DBNull) return null;
            return o.ToString();
        }

        public static int ToInt(object o)
        {
            if (o == null || o is DBNull) return 0;
            return Convert.ToInt32(o);
        }

        public static int? ToNullInt(object o)
        {
            if (o == null || o is DBNull) return null;
            return Convert.ToInt32(o);
        }

        // az SQLite-ban a logikai érték 0 vagy 1
        public static bool ToBool(object o)
        {
            if (o == null || o is DBNull) return false;
            return Convert.ToInt32(o) == 1;
        }

        public static bool? ToNullBool(object o)
        {
            if (o == null || o is DBNull) return null;
            return Convert.ToInt32(o) == 1;
        }
    }

    // Dátumok kezelése
    public static class Fmt
    {
        public static readonly CultureInfo Inv = CultureInfo.InvariantCulture;

        // Felületi formátum: 2026.10.05. és 2026.10.05. 14:05
        // A dátum végi pont elhagyható (2026.10.05 is jó)
        public static bool TryDate(string s, out DateTime d)
        {
            if (s == null) s = "";
            string[] formats = { "yyyy.MM.dd.", "yyyy.MM.dd" };
            return DateTime.TryParseExact(s.Trim(), formats, Inv, DateTimeStyles.None, out d);
        }

        public static bool TryDateTime(string s, out DateTime d)
        {
            if (s == null) s = "";
            string[] formats = { "yyyy.MM.dd. HH:mm", "yyyy.MM.dd HH:mm" };
            return DateTime.TryParseExact(s.Trim(), formats, Inv, DateTimeStyles.None, out d);
        }

        public static string Show(DateTime d) { return d.ToString("yyyy.MM.dd.", Inv); }
        public static string ShowTime(DateTime d) { return d.ToString("yyyy.MM.dd. HH:mm", Inv); }

        // Adatbázis formátum: 2026-10-05 és 2026-10-05 14:05 (így lehet szövegként összehasonlítani)
        public static string ToDb(DateTime d) { return d.ToString("yyyy-MM-dd", Inv); }
        public static string ToDbTime(DateTime d) { return d.ToString("yyyy-MM-dd HH:mm", Inv); }

        // Mindkettő ugyanazt csinálja: a szöveget DateTime-má alakítja, NULL esetén null
        public static DateTime? FromDb(object o)
        {
            string s = Conv.ToStr(o);
            if (s == null) return null;
            string[] formats = { "yyyy-MM-dd", "yyyy-MM-dd HH:mm" };
            return DateTime.ParseExact(s, formats, Inv, DateTimeStyles.None);
        }

        public static DateTime? FromDbTime(object o)
        {
            return FromDb(o);
        }
    }

    // Beviteli szabályok
    public static class Rules
    {
        public static bool UserIdOk(string s)
        {
            if (s == null || s.Length == 0 || s.Length > 30) return false;
            foreach (char c in s)
            {
                bool ok = (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') || c == '-';
                if (!ok) return false;
            }
            return true;
        }

        public static bool PasswordOk(string s)
        {
            if (s == null || s.Length < 5 || s.Length > 30) return false;
            foreach (char c in s)
            {
                // csak a látható ASCII karakterek (szóköz és ékezet nem)
                if (c < 33 || c > 126) return false;
            }
            return true;
        }

        // betű, szám, írásjel, szóköz
        public static bool TextOk(string s)
        {
            if (s == null) return true;
            foreach (char c in s)
            {
                if (!char.IsLetterOrDigit(c) && !char.IsPunctuation(c) && c != ' ') return false;
            }
            return true;
        }

        public static bool NameOk(string s)
        {
            if (s == null || s.Length == 0) return false;
            foreach (char c in s)
            {
                if (!char.IsLetter(c) && c != ' ' && c != '-') return false;
            }
            return true;
        }

        public static bool EmailOk(string s)
        {
            if (s == null || s.Length > 100) return false;
            int at = s.IndexOf('@');
            if (at < 1 || at != s.LastIndexOf('@')) return false;
            string domain = s.Substring(at + 1);
            int dot = domain.LastIndexOf('.');
            if (dot < 1 || dot == domain.Length - 1) return false;
            return s.IndexOf(' ') < 0;
        }

        public static bool PhoneOk(string s)
        {
            if (s == null || s.Length > 20) return false;
            foreach (char c in s)
            {
                if (!char.IsDigit(c) && c != '+' && c != ' ' && c != '-') return false;
            }
            return true;
        }

        // Megjegyzés ellenőrzése. Hibaüzenetet ad vissza, vagy null-t, ha rendben van.
        public static string CheckNote(string note, bool required)
        {
            if (note == null) note = "";
            note = note.Trim();
            if (note.Length == 0)
            {
                if (required) return "A megjegyzés megadása kötelező!";
                return null;
            }
            if (note.Length > 500) return "A megjegyzés legfeljebb 500 karakter lehet!";
            if (!TextOk(note)) return "A megjegyzés nem megengedett karaktert tartalmaz!";
            return null;
        }
    }

    // Jelszó hash-elés SHA256-tal, hogy ne sima szövegként legyen az adatbázisban
    public static class Security
    {
        public static string Hash(string password)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(bytes);
        }

        public static bool Verify(string password, string stored)
        {
            return Hash(password) == stored;
        }
    }

    // Adatbázis-kapcsolat, using blokkban kell használni.
    // A paraméterek az SQL-ben $p0, $p1, ... néven szerepelnek.
    public class DbConn : IDisposable
    {
        private SqliteConnection conn;
        private SqliteTransaction tran;

        public DbConn()
        {
            conn = new SqliteConnection("Data Source=" + Db.Path);
            conn.Open();
            Exec("PRAGMA foreign_keys = ON");
        }

        private SqliteCommand MakeCommand(string sql, object[] p)
        {
            SqliteCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Transaction = tran;
            if (p != null)
            {
                for (int i = 0; i < p.Length; i++)
                {
                    object value = p[i];
                    if (value == null) value = DBNull.Value;
                    cmd.Parameters.AddWithValue("$p" + i, value);
                }
            }
            return cmd;
        }

        public List<object[]> Query(string sql, params object[] p)
        {
            List<object[]> rows = new List<object[]>();
            using (SqliteCommand cmd = MakeCommand(sql, p))
            using (SqliteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] row = new object[reader.FieldCount];
                    reader.GetValues(row);
                    rows.Add(row);
                }
            }
            return rows;
        }

        public int Exec(string sql, params object[] p)
        {
            using (SqliteCommand cmd = MakeCommand(sql, p))
            {
                return cmd.ExecuteNonQuery();
            }
        }

        public object Scalar(string sql, params object[] p)
        {
            using (SqliteCommand cmd = MakeCommand(sql, p))
            {
                return cmd.ExecuteScalar();
            }
        }

        public void Begin()
        {
            tran = conn.BeginTransaction();
        }

        public void Commit()
        {
            tran.Commit();
            tran.Dispose();
            tran = null;
        }

        // ha hiba miatt nem volt Commit, a módosítások nem mentődnek el
        public void Dispose()
        {
            if (tran != null) tran.Rollback();
            conn.Close();
        }
    }

    // Adatbázis létrehozása mintaadatokkal
    public static class Db
    {
        public static string Path = System.IO.Path.Combine(AppContext.BaseDirectory, "tkr.db");

        private const string Schema = @"
CREATE TABLE kategoria (
    kategoria_id INTEGER PRIMARY KEY,
    nev TEXT NOT NULL UNIQUE
);

CREATE TABLE jatek (
    jatek_id INTEGER PRIMARY KEY,
    cim TEXT NOT NULL,
    kiado TEXT,
    kategoria_id INTEGER NOT NULL REFERENCES kategoria(kategoria_id),
    min_jatekos INTEGER NOT NULL CHECK (min_jatekos BETWEEN 1 AND 20),
    max_jatekos INTEGER NOT NULL CHECK (max_jatekos BETWEEN 1 AND 20),
    jatekido_perc INTEGER NOT NULL CHECK (jatekido_perc BETWEEN 1 AND 600),
    min_kor INTEGER NOT NULL CHECK (min_kor BETWEEN 0 AND 18),
    nehezseg INTEGER NOT NULL CHECK (nehezseg BETWEEN 1 AND 5),
    napidij INTEGER NOT NULL CHECK (napidij BETWEEN 0 AND 9999),
    kaucio INTEGER NOT NULL CHECK (kaucio BETWEEN 0 AND 99999),
    CHECK (min_jatekos <= max_jatekos)
);

CREATE TABLE peldany (
    leltari_szam TEXT PRIMARY KEY,
    jatek_id INTEGER NOT NULL REFERENCES jatek(jatek_id),
    beszerzes_datuma TEXT NOT NULL,
    allapot TEXT NOT NULL DEFAULT 'Készleten'
        CHECK (allapot IN ('Készleten', 'Használatban', 'Elvitt', 'Hiányos', 'Kivonva')),
    megjegyzes TEXT
);

CREATE TABLE tag (
    tag_id TEXT PRIMARY KEY,
    vezeteknev TEXT NOT NULL,
    keresztnev TEXT NOT NULL,
    szuletesi_datum TEXT NOT NULL,
    email TEXT,
    telefon TEXT,
    belepes_datuma TEXT NOT NULL,
    aktiv INTEGER NOT NULL DEFAULT 1
);

CREATE TABLE dolgozo (
    felhasznalo_id TEXT PRIMARY KEY,
    vezeteknev TEXT NOT NULL,
    keresztnev TEXT NOT NULL,
    szerepkor TEXT NOT NULL CHECK (szerepkor IN ('pultos', 'uzletvezeto')),
    jelszo_hash TEXT NOT NULL,
    aktiv INTEGER NOT NULL DEFAULT 1
);

CREATE TABLE kolcsonzes (
    kolcsonzes_id INTEGER PRIMARY KEY,
    leltari_szam TEXT NOT NULL REFERENCES peldany(leltari_szam),
    tipus TEXT NOT NULL CHECK (tipus IN ('Helyben', 'Elvitel')),
    tag_id TEXT REFERENCES tag(tag_id),
    asztalszam INTEGER CHECK (asztalszam BETWEEN 1 AND 20),
    kiado_dolgozo TEXT NOT NULL REFERENCES dolgozo(felhasznalo_id),
    kivetel_ideje TEXT NOT NULL,
    hatarido TEXT,
    visszavetel_ideje TEXT,
    visszavevo_dolgozo TEXT REFERENCES dolgozo(felhasznalo_id),
    napidij INTEGER NOT NULL DEFAULT 0,
    kaucio INTEGER NOT NULL DEFAULT 0,
    dij INTEGER NOT NULL,
    kesedelmi_dij INTEGER,
    hianyos INTEGER,
    kaucio_visszatartva INTEGER,
    megjegyzes TEXT,
    CHECK (tipus <> 'Elvitel' OR (tag_id IS NOT NULL AND hatarido IS NOT NULL)),
    CHECK (tipus <> 'Helyben' OR asztalszam IS NOT NULL)
);

CREATE TRIGGER kolcsonzes_nem_torolheto BEFORE DELETE ON kolcsonzes
BEGIN
    SELECT RAISE(ABORT, 'A kölcsönzési napló tételei nem törölhetők!');
END;

CREATE TRIGGER tag_nem_torolheto BEFORE DELETE ON tag
BEGIN
    SELECT RAISE(ABORT, 'A tag nem törölhető, csak inaktiválható!');
END;
";

        private const string SampleData = @"
INSERT INTO kategoria VALUES (1, 'Családi'), (2, 'Stratégiai'), (3, 'Party'), (4, 'Kooperatív'), (5, 'Kártyajáték'), (6, 'Gyerek');

INSERT INTO jatek VALUES (1, 'Catan', 'Kosmos', 2, 3, 4, 75, 10, 3, 600, 8000);
INSERT INTO jatek VALUES (2, 'Carcassonne', 'Hans im Glück', 1, 2, 5, 35, 7, 2, 400, 6000);
INSERT INTO jatek VALUES (3, 'Dixit', 'Libellud', 3, 3, 6, 30, 8, 1, 400, 6000);
INSERT INTO jatek VALUES (4, 'Ticket to Ride', 'Days of Wonder', 1, 2, 5, 60, 8, 2, 700, 9000);
INSERT INTO jatek VALUES (5, 'Pandemic', 'Z-Man Games', 4, 2, 4, 45, 8, 3, 600, 8000);
INSERT INTO jatek VALUES (6, 'Dobble', 'Asmodee', 5, 2, 8, 15, 6, 1, 300, 4000);

INSERT INTO peldany VALUES ('JT-0001', 1, '2025-02-01', 'Készleten', NULL);
INSERT INTO peldany VALUES ('JT-0002', 2, '2025-02-01', 'Elvitt', NULL);
INSERT INTO peldany VALUES ('JT-0003', 3, '2025-03-15', 'Készleten', NULL);
INSERT INTO peldany VALUES ('JT-0004', 4, '2025-05-10', 'Készleten', NULL);
INSERT INTO peldany VALUES ('JT-0005', 5, '2025-05-10', 'Hiányos', '1 db szerepkártya hiányzik');
INSERT INTO peldany VALUES ('JT-0006', 6, '2025-08-20', 'Használatban', NULL);
INSERT INTO peldany VALUES ('JT-0007', 1, '2026-01-12', 'Elvitt', NULL);

INSERT INTO tag VALUES ('T-0001', 'Kovács', 'Anna', '1990-04-17', 'anna.kovacs@example.com', '+36 30 111 2233', '2025-02-10', 1);
INSERT INTO tag VALUES ('T-0002', 'Szabó', 'Bence', '1998-11-02', 'bence.szabo@example.com', NULL, '2025-06-21', 1);
INSERT INTO tag VALUES ('T-0003', 'Nagy', 'Eszter', '1985-07-23', 'eszter.nagy@example.com', '+36 30 555 0123', '2025-03-14', 1);
INSERT INTO tag VALUES ('T-0004', 'Tóth', 'Gergő', '2001-01-30', NULL, '+36 20 444 5566', '2026-01-18', 1);
INSERT INTO tag VALUES ('T-0005', 'Horváth', 'Lilla', '2015-03-12', NULL, NULL, '2026-08-30', 1);

INSERT INTO kolcsonzes VALUES (1001, 'JT-0001', 'Elvitel', 'T-0001', NULL, 'VargaDora', '2026-11-21 17:10', '2026-11-24', '2026-11-25 16:40', 'VargaDora', 600, 8000, 1800, 1200, 0, 0, NULL);
INSERT INTO kolcsonzes VALUES (1002, 'JT-0004', 'Helyben', NULL, 4, 'VargaDora', '2026-11-23 15:20', NULL, '2026-11-23 17:55', 'VargaDora', 700, 0, 0, NULL, 0, NULL, NULL);
INSERT INTO kolcsonzes VALUES (1003, 'JT-0005', 'Helyben', 'T-0003', 2, 'KissMarton', '2026-11-24 18:00', NULL, '2026-11-24 19:30', 'KissMarton', 600, 0, 0, NULL, 1, NULL, '1 db szerepkártya hiányzik');
INSERT INTO kolcsonzes VALUES (1004, 'JT-0002', 'Elvitel', 'T-0002', NULL, 'VargaDora', '2026-11-25 12:30', '2026-11-28', NULL, NULL, 400, 6000, 1200, NULL, NULL, NULL, NULL);
INSERT INTO kolcsonzes VALUES (1005, 'JT-0006', 'Helyben', NULL, 6, 'VargaDora', '2026-11-25 13:40', NULL, NULL, NULL, 300, 0, 0, NULL, NULL, NULL, NULL);
INSERT INTO kolcsonzes VALUES (1006, 'JT-0007', 'Elvitel', 'T-0002', NULL, 'VargaDora', '2026-11-25 12:35', '2026-11-29', NULL, NULL, 600, 8000, 2400, NULL, NULL, NULL, NULL);
";

        // Létrehozza az adatbázist, ha még nincs
        public static void Init()
        {
            if (File.Exists(Path)) return;

            using (DbConn c = new DbConn())
            {
                c.Begin();
                c.Exec(Schema);
                // a dolgozók kellenek előbb, mert a kölcsönzések hivatkoznak rájuk
                c.Exec("INSERT INTO dolgozo VALUES ('VargaDora', 'Varga', 'Dóra', 'pultos', $p0, 1)", Security.Hash("Pultos2026"));
                c.Exec("INSERT INTO dolgozo VALUES ('KissMarton', 'Kiss', 'Márton', 'pultos', $p0, 1)", Security.Hash("Pultos2026"));
                c.Exec("INSERT INTO dolgozo VALUES ('GramaAkos', 'Grama', 'Ákos', 'uzletvezeto', $p0, 1)", Security.Hash("Vezeto"));
                c.Exec(SampleData);
                c.Commit();
            }
        }
    }
}
