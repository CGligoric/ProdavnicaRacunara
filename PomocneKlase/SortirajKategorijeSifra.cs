using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodavnica_racunara.Moduli;

namespace Prodavnica_racunara.PomocneKlase
{
    public class SortirajKategorijeSifra : IComparer<KategorijaKomponente>
    {
        public int Compare(KategorijaKomponente x, KategorijaKomponente y)
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
