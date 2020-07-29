using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodavnica_racunara.Moduli;
using Prodavnica_racunara.PomocneKlase;

namespace Prodavnica_racunara.UI
{
    class PregledUI
    {
        public static void Meni()
        {

            int izborEntiteta = Meniji.OdabirEntiteta();
            Console.Clear();

            // ISPIS KATEGORIJA
            if (izborEntiteta == 1)
            {
                int izborOpcije = Meniji.IspisiMeni(KategorijaKomponenteUI.IspisiMeniKategorije, 6);
                switch (izborOpcije)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        Console.Clear();
                        KategorijaKomponenteUI.IspisiKategorije(izborOpcije);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 6:
                        Console.Clear();
                        Meniji.OdabirEntiteta();
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
            }
            
            // ISPIS ARTIKALA
            else if (izborEntiteta == 2)
            {
                int izborOpcije = Meniji.IspisiMeni(ArtikalProdajeUI.IspisiMeniArtikla, 10);
                switch (izborOpcije)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                        Console.Clear();
                        ArtikalProdajeUI.IspisiArtikle(izborOpcije);
                        Console.ReadLine();
                        break;
                    case 9:
                        Console.Clear();
                        ArtikalProdajeUI.ObrisiArtikal();
                        Console.ReadLine();
                        break;
                    case 10:
                        Console.Clear();
                        ArtikalProdajeUI.PronadjiArtikalPoSifri();
                        Console.ReadLine();
                        break;
                    case 11:
                        Console.Clear();
                        Meniji.OdabirEntiteta();
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
            }

            // ISPIS KONFIGURACIJA
            else if (izborEntiteta == 3)
            {
                int izborOpcije = Meniji.IspisiMeni(GotovaKonfiguracijaUI.IspisiMeniKonfiguracije, 5);
                switch (izborOpcije)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        Console.Clear();
                        GotovaKonfiguracijaUI.IspisiKonfiguracije(izborOpcije);
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Clear();
                        Meniji.OdabirEntiteta();
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
            }

            // ISPIS KOMPONENATA
            else if (izborEntiteta == 4)
            {
                int izborOpcije = Meniji.IspisiMeni(KomponentaRacunaraUI.IspisiMeniKomponenti, 5);
                switch (izborOpcije)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        Console.Clear();
                        KomponentaRacunaraUI.IspisiKomponente(izborOpcije);
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Clear();
                        Meniji.OdabirEntiteta();
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Nevazeca komanda!");
                        Console.ReadLine();
                        break;
                }
            }

            // ISPIS RACUNA MENADZER
            else if (izborEntiteta == 5)
            {
                if (PrijavaUI.ulogovanKorisnik is Menadzer)
                {
                    int izborOpcije = Meniji.IspisiMeni(RacunUI.MeniRacunaMenadzer, 4);
                    RacunUI.IspisiMeniRacunaMenadzer(izborOpcije);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Ova opcija je dostupna samo menadzerima.");
                }
            }

            // ISPIS RACUNA PRODAVAC
            else if (izborEntiteta == 6)
            {
                RacunUI.IzdajRacun();
                Console.ReadLine();
            }
        }
    }
}
