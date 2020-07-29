using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodavnica_racunara.Moduli;
using Prodavnica_racunara.PomocneKlase;
using System.IO;

namespace Prodavnica_racunara.UI
{
    static class KategorijaKomponenteUI
    {
        static List<KategorijaKomponente> sveKategorije = new List<KategorijaKomponente>();

        public static void IspisiMeniKategorije()
        {
            Console.WriteLine("Rad sa kategorijama komponenti - opcije\n");
            Console.WriteLine("Opcija 1 - ispisivanje svih kategorija komponenti");
            Console.WriteLine("Opcija 2 - ispisivanje svih dostupnih kategorija");
            Console.WriteLine("Opcija 3 - ispisivanje svih obrisanih kategorija");
            Console.WriteLine("Opcija 4 - ispisivanje po sifri kategorije (rastuce)");
            Console.WriteLine("Opcija 5 - ispisivanje po nazivu");
        }

        public static void IspisiKategorije(int izabranaOpcija)
        {
            // SVE
            if (izabranaOpcija == 1)
            {
                for (int i = 0; i < sveKategorije.Count; i++)
                {
                    Console.WriteLine(sveKategorije[i].ToString());
                }
            }

            // DOSTUPNE
            else if (izabranaOpcija == 2)
            {
                for (int i = 0; i < sveKategorije.Count; i++)
                {
                    if (sveKategorije[i].Izbrisana == false)
                    {
                        Console.WriteLine(sveKategorije[i].ToString());
                    }
                }
            }

            // OBRISANE
            else if (izabranaOpcija == 3)
            {
                for (int i = 0; i < sveKategorije.Count; i++)
                {
                    if (sveKategorije[i].Izbrisana == true)
                    {
                        Console.WriteLine(sveKategorije[i].ToString());
                    }
                }
            }

            // PO SIFRI ASC
            else if (izabranaOpcija == 4)
            {
                SortirajKategorijeSifra sortiraj = new SortirajKategorijeSifra();
                sveKategorije.Sort(sortiraj);

                for (int i = 0; i < sveKategorije.Count; i++)
                {
                    Console.WriteLine(sveKategorije[i].ToString());
                }
            }

            // PO NAZIVU ABCD
            else if (izabranaOpcija == 5)
            {
                sveKategorije.Sort();
                for (int i = 0; i < sveKategorije.Count; i++)
                {
                    Console.WriteLine(sveKategorije[i].ToString());
                }
            }
        }

        public static KategorijaKomponente NapraviKategoriju(string s)
        {
            string[] tokeni = s.Split(',');
            int sifra = Convert.ToInt32(tokeni[0]);
            string naziv = tokeni[1];
            string opis = tokeni[2];

            return new KategorijaKomponente(sifra, naziv, opis);
        }

        public static void ObrisiKategoriju()
        {
            Console.WriteLine("Upisite sifru kategorije koju zelite da izbrisete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < sveKategorije.Count; i++)
            {
                if (sveKategorije[i].Sifra == id && sveKategorije[i].Izbrisana == false)
                {
                    sveKategorije[i].Izbrisana = true;
                    return;
                }
            }
            Console.WriteLine("Nije pronadjena nijedna kategorija sa tom sifrom");
        }

        public static void UcitajKategorijeIzDatoteke(string nazivDatoteke)
        {
            if (File.Exists(nazivDatoteke))
            {
                using (StreamReader r = File.OpenText(nazivDatoteke))
                {
                    string linija = "";
                    while ((linija = r.ReadLine()) != null)
                    {
                        KategorijaKomponente kk = NapraviKategoriju(linija);
                        sveKategorije.Add(kk);
                    }
                }
            }
            else
            {
                Console.WriteLine("Greska prilikom iscitavanja podataka o kategorijama komponenata");
            }
        }

        public static void SacuvajKategorijeUDatoteku(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                foreach (KategorijaKomponente kk in sveKategorije)
                {
                    writer.WriteLine(kk.ToFileString());
                }
            }
        }
    }
}
