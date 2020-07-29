using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica_racunara.Moduli
{
    class Korisnik
    {
        public string UserName { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public enum Uloga { Menadzer, Prodavac };

        public Uloga TipUloge { get; set; }

        public Korisnik() { }

        public Korisnik(string userName, string lozinka, string ime, string prezime, Uloga tipUloge)
        {
            UserName = userName;
            Lozinka = lozinka;
            Ime = ime;
            Prezime = prezime;
            TipUloge = tipUloge;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", Ime, Prezime, UserName);
        }


    }
}
