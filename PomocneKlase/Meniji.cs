using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica_racunara.PomocneKlase
{
    public static class Meniji
    {
        public delegate void MeniZaIspis();

        public static void IspisiMeniEntiteta()
        {
            Console.Clear();
            Console.WriteLine("S kojim entitetom zelite da radite?\n" +
                "Opcija br 1 - rad sa kategorijama artikala\n" +
                "Opcija br 2 - rad sa artiklima\n" +
                "Opcija br 3 - rad sa gotovim konfiguracijama\n" +
                "Opcija br 4 - rad sa racunarskim komponentama\n" +
                "Opcija br 5 - upit u podakte o racunima (menadzer)\n" +
                "Opcija b4 6 - izdavanje novog racuna (prodavac)\n");
        }

        public static int OdabirEntiteta()
        {
            int opcija = IspisiMeni(IspisiMeniEntiteta, 6);
            return opcija;
        }

        public static int IspisiMeni(MeniZaIspis meni, int brojOpcija)
        {
            while (true)
            {
                meni();

                Console.WriteLine("Izaberite opcije od: 1 - " + brojOpcija + ": ");
                int opcija = Convert.ToInt32(Console.ReadLine());
                if (opcija >= 1 && opcija <= brojOpcija)
                {
                    return opcija;
                }
                else
                {
                    Console.WriteLine("Izabrali ste nepostojecu opciju...");
                }
            }
        }
    }
}
