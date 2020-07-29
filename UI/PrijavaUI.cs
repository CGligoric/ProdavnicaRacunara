using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodavnica_racunara.Moduli;

namespace Prodavnica_racunara.UI
{
    class PrijavaUI
    {
        static Dictionary<string, Korisnik> sviKorisnici = new Dictionary<string, Korisnik>();

        public static Korisnik ulogovanKorisnik = null;

        public static Korisnik NapraviKorisnika(string s)
        {
            if (s.Contains("Prodavac"))
            {
                return new Prodavac(s);
            }
            else
            {
                return new Menadzer(s);
            }
        }

        public static void UcitajKorisnikaIzDatoteke(string nazivDatoteke)
        {
            if (File.Exists(nazivDatoteke))
            {
                using (StreamReader r = File.OpenText(nazivDatoteke))
                {
                    string linija = "";
                    while ((linija = r.ReadLine()) != null)
                    {
                        Korisnik k = NapraviKorisnika(linija);
                        sviKorisnici.Add(k.UserName, k);
                    }
                }
            }
        }

        public static Prodavac PronadjiProdavcaPoKorisnickomImenu(string kime)
        {
            if (sviKorisnici.ContainsKey(kime))
            {
                Korisnik k = sviKorisnici[kime];
                if (k is Prodavac)
                {
                    return (Prodavac)k;
                }
            }
            return null;
        }

        public static bool PrijavaKorisnika()
        {
            string user;
            string lozinka;
            bool nastavak = true;
            do
            {
                Console.WriteLine("Upisite korisnicko ime: ");
                user = Console.ReadLine();
                Console.WriteLine("Dobar dan, korisnice " + user + " ! Upisite svoju lozinku:");
                lozinka = Console.ReadLine();

                if (ProveriPrijavu(user, lozinka))
                {
                    nastavak = false;
                }
                else
                {
                    Console.WriteLine("Uneti podaci su neispravni, probajte ponovo");
                }
            } while (nastavak);

            ulogovanKorisnik = sviKorisnici[user];
            return true;
        }

        public static bool ProveriPrijavu(string kime, string pass)
        {
            bool retVal = true;
            if (sviKorisnici.ContainsKey(kime))
            {
                Korisnik korisnik = sviKorisnici[kime];
                string tacnaLozinka = korisnik.Lozinka;
                if (tacnaLozinka == pass)
                {
                    retVal = true;
                }
                else
                {
                    retVal = false;
                }
            }
            else
            {
                retVal = false;
            }
            return retVal;
        }

        public static void OdjavaKorisnika()
        {
            ulogovanKorisnik = null;
        }
    }
}
