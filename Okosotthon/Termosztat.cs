using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class Termosztat : OkosEszkoz
    {
        public double JelenlegiHomerseklet { get; private set; }

        public double CelHomerseklet { get; private set; }

        public Termosztat(string azonosito, string nev, double celHomerseklet)
            : base(azonosito, nev)
        {
            this.JelenlegiHomerseklet = 21.0;
            this.CelHomerseklet = celHomerseklet;
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
    }
}