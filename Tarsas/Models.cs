using System;
using System.Collections.Generic;

namespace TKR
{
    // A játékpéldányok lehetséges állapotai
    public static class GameStates
    {
        public const string Available = "Készleten";
        public const string InUse = "Használatban";
        public const string Taken = "Elvitt";
        public const string Missing = "Hiányos";
        public const string Withdrawn = "Kivonva";

        public static readonly string[] All = { Available, InUse, Taken, Missing, Withdrawn };
    }

    public static class RentalTypes
    {
        public const string OnSite = "Helyben";
        public const string TakeAway = "Elvitel";
    }

    // Egy elem a legördülő listákhoz (azonosító + szöveg)
    public class Item
    {
        public int Id;
        public string Text;
        public Item(int id, string text) { Id = id; Text = text; }
        public override string ToString() { return Text; }
    }

    // Egy játékpéldány (vagy játékcím, ha a Leltari null)
    public class GameRow
    {
        public string Leltari;
        public int JatekId;
        public string Cim;
        public string Kiado;
        public int KategoriaId;
        public int MinJatekos;
        public int MaxJatekos;
        public int Perc;
        public int MinKor;
        public int Nehezseg;
        public int Napidij;
        public int Kaucio;
        public string Allapot;
        public string Megjegyzes;

        public string Jatekosok
        {
            get { return MinJatekos == MaxJatekos ? MinJatekos.ToString() : MinJatekos + "–" + MaxJatekos; }
        }
    }

    public class GameFilter
    {
        public string Cim = "";
        public int? KategoriaId = null;
        public string Jatekosok = "";
        public List<string> Allapotok = new List<string>();
    }

    public enum GameMode { NewCopy, NewTitle, Edit }

    public class GameEdit
    {
        public GameMode Mode;
        public string Leltari;
        public int JatekId;
        public string Beszerzes;
        public string Cim;
        public string Kiado;
        public int KategoriaId;
        public string Min, Max, Perc, MinKor, Nehezseg, Napidij, Kaucio;
        public string Megjegyzes;
        public bool MarkMissing;
        public bool ReEnable;
        public bool Withdraw;
    }

    public class MemberRow
    {
        public string Id;
        public string Vezeteknev;
        public string Keresztnev;
        public DateTime Szuletes;
        public string Email;
        public string Telefon;
        public DateTime Belepes;
        public bool Aktiv;

        public string FullName { get { return Vezeteknev + " " + Keresztnev; } }
    }

    public class MemberEdit
    {
        public string Id;          // null = új tag
        public string Vezeteknev;
        public string Keresztnev;
        public string Szuletes;
        public string Email;
        public string Telefon;
        public bool Aktiv;
    }

    public class RentalRow
    {
        public int Id;
        public string Leltari;
        public string Cim;
        public string Tipus;
        public string TagId;
        public string TagNev;
        public int? Asztal;
        public string KiadoDolgozo;
        public DateTime Kivetel;
        public DateTime? Hatarido;
        public DateTime? Visszavetel;
        public int Napidij;
        public int Kaucio;
        public int Dij;
        public int? KesedelmiDij;
        public bool? Hianyos;
        public bool? KaucioVisszatartva;
        public string Megjegyzes;

        public bool IsOpen { get { return !Visszavetel.HasValue; } }
        public bool IsTakeAway { get { return Tipus == RentalTypes.TakeAway; } }

        // A "Tag / asztal" oszlop szövege
        public string TagAsztal
        {
            get
            {
                string tag = TagId == null ? "" : TagNev + " (" + TagId + ")";
                if (IsTakeAway) return tag;
                string t = (Asztal.HasValue ? Asztal.Value + ". asztal" : "–");
                return tag.Length > 0 ? t + ", " + tag : t;
            }
        }
    }

    public class IssueInput
    {
        public string Leltari;
        public string Tipus;
        public string Asztal;
        public string TagId;
        public string Kivetel;      // üres = most
        public string Hatarido;
        public string Megjegyzes;
    }

    public class IssueCalc
    {
        public int Napok;
        public int Dij;
        public int Kaucio;
        public string Warning;
    }

    public class ReturnCalc
    {
        public int KesedelmesNapok;
        public int KesedelmiDij;
        public int VisszajaroKaucio;
    }

    public class LogFilter
    {
        public string From = "";
        public string To = "";
        public bool OnSite = true;
        public bool TakeAway = true;
        public bool Open = true;
        public bool Closed = true;
        public string Leltari = "";
        public string TagId = "";
    }
}
