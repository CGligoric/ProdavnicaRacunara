using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodavnica_racunara.Moduli;

namespace Prodavnica_racunara.PomocneKlase
{
    class SortArtCenaDESC : IComparer<ArtikalProdaje>
    {
        public int Compare(ArtikalProdaje x, ArtikalProdaje y)
        {
            if (x.Cena > y.Cena)
            {
                return -1;
            }
            else if (x.Cena < y.Cena)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static implicit operator SortArtCenaDESC(SortArtCenaASC v)
        {
            throw new NotImplementedException();
        }
    }
}
