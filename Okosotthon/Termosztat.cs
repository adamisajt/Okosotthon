using System;
using System.Globalization;

namespace Okosotthon
{
    public class Termosztat : OkosEszkoz, IIdozitheto, IStatisztika
    {
        private DateTime idozitoVege;

        public double JelenlegiHomerseklet { get; private set; }

        public double CelHomerseklet { get; private set; }

        public Termosztat(string azonosito, string nev, double celHomerseklet)
            : base(azonosito, nev)
        {
            this.JelenlegiHomerseklet = 21.0;
            this.CelHomerseklet = celHomerseklet;
            this.idozitoVege = DateTime.Now;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            string[] reszek = parancs.Split(':');

            if (reszek.Length == 2)
            {
                if (reszek[0] == "BEALLIT_HOMERSEKLET")
                {
                    this.CelHomerseklet = double.Parse(
                        reszek[1],
                        CultureInfo.InvariantCulture
                    );

                    this.UtolsoFrissites = DateTime.Now;
                }
            }
        }

        public override string AllapotJelentes()
        {
            return "Jelenlegi hőmérséklet: " + this.JelenlegiHomerseklet
                + " °C, célhőmérséklet: " + this.CelHomerseklet + " °C";
        }

        protected override bool OnTesztFuttatasa()
        {
            if (this.CelHomerseklet >= 5.0 && this.CelHomerseklet <= 35.0)
            {
                return true;
            }

            return false;
        }

        public void IdozitestBeallit(int perc)
        {
            if (perc < 0)
            {
                perc = 0;
            }

            this.idozitoVege = DateTime.Now.AddMinutes(perc);
        }

        public int GetMaradtIdo()
        {
            TimeSpan maradtIdo = this.idozitoVege - DateTime.Now;

            if (maradtIdo.TotalMinutes <= 0)
            {
                return 0;
            }

            return (int)Math.Ceiling(maradtIdo.TotalMinutes);
        }

        public string StatisztikatKeszit()
        {
            return this.Nev
                + " | Jelenlegi hőmérséklet: " + this.JelenlegiHomerseklet
                + " °C | Célhőmérséklet: " + this.CelHomerseklet
                + " °C | Hátralévő idő: " + this.GetMaradtIdo() + " perc";
        }
    }
}