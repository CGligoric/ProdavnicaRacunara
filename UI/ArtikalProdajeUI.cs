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
    class ArtikalProdajeUI
    {
        static List<ArtikalProdaje> sviArtikli = new List<ArtikalProdaje>();

        public static void IspisiMeniArtikla()
        {
            Console.WriteLine("Rad sa artiklima - opcije: ");
            Console.WriteLine("Opcija 1 - ispisi sve artikle");
            Console.WriteLine("Opcija 2 - ispisi sve artikle koji su dostupnu");
            Console.WriteLine("Opcija 3 - ispisi sve artikle koji su obrisani");
            Console.WriteLine("Opcija 4 - ispisi sve artikle po nekom opsegu cene");
            Console.WriteLine("Opcija 5 - ispisi sve artikle po nazivu rastuce");
            Console.WriteLine("Opcija 6 - ispisi sve artikle po nazivu opadajuce");
            Console.WriteLine("Opcija 7 - ispisi sve artikle po ceni rastuce");
            Console.WriteLine("Opcija 8 - ispisi sve artikle po ceni opadajuce");
            Console.WriteLine("Opcija 9 - obrisi artikal");
            Console.WriteLine("Opcija 10 - pronadji artikal");
        }

        public static ArtikalProdaje NapraviArtikal(string s1)
        {
            string[] tokeni = s1.Split(',');
            int i = s1.IndexOf(',') + 1;
            string s2 = s1.Substring(i);

            if (tokeni[0] == "Procesor")
            {
                return new ProcesorRacunara(s2);
            }
            else if (tokeni[0] == "Memorija")
            {
                return new MemorijaRacunara(s2);
            }
            else
            {
                return new ArtikalProdaje(s2);
            }
        }

        public static void UcitajArtikalIzDatoteke(string nazivDatoteke)
        {
            if (File.Exists(nazivDatoteke))
            {
                using (StreamReader r = File.OpenText(nazivDatoteke))
                {
                    string linija = "";
                    while ((linija = r.ReadLine()) != null )
                    {
                        string linija2 = linija.Substring(linija.IndexOf(',') + 1);
                        ArtikalProdaje ap = NapraviArtikal(linija);
                        sviArtikli.Add(ap);
                    }
                }
            }
            else
            {
                Console.WriteLine("Greska prilikom iscitavanja podataka o prodajnim artiklima");
            }
        }

        public static void ObrisiArtikal()
        {
            Console.WriteLine("Unesite koliko artikala zelite da obrisete: ");
            int broj = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < broj; i++)
            {
                Console.WriteLine($"Unesite sifru {i + 1}. artikla: ");
                int id = Convert.ToInt32(Console.ReadLine());

                for (int j = 0; j < sviArtikli.Count; j++)
                {
                    if (sviArtikli[j].Sifra == id && sviArtikli[j].Izbrisan == false)
                    {
                        sviArtikli[j].Izbrisan = true;
                    }
                }
            }

            Console.WriteLine("Uspesno ste obrisali " + broj + " artikla!");
        }

        public static void PronadjiArtikalPoSifri()
        {
            Console.WriteLine("Unesite sifru artikla: ");
            int id = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < sviArtikli.Count; i++)
            {
                if (sviArtikli[i].Sifra == id)
                {
                    Console.WriteLine(sviArtikli[i].ToString());
                }
            }
        }

        public static ArtikalProdaje PronadjiArtikalPoSifri(int id)
        {
            for (int i = 0; i < sviArtikli.Count; i++)
            {
                if (id== sviArtikli[i].Sifra)
                {
                    ArtikalProdaje ap = new ArtikalProdaje();
                    ap = sviArtikli[i];
                    return ap;
                }
            }
            return null;
        }

        public static void IspisiArtikle(int izbor)
        {
            // SVE
            if (izbor == 1)
            {
                for (int i = 0; i < sviArtikli.Count; i++)
                {
                    Console.WriteLine($"Artikal {i + 1}: " + "Sifra: " + sviArtikli[i].Sifra + " | Naziv: " + sviArtikli[i].Naziv +
                        " | Jedinicna cena: " + sviArtikli[i].Cena + " | Kolicina u magacinu: " + sviArtikli[i].Kolicina + "Opis: " + sviArtikli[i].Opis + "\n");
                }
            }

            // DOSTUPNI
            else if(izbor == 2)
            {
                for (int i = 0; i < sviArtikli.Count; i++)
                {
                    if (sviArtikli[i].Izbrisan == false)
                    {
                        Console.WriteLine($"Dostupni artikal {i + 1}: " + "Sifra: " + sviArtikli[i].Sifra + " | Naziv: " + sviArtikli[i].Naziv +
                        " | Jedinicna cena: " + sviArtikli[i].Cena + " | Kolicina u magacinu: " + sviArtikli[i].Kolicina + " Opis: " + sviArtikli[i].Opis + "\n");
                    }
                }
            }

            // OBRISANI
            else if(izbor == 3)
            {
                for (int i = 0; i < sviArtikli.Count; i++)
                {
                    if (sviArtikli[i].Izbrisan == true)
                    {
                        Console.WriteLine($"Nedostupni artikal {i + 1}: " + "Sifra: " + sviArtikli[i].Sifra + " | Naziv: " + sviArtikli[i].Naziv +
                        " | Jedinicna cena: " + sviArtikli[i].Cena + " | Kolicina u magacinu: " + 0 + "Opis: " + sviArtikli[i].Opis + "\n");
                    }
                }
            }

            // OPSEG CENE
            else if (izbor == 4)
            {
                Console.WriteLine("Izaberite opseg cene koja Vas interesuje \n Od: ");
                int c1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Do: ");
                int c2 = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < sviArtikli.Count; i++)
                {
                    if (sviArtikli[i].Cena >= c1 && sviArtikli[i].Cena <= c2)
                    {
                        Console.WriteLine($"Artikal {i + 1}: " + "Sifra: " + sviArtikli[i].Sifra + " | Naziv: " + sviArtikli[i].Naziv +
                        " | Jedinicna cena: " + sviArtikli[i].Cena + " | Kolicina u magacinu: " + sviArtikli[i].Kolicina + "Opis: " + sviArtikli[i].Opis + "\n");
                    }
                }
            }

            // NAZIV ASC
            else if (izbor == 5)
            {
                SortArtNazivASC sortiraj = new SortArtNazivASC();
                sviArtikli.Sort(sortiraj);

                for (int i = 0; i < sviArtikli.Count; i++)
                {
                    Console.WriteLine($"Artikal {i + 1}: " + "Sifra: " + sviArtikli[i].Sifra + " | Naziv: " + sviArtikli[i].Naziv +
                        " | Jedinicna cena: " + sviArtikli[i].Cena + " | Kolicina u magacinu: " + sviArtikli[i].Kolicina + "Opis: " + sviArtikli[i].Opis + "\n");
                }
            }

            // NAZIV DESC
            else if (izbor == 6)
            {
                SortArtNazivDESC sortiraj = new SortArtNazivDESC();
                sviArtikli.Sort(sortiraj);

                for (int i = 0; i < sviArtikli.Count; i++)
                {
                    Console.WriteLine($"Artikal {i + 1}: " + "Sifra: " + sviArtikli[i].Sifra + " | Naziv: " + sviArtikli[i].Naziv +
                        " | Jedinicna cena: " + sviArtikli[i].Cena + " | Kolicina u magacinu: " + sviArtikli[i].Kolicina + "Opis: " + sviArtikli[i].Opis + "\n");
                }
            }

            // CENA ASC
            else if (izbor == 8)
            {
                SortArtCenaASC sortiraj = new SortArtCenaASC();
                sviArtikli.Sort(sortiraj);

                for (int i = 0; i < sviArtikli.Count; i++)
                {
                    Console.WriteLine($"Artikal {i + 1}: " + "Sifra: " + sviArtikli[i].Sifra + " | Naziv: " + sviArtikli[i].Naziv +
                        " | Jedinicna cena: " + sviArtikli[i].Cena + " | Kolicina u magacinu: " + sviArtikli[i].Kolicina + "Opis: " + sviArtikli[i].Opis + "\n");
                }
            }

            // CENA DESC
            else if (izbor == 9)
            {
                SortArtCenaDESC sortiraj = new SortArtCenaDESC();
                sviArtikli.Sort(sortiraj);

                for (int i = 0; i < sviArtikli.Count; i++)
                {
                    Console.WriteLine($"Artikal {i + 1}: " + "Sifra: " + sviArtikli[i].Sifra + " | Naziv: " + sviArtikli[i].Naziv +
                        " | Jedinicna cena: " + sviArtikli[i].Cena + " | Kolicina u magacinu: " + sviArtikli[i].Kolicina + "Opis: " + sviArtikli[i].Opis + "\n");
                }
            }
        }

        public static void SacuvajArtikleUDatoteku(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                foreach (ArtikalProdaje ap in sviArtikli)
                {
                    writer.WriteLine(ap.ToFileString());
                }
            }
        }
    }
}
