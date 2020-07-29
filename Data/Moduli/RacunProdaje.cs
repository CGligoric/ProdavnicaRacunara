using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodavnica_racunara.UI;

namespace Prodavnica_racunara.Moduli
{
    class RacunProdaje
    {
        public int Sifra { get; set; }
        public Prodavac Prodavac { get; set; }
        public DateTime DatumVreme { get; set; }
        public int UkupnaCena { get; set; }
        public List<StavkaRacuna> Stavke { get; set; }
        public int BrojStavki { get; set; }

        public RacunProdaje() { }

        public RacunProdaje(int sifra, Prodavac prodavac, DateTime datum)
        {
            Sifra = sifra;
            Prodavac = prodavac;
            DatumVreme = datum;
            UkupnaCena = 0;
            Stavke = new List<StavkaRacuna>();
            BrojStavki = 0;
        }

        public RacunProdaje(string s)
        {
            string[] tokeni = s.Split(',');
            Stavke = new List<StavkaRacuna>();

            Sifra = Convert.ToInt32(tokeni[0]);
            Prodavac = PrijavaUI.PronadjiProdavcaPoKorisnickomImenu(tokeni[1]);
            DatumVreme = DateTime.Parse(tokeni[2]);
            BrojStavki = (tokeni.Length - 3) / 2;

            for (int i = 0; i < BrojStavki; i++)
            {
                int sifra = 0;
                int kolicina = 0;

                if (i % 2 == 0)
                {
                    if (i == 0)
                    {
                        sifra = int.Parse(tokeni[4 + i - 1]);
                        kolicina = int.Parse(tokeni[4 + i]);
                    }
                    else
                    {
                        sifra = int.Parse(tokeni[(i*i) + 4- 1]);
                        kolicina = int.Parse(tokeni[(i*i) + 4]);
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        sifra = int.Parse(tokeni[4 + i]);
                        kolicina = int.Parse(tokeni[4 + i + 1]);
                    }
                    else
                    {
                        sifra = int.Parse(tokeni[i * 4 + i]);
                        kolicina = int.Parse(tokeni[i * 4 + i + 1]);
                    }
                }

                ArtikalProdaje ap = ArtikalProdajeUI.PronadjiArtikalPoSifri(sifra);

                Stavke.Add(new StavkaRacuna(sifra, ap, ap.Cena, kolicina));
                UkupnaCena += ap.Cena * kolicina;

            }
        }

        public string DetaljanIspis()
        {
            string zaglavlje = ToString() + "\n";
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < BrojStavki; i++)
            {
                if (i == 0)
                {
                    sb.Append(zaglavlje + Stavke[i].ToString() + "\n");
                    Stavke[i].RedniBr++;
                }
                else
                {
                    sb.Append(Stavke[i].ToString() + "\n");
                    Stavke[i].RedniBr++;
                }
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return String.Format("Sifra: {0} | Ime i prezime prodavca: {1} {2} | Datum i vreme transakcije: {3} " +
                "| Ukupna cena: {4}$ | Broj stavki na racunu: {5}", Sifra, Prodavac.Ime, Prodavac.Prezime, DatumVreme, UkupnaCena, BrojStavki);
        }

        public string IspisiSvePodatkeRacuna()
        {
            string str = "";
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < BrojStavki; i++)
            {
                sb.AppendLine(Stavke[i].ToString());
            }
            return sb.ToString();
        }

        public string ToFileString()
        {
            string prviDeo = string.Format("{0},{1}", Prodavac.UserName, DatumVreme.ToShortDateString());
            string drugiDeo = "";

            foreach (StavkaRacuna s in Stavke)
            {
                drugiDeo += string.Format(",{0}", s.ArtikalProdaje.Sifra);
            }
            return prviDeo + drugiDeo;
        }
    }
}
