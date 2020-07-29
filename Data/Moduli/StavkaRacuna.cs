using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica_racunara.Moduli
{
    class StavkaRacuna
    {
        public int RedniBr { get; set; }
        public ArtikalProdaje ArtikalProdaje { get; set; }
        public int JedinicaCena { get; set; }
        public int Kolicina { get; set; }

        public StavkaRacuna() { }

        public StavkaRacuna(int redniBr, ArtikalProdaje artikal, int jedinicnaCena, int kolicina)
        {
            RedniBr = redniBr;
            ArtikalProdaje = artikal;
            JedinicaCena = jedinicnaCena;
            Kolicina = kolicina;
        }

        public override string ToString()
        {
            return String.Format("Stavka br: {0} | Naziv: {1} | Cena: {2} | Kolicina: {3}", RedniBr, ArtikalProdaje.Naziv, JedinicaCena, Kolicina);
        }

        public string ToFileString()
        {
            return String.Format("{0},{1},{2},{3}", RedniBr, ArtikalProdaje.Naziv, JedinicaCena, Kolicina);
        }
    }
}
