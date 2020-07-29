using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodavnica_racunara.Moduli;
using Prodavnica_racunara.PomocneKlase;

namespace Prodavnica_racunara.UI
{
    class RacunUI
    {
        static List<RacunProdaje> sviRacuni = new List<RacunProdaje>();

        public static void MeniRacunaMenadzer()
        {
            Console.WriteLine("Rad sa racunima - opcije:");
            Console.WriteLine("Opcija 1 - pregled svih racuna (bez podataka o stavkama racuna)");
            Console.WriteLine("Opcija 2 - pregled svih racuna odredjenog datuma (bez podataka o stavkama racuna");
            Console.WriteLine("Opcija 3 - pregled kompletnih informacija odredjenog racuna (ukljucujuci i podatke o stavkama");
            Console.WriteLine("Opcija 4 - ispis izvestaja o ukupnoj prodaji po datumima (tabela)");
        }

        public static void IspisiSveRacune()
        {
            for (int i = 0; i < sviRacuni.Count; i++)
            {
                Console.WriteLine(sviRacuni[i].ToString());
            }
        }

        public static void IspisiRacunZaDatum()
        {
            Console.WriteLine("Upisite datum (u formatu mm/dd/gggg): ");
            string datumVreme = Console.ReadLine();

            while (true)
            {
                if (datumVreme.Contains('/') == false)
                {
                    Console.WriteLine("Neispravan format datuma!");
                    break;
                }
                else
                {
                    List<string> niz_datuma = new List<string>();
                    for (int i = 0; i < sviRacuni.Count; i++)
                    {
                        if (sviRacuni[i].DatumVreme.ToShortDateString() == datumVreme)
                        {
                            Console.WriteLine(sviRacuni[i].ToString());
                        }
                    }
                    return;
                }
            }
        }

        public static void IspisiSveRacuneSve()
        {
            for (int i = 0; i < sviRacuni.Count; i++)
            {
                Console.WriteLine(sviRacuni[i].DetaljanIspis());
            }
        }

        public static void IspisiTabeluProdaje()
        {
            List<string> listaDatuma = new List<string>();  // Lista u kojoj se nalaze jedinstveni datumi
            Console.Clear();


            // Petlja za ubacivanje datuma u listu 
            for (int i = 0; i < sviRacuni.Count; i++)
            {
                if (listaDatuma.Contains(Convert.ToString(sviRacuni[i].DatumVreme.Date)))
                {
                    continue;
                }
                else
                {
                    listaDatuma.Add(Convert.ToString(sviRacuni[i].DatumVreme.Date));
                }
            }

            Console.WriteLine("\n");

            // Ispisivanje tabele

            Console.WriteLine("--------------------------------");
            Console.WriteLine("|    Datum    | Ukupan prihod |");
            Console.WriteLine("--------------------------------");

            List<int> ukCenaZaDatum = new List<int>();
            for (int i = 0; i < listaDatuma.Count; i++)
            {
                ukCenaZaDatum.Add(0);
            }

            for (int i = 0; i < listaDatuma.Count; i++)
            {
                for (int j = 0; j < sviRacuni.Count; j++)
                {
                    if (sviRacuni[j].DatumVreme.Date.ToString().Contains(listaDatuma[i]))
                    {
                        ukCenaZaDatum[i] += sviRacuni[j].UkupnaCena;
                    }
                }
                string datum = listaDatuma[i].Substring(0, 10); 
                Console.WriteLine("|  " + datum + " |      " + ukCenaZaDatum[i] + "$    |");
            }
            Console.WriteLine("---------------------------------");
        }


        public static void IspisiMeniRacunaMenadzer(int izbor)
        {
            if (PrijavaUI.ulogovanKorisnik is Menadzer)
            {
                Console.Clear();
                if (izbor == 1)
                {
                    IspisiSveRacune();
                }
                else if (izbor == 2)
                {
                    IspisiRacunZaDatum();
                }
                else if (izbor == 3)
                {
                    IspisiSveRacuneSve();
                }
                else if (izbor == 4)
                {
                    IspisiTabeluProdaje();
                }
            }
            else
            {
                Console.WriteLine("Uvid u podatke o racunima je dostupan sam korisnicima tipa Menadzer!");
            }
        }

        public static void IzdajRacun()
        {
            if (PrijavaUI.ulogovanKorisnik is Prodavac)
            {
                Console.Clear();

                RacunProdaje rp = new RacunProdaje();

                Console.WriteLine("Unesite koliko zelite da Vas racun sadrzi stavki: ");
                int brojStavki = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < brojStavki; i++)
                {
                    Console.WriteLine("Unesite sifru novog artikla: ");

                    int sifra = Convert.ToInt32(Console.ReadLine());
                    ArtikalProdaje ap = ArtikalProdajeUI.PronadjiArtikalPoSifri(sifra);

                    if (ap != null)
                    {
                        Console.WriteLine("Unesite broj ovih artikla koji je kupac porucio");
                        int brojArtikala = Convert.ToInt32(Console.ReadLine());

                        StavkaRacuna sr = new StavkaRacuna(i, ap, ap.Cena, brojArtikala);

                        rp.Stavke = new List<StavkaRacuna>();
                        rp.Stavke.Add(sr);
                        rp.UkupnaCena += sr.JedinicaCena * brojArtikala;
                    }
                    else
                    {
                        Console.WriteLine("Nije pronadjen nijedan artikal sa unetom sifrom.");
                    }
                }
                sviRacuni.Add(rp);
                Console.WriteLine("Nov racun je pridodat bazi podaka. On izgleda ovako:\n");

                IspisiRacun(rp, brojStavki);
            }

            else
            {
                Console.WriteLine("Samo prodavci mogu da pristupe ovoj opciji!");
            }
        }

        public static void IspisiRacun(RacunProdaje rp, int brStavki)
        {
            rp.Sifra = sviRacuni.Count + 1;
            Prodavac pr = new Prodavac(PrijavaUI.ulogovanKorisnik.UserName, PrijavaUI.ulogovanKorisnik.Lozinka,
                PrijavaUI.ulogovanKorisnik.Ime, PrijavaUI.ulogovanKorisnik.Prezime);
            rp.Prodavac = pr;
            rp.DatumVreme = DateTime.Now;
            rp.BrojStavki = brStavki;

            Console.WriteLine(rp.ToString());
            Console.ReadLine();
        }

        public static void UcitajRacune(string nazidDatoteke)
        {
            if (File.Exists(nazidDatoteke))
            {
                using (StreamReader reader1 = File.OpenText(nazidDatoteke))
                {
                    string linija;
                    while ((linija = reader1.ReadLine()) != null)
                    {
                        RacunProdaje rp = new RacunProdaje(linija);
                        sviRacuni.Add(rp);
                    }
                }
            }
            else
            {
                Console.WriteLine("Datoteka {0} ne postoji ili putanja nije ispravna.", nazidDatoteke);
            }
        }

        public static void SacuvajRacuneUDatoteke(string nazviDatoteke)
        {
            if (File.Exists(nazviDatoteke))
            {
                using (StreamWriter w = new StreamWriter(nazviDatoteke, false, Encoding.UTF8))
                {
                    foreach (RacunProdaje racun in sviRacuni)
                    {
                        w.WriteLine(racun.ToFileString());
                    }
                }
            }
        }
    }
}
