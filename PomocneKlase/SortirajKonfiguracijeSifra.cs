using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodavnica_racunara.Moduli;

namespace Prodavnica_racunara.PomocneKlase
{
    class SortirajKonfiguracijeSifra : IComparer<GotovaKonfiguracija>
    {
        public int Compare(GotovaKonfiguracija x, GotovaKonfiguracija y)
        {
            if (x.Sifra > y.Sifra)
            {
                return 1;
            }
            else if (x.Sifra < y.Sifra)
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
