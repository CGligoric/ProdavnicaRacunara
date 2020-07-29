using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica_racunara.Moduli
{
    class MemorijaRacunara : KomponentaRacunara
    {
        public int Kapacitet { get; set; }

        public MemorijaRacunara()
        {

        }

        public MemorijaRacunara(int sifra, string naziv, int cena, int kolicina, string opis,
            string kategorijaKomponente, int kapacitet) : base(sifra, naziv, cena, kolicina, opis, kategorijaKomponente)
        {
            Kapacitet = kapacitet;
        }

        public MemorijaRacunara(string s)
        {
            string[] delovi = s.Split(',');
            Sifra = Convert.ToInt32(delovi[0]);
            Naziv = delovi[1];
            Cena = Convert.ToInt32(delovi[2]);
            Kolicina = Convert.ToInt32(delovi[3]);
            Opis = delovi[4];
            Izbrisan = Convert.ToBoolean(delovi[5]);
            KategorijaKomponente = delovi[6];
            Kapacitet = Int32.Parse(delovi[7]);
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(" | Kapacitet: {0}", Kapacitet);
        }

        public override string ToFileString()
        {
            return base.ToFileString() + String.Format(",{0}", Kapacitet);
        }
    }
}
