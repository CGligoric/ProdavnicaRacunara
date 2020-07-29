using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodavnica_racunara.Moduli;

namespace Prodavnica_racunara.PomocneKlase
{
    class SortirajKomponenteSifra : IComparer<KomponentaRacunara>
    {
        public int Compare(KomponentaRacunara x, KomponentaRacunara y)
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
