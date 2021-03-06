﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica_racunara.Moduli
{
    class Prodavac : Korisnik
    {
        public Prodavac(string userName, string lozinka, string ime, string prezime) : base(userName, lozinka, ime, prezime, Uloga.Prodavac)
        {

        }

        public Prodavac(string s)
        {
            string[] delovi = s.Split(',');
            UserName = delovi[0];
            Lozinka = delovi[1];
            Ime = delovi[2];
            Prezime = delovi[3];
            TipUloge = Uloga.Prodavac;
        }
    }
}
