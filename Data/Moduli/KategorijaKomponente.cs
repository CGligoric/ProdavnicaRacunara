using System;

namespace Prodavnica_racunara.Moduli
{
    public class KategorijaKomponente : IComparable<KategorijaKomponente>
    {
        private readonly int brojac = 0;

        public int Sifra { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public KategorijaKomponente Nadkategorija { get; set; }
        public bool Izbrisana { get; set; }

        public KategorijaKomponente()
        {

        }

        public KategorijaKomponente(int sifra, string naziv, string opis, KategorijaKomponente nadkategorija, bool izbrisana = false)
        {
            Sifra = sifra;
            Naziv = naziv;
            Opis = opis;
            Nadkategorija = nadkategorija;
            Izbrisana = izbrisana;
        }

        public KategorijaKomponente(int sifra, string naziv, string opis, bool izbrisana = false)  // Konstruktor kategorije koja ne sadrzi nadklasu
        {
            Sifra = sifra;
            Naziv = naziv;
            Opis = opis;
            Izbrisana = izbrisana;
        }

        public override string ToString()
        {
            return String.Format("Sifra kategorije: {0} | Naziv: {1} | Opis: {2}", Sifra, Naziv, Opis);
        }

        public virtual string ToFileString()
        {
            if (Nadkategorija != null)
            {
                return String.Format("{0},{1},{2},{3}", Sifra, Naziv, Nadkategorija.Nadkategorija, Opis);
            }
            return String.Format("{0},{1},{2},{3}", Sifra, Naziv, "Bez nadkategorije", Opis);

        }

        public int CompareTo(KategorijaKomponente kk)
        {
            return this.Naziv.CompareTo(kk.Naziv);
        }
    }
}
