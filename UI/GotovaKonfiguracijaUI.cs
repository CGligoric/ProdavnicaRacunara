using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodavnica_racunara.Moduli;
using Prodavnica_racunara.PomocneKlase;

namespace Prodavnica_racunara.UI
{
    class GotovaKonfiguracijaUI
    {
        static List<GotovaKonfiguracija> sveKonfiguracije = new List<GotovaKonfiguracija>();

        public static void IspisiMeniKonfiguracije()
        {
            Console.WriteLine("Rad sa gotovim konfiguracijama - opcije");
            Console.WriteLine("Opcija 1 - ispisi sve konfiguracije");
            Console.WriteLine("Opcija 2 - ispisi sve po nazivu");
            Console.WriteLine("Opcija 3 - ispisi sve konfiguracije koje spadaju u neki opseg cene");
            Console.WriteLine("Opcija 4 - ispisi sve konfiguracije po koicini u magacinu rastuce");
        }

        public static GotovaKonfiguracija NapraviKonfiguraciju(string s1)
        {
            string[] tokeni = s1.Split(',');
            int sifra = Convert.ToInt32(tokeni[1]);
            string naziv = tokeni[2];
            int cena = Convert.ToInt32(tokeni[3]);
            int kolicina = Convert.ToInt32(tokeni[4]);
            string opis = tokeni[5];
            bool izbrisan = Convert.ToBoolean(tokeni[6]);

            if (tokeni[0] == "Racunar")
            {
                return new GotovaKonfiguracija(sifra, naziv, cena, kolicina, opis);
            }
            else
            {
                return null;
            }
        }

        public static void UcitajKonfiguracijuIzDatoteke(string nazivDatoteke)
        {
            if (File.Exists(nazivDatoteke))
            {
                using (StreamReader r = File.OpenText(nazivDatoteke))
                {
                    string linija = "";
                    while ((linija = r.ReadLine()) != null)
                    {
                        string[] linija_niz = linija.Split(',');
                        if (linija_niz[0] == "Racunar")
                        {
                            string linija2 = linija.Substring(linija.IndexOf(',') + 1);
                            GotovaKonfiguracija gk = new GotovaKonfiguracija(linija2);
                            sveKonfiguracije.Add(gk);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Neispravna datoteka");
            }
        }

        public static void SacuvajKonfiguracijeUDatoteku(string nazivDatoteke)
        {
            if (File.Exists(nazivDatoteke))
            {
                using (StreamWriter w = new StreamWriter(nazivDatoteke, false, Encoding.UTF8))
                {
                    foreach (GotovaKonfiguracija gk in sveKonfiguracije)
                    {
                        w.WriteLine(gk.ToFileString());
                    }
                }
            }
        }

        public static void IspisiKonfiguracije(int izbor)
        {
            // SIFRA ASC
            if (izbor == 1)
            {
                SortirajKonfiguracijeSifra sortiraj = new SortirajKonfiguracijeSifra();
                sveKonfiguracije.Sort(sortiraj);
                for (int i = 0; i < sveKonfiguracije.Count; i++)
                {
                    Console.WriteLine(sveKonfiguracije[i].ToString());
                }
            }

            // NAZIV ADBC
            else if (izbor == 2)
            {
                sveKonfiguracije.Sort();
                for (int i = 0; i < sveKonfiguracije.Count; i++)
                {
                    Console.WriteLine(sveKonfiguracije[i].ToString());
                }
            }

            // OPSEG CENE
            else if (izbor == 3)
            {
                Console.WriteLine("Izaberite opseg cene koja Vas interesuje \n Od: ");
                int c1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Do: ");
                int c2 = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < sveKonfiguracije.Count; i++)
                {
                    if (sveKonfiguracije[i].Cena >= c1 && sveKonfiguracije[i].Cena <= c2)
                    {
                        Console.WriteLine(sveKonfiguracije[i].ToString());
                    }
                }
            }

            // KOLICINA ASC
            else if (izbor == 4)
            {
                SortirajKonfiguracijuKolicina sortiraj = new SortirajKonfiguracijuKolicina();
                sveKonfiguracije.Sort(sortiraj);

                for (int i = 0; i < sveKonfiguracije.Count; i++)
                {
                    Console.WriteLine(sveKonfiguracije[i].ToString());
                }
            }
        }
    }
}
