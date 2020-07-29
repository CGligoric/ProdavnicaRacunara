using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica_racunara.Moduli
{
    class ArtikalProdaje : IComparable<ArtikalProdaje>
    {
        private readonly int brojac = 0;

        public int Sifra { get; set; }
        public string Naziv { get; set; }
        public int Cena { get; set; }
        public int Kolicina { get; set; }
        public string Opis { get; set; }
        public bool Izbrisan { get; set; }

        public ArtikalProdaje(int sifra, string naziv, int cena, int kolicina, string opis, bool izbrisan = false)
        {
            Sifra = sifra;
            Naziv = naziv;
            Cena = cena;
            Kolicina = kolicina;
            Opis = opis;
            Izbrisan = izbrisan;
        }

        public ArtikalProdaje()
        {

        }

        public ArtikalProdaje(string s)
        {
            string[] delovi = s.Split(',');
            Sifra = Convert.ToInt32(delovi[0]);
            Naziv = delovi[1];
            Cena = Int32.Parse(delovi[2]);
            Kolicina = Int32.Parse(delovi[3]);
            Opis = delovi[4];
            Izbrisan = Convert.ToBoolean(delovi[5]);
        }

        public override string ToString()
        {
            return String.Format("Sifra: {0} | Naziv: {1} | Cena: {2} | Kolicina: {3} | Opis: {4}", Sifra, Naziv, Cena, Kolicina, Opis);
        }

        public virtual string ToFileString()
        {
            return String.Format("{0},{1},{2},{3},{4}", Naziv, Cena, Kolicina, Opis, Izbrisan);
        }

        public int CompareTo(ArtikalProdaje ap)
        {
            return this.Naziv.CompareTo(ap.Naziv);
        }
    }
}
