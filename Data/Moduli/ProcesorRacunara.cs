using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica_racunara.Moduli
{
    class ProcesorRacunara : KomponentaRacunara
    {
        public float RadniTakt { get; set; }
        public int BrojJezgara { get; set; }

        public ProcesorRacunara()
        {

        }

        public ProcesorRacunara(int sifra, string naziv, int cena, int kolicina, string opis,
            string kategorijaKomponente, int radniTakt, int brojJezgara) : base(sifra, naziv, cena, kolicina, opis, kategorijaKomponente)
        {
            RadniTakt = radniTakt;
            BrojJezgara = brojJezgara;
        }

        public ProcesorRacunara(string s)
        {
            string[] delovi = s.Split(',');
            Sifra = Convert.ToInt32(delovi[0]);
            Naziv = delovi[1];
            Cena = Convert.ToInt32(delovi[2]);
            Kolicina = Convert.ToInt32(delovi[3]);
            Opis = delovi[4];
            Izbrisan = Convert.ToBoolean(delovi[5]);
            KategorijaKomponente = delovi[6];
            RadniTakt = float.Parse(delovi[7]);
            BrojJezgara = Int32.Parse(delovi[8]);
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(" | Radni takt: {0} | Broj jezgara: {1}", RadniTakt, BrojJezgara);
        }

        public override string ToFileString()
        {
            return base.ToFileString() + String.Format(",{0},{1}", RadniTakt, BrojJezgara);
        }
    }
}
