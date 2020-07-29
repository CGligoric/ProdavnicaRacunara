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
    class KomponentaRacunaraUI
    {
        static List<KomponentaRacunara> sveKomponente = new List<KomponentaRacunara>();

        public static void IspisiMeniKomponenti()
        {
            Console.WriteLine("Rad sa komponentama - opcije: ");
            Console.WriteLine("Opcija 1 - ispisi sve komponente");
            Console.WriteLine("Opcija 2 - ispisi sve komponente po nazivu rastuce");
            Console.WriteLine("Opcija 3 - ispisi sve komponente po nekom opsegu cene");
            Console.WriteLine("Opcija 4 - ispisi sve po opsegu kolicine");
            Console.WriteLine("Opcija 5 - ispisi sve po nazivu kategorije rastuce");
        }

        public static KomponentaRacunara NapraviKomponentu(string s1)
        {
            string[] delovi = s1.Split(',');
            int i = s1.IndexOf(',') + 1;
            string s2 = s1.Substring(i);

            if (delovi[0] == "Procesor")
            {
                return new ProcesorRacunara(s2);
            }
            else if(delovi[0] == "Memorija")
            {
                return new ProcesorRacunara(s2);
            }
            else
            {
                return null;
            }
        }

        public static void UcitajKomponentuIzDatoteke(string nazivDatoteke)
        {
            if (File.Exists(nazivDatoteke))
            {
                using (StreamReader r = File.OpenText(nazivDatoteke))
                {
                    string linija = "";
                    while ((linija = r.ReadLine()) != null)
                    {
                        if (linija.Contains("Racunar") == false)
                        {
                            string linija2 = linija.Substring(linija.IndexOf(',') + 1);
                            KomponentaRacunara kp = new KomponentaRacunara(linija);
                            sveKomponente.Add(kp);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Neispravna datoteka");
            }
        }

        public static void IspisiKomponente(int izbor)
        {
            // SIFRA ASC
            if (izbor == 1)
            {
                SortirajKomponenteSifra sortiraj = new SortirajKomponenteSifra();
                sveKomponente.Sort(sortiraj);

                for (int i = 0; i < sveKomponente.Count; i++)
                {
                    Console.WriteLine(sveKomponente[i].ToString());
                }
            }

            // NAZIV ABDC
            else if (izbor == 2)
            {
                sveKomponente.Sort();

                for (int i = 0; i < sveKomponente.Count; i++)
                {
                    Console.WriteLine(sveKomponente[i].ToString());
                }
            }

            // OPSEG CENE
            else if (izbor == 3)
            {
                Console.WriteLine("Izaberite opseg cene koja Vas interesuje \n Od: ");
                int c1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Do: ");
                int c2 = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < sveKomponente.Count; i++)
                {
                    if (sveKomponente[i].Cena >= c1 && sveKomponente[i].Cena <= c2)
                    {
                        Console.WriteLine(sveKomponente[i].ToString());
                    }
                }
            }

            // OPSEG KOLICNE
            else if (izbor == 4)
            {
                Console.WriteLine("Izaberite opseg kolicine koja Vas interesuje \n Od: ");
                int k1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Do: ");
                int k2 = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < sveKomponente.Count; i++)
                {
                    if (sveKomponente[i].Kolicina >= k1 && sveKomponente[i].Kolicina <= k2)
                    {
                        Console.WriteLine(sveKomponente[i].ToString());
                    }
                }
            }

            else if (izbor == 5)
            {
                SortirajKomponenteNaziv sortiraj = new SortirajKomponenteNaziv();
                sveKomponente.Sort(sortiraj);

                for (int i = 0; i < sveKomponente.Count; i++)
                {
                    Console.WriteLine(sveKomponente[i].ToString());
                }
            }
        }
    }
}
