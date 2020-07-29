using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodavnica_racunara.Moduli;

namespace Prodavnica_racunara.PomocneKlase
{
    class SortirajKomponenteNaziv : IComparer<KomponentaRacunara>
    {
        public int Compare(KomponentaRacunara x, KomponentaRacunara y)
        {
            if (x.Naziv == null || y.Naziv == null)
            {
                return 0;
            }
            else
            {
                return x.Naziv.CompareTo(y.Naziv);
            }
        }
    }
}
