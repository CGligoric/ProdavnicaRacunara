using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica_racunara.Moduli
{
    class GotovaKonfiguracija : ArtikalProdaje,IComparable<GotovaKonfiguracija>
    {
        private readonly int brojac = 0;
        public List<KomponentaRacunara> ListaKomponenti { get; set; }

        public GotovaKonfiguracija() { }

        public GotovaKonfiguracija(int sifra, string naziv, int cena, int kolicina, string opis) : base(sifra, naziv, cena, kolicina, opis)
        {
        }

        public GotovaKonfiguracija(string s)
        {
            string[] delovi = s.Split(',');
            Sifra = Convert.ToInt32(delovi[0]);
            Naziv = delovi[1];
            Cena = Int32.Parse(delovi[2]);
            Kolicina = Int32.Parse(delovi[3]);
            Opis = delovi[4];
            Izbrisan = Convert.ToBoolean(delovi[5]);
        }

        public int CompareTo(GotovaKonfiguracija other)
        {
            return this.Naziv.CompareTo(other.Naziv);
        }

        // METODE ToString() I ToFileString() NISU OVDE ZATO STO NEMA STA DA SE REDEFINISE KOD NJIH U OVOJ KLASI
    }
}
