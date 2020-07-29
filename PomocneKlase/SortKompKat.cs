using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodavnica_racunara.Moduli;

namespace Prodavnica_racunara.PomocneKlase
{
    class SortKompKat : IComparer<KomponentaRacunara>
    {
        public int Compare(KomponentaRacunara x, KomponentaRacunara y)
        {
            if (x == null || y == null)
            {
                return 0;
            }
            else
            {
                return x.KategorijaKomponente.CompareTo(y.KategorijaKomponente);
            }
        }
    }
}
