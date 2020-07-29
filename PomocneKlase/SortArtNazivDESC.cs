using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodavnica_racunara.Moduli;

namespace Prodavnica_racunara.PomocneKlase
{
    class SortArtNazivDESC : IComparer<ArtikalProdaje>
    {
        public int Compare(ArtikalProdaje x, ArtikalProdaje y)
        {
            if (x == null || y == null)
            {
                return 0;
            }
            else
            {
                return -x.Naziv.CompareTo(y.Naziv);
            }
        }
    }
}
