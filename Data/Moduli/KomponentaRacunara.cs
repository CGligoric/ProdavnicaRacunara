using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica_racunara.Moduli
{
    class KomponentaRacunara : ArtikalProdaje,IComparable<KomponentaRacunara>
    {
        public string KategorijaKomponente { get; set; }
        
        public KomponentaRacunara()
        {

        }

        public KomponentaRacunara(int sifra, string naziv, int cena, int kolicina, string opis, 
            string kategorijaKomponente) : base(sifra, naziv, cena, kolicina, opis)
        {
            KategorijaKomponente = kategorijaKomponente;
        }

        public KomponentaRacunara(string s)
        {
            string[] delovi = s.Split(',');
            Sifra = Convert.ToInt32(delovi[1]);
            Naziv = delovi[2];
            Cena = Int32.Parse(delovi[3]);
            Kolicina = Int32.Parse(delovi[4]);
            Opis = delovi[5];
            Izbrisan = Convert.ToBoolean(delovi[6]);
            KategorijaKomponente = delovi[7];
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(" | Komponenta spada u kategoriju: {0}", KategorijaKomponente);
        }

        public override string ToFileString()
        {
            return base.ToFileString() + String.Format("{0}", KategorijaKomponente);
        }

        public int CompareTo(KomponentaRacunara other)
        {
            return this.Naziv.CompareTo(other.Naziv);
        }
    }
}
