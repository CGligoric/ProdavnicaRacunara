using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodavnica_racunara.Moduli;
using Prodavnica_racunara.PomocneKlase;
using Prodavnica_racunara.UI;
using Prodavnica_racunara.Data;

namespace Prodavnica_racunara
{
    class Program
    {
        public static void UcitajPodatke()
        {
            Datoteke.PodesiPutanju();

            PrijavaUI.UcitajKorisnikaIzDatoteke(Datoteke.KorisnikFullPath);
            KategorijaKomponenteUI.UcitajKategorijeIzDatoteke(Datoteke.KategorijeFullPath);
            ArtikalProdajeUI.UcitajArtikalIzDatoteke(Datoteke.ArtikalFullPath);
            RacunUI.UcitajRacune(Datoteke.RacunFullPath);
            KomponentaRacunaraUI.UcitajKomponentuIzDatoteke(Datoteke.ArtikalFullPath);
            GotovaKonfiguracijaUI.UcitajKonfiguracijuIzDatoteke(Datoteke.ArtikalFullPath);
        }

        public static void SacuvajPodatke()
        {
            KategorijaKomponenteUI.SacuvajKategorijeUDatoteku(Datoteke.KategorijeFullPath);
            ArtikalProdajeUI.SacuvajArtikleUDatoteku(Datoteke.ArtikalFullPath);
            RacunUI.SacuvajRacuneUDatoteke(Datoteke.RacunFullPath);
            GotovaKonfiguracijaUI.SacuvajKonfiguracijeUDatoteku(Datoteke.ArtikalFullPath);
        }

        public static void OsnovniMeniIspis()
        {
            Console.WriteLine("Opcije:");
            Console.WriteLine("1 - Prijava na sistem");
            Console.WriteLine("2 - Izlaz iz aplikacije i cuvanje izmena u fajl");
        }

        static void Main(string[] args)
        {
            UcitajPodatke();

            int opcija = Meniji.IspisiMeni(OsnovniMeniIspis, 2);

            if (opcija == 1)
            {
                PrijavaUI.PrijavaKorisnika();
                bool nastavak = false;
                do
                {
                    PregledUI.Meni();
                    Console.WriteLine("\nDa li zelite da nastavite s radom nad bazom podataka prodavnice racunara? y/n");
                    string yn = Console.ReadLine();
                    if (yn == "y")
                    {
                        nastavak = true;
                    }
                    else
                    {
                        nastavak = false;
                    }
                } while (nastavak);
            }
            else
            {
                PrijavaUI.OdjavaKorisnika();
                SacuvajPodatke();
            }
        }
    }
}
