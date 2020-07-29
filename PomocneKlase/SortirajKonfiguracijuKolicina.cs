using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodavnica_racunara.Moduli;

namespace Prodavnica_racunara.PomocneKlase
{
    class SortirajKonfiguracijuKolicina : IComparer<GotovaKonfiguracija>
    {
        public int Compare(GotovaKonfiguracija x, GotovaKonfiguracija y)
        {
            if (x.Kolicina > y.Kolicina)
            {
                return 1;
            }
            else if (x.Kolicina < y.Kolicina)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
