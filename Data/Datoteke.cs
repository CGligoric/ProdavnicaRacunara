using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica_racunara.Data
{
    static class Datoteke
    {
        public static readonly string DataDir = "Data";

        public static readonly string ArtikalData = "artikal-prodaje.csv";
        public static readonly string KategorijeData = "kategorije.csv";
        public static readonly string KorisnikData = "korisnik.csv";
        public static readonly string RacunData = "racuni.csv";

        private static char sep = Path.DirectorySeparatorChar;

        public static string ArtikalFullPath { private set; get; }
        public static string KategorijeFullPath { private set; get; }
        public static string KorisnikFullPath { private set; get; }
        public static string RacunFullPath { private set; get; }

        public static string PodesiPutanju()
        {
            string trenutnaPutanja = Directory.GetCurrentDirectory();
            string putanja = "";

            string putanjaProjekta = new DirectoryInfo(trenutnaPutanja).Parent.Parent.FullName;
            putanja = putanjaProjekta + sep + DataDir + sep;

            KategorijeFullPath = putanja + KategorijeData;
            KorisnikFullPath = putanja + KorisnikData;
            ArtikalFullPath = putanja + ArtikalData;
            RacunFullPath = putanja + RacunData;
            return putanja;
        }

    }
}
