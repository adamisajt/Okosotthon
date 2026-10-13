using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosZar : OkosEszkoz
    {
        private string pinKod;

        public bool ZartE { get; private set; }

        public OkosZar(string azonosito, string nev, string pinKod)
            : base(azonosito, nev)
        {
            this.pinKod = pinKod;
            this.ZartE = true;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs == "ZARAS")
            {
                this.ZartE = true;
                this.UtolsoFrissites = DateTime.Now;
            }
            else
            {
                string[] reszek = parancs.Split(':');

                if (reszek.Length == 2)
                {
                    if (reszek[0] == "NYITAS")
                    {
                        if (reszek[1] == this.pinKod)
                        {
                            this.ZartE = false;
                            this.UtolsoFrissites = DateTime.Now;
                        }
                    }
                }
            }
        }

        public override string AllapotJelentes()
        {
            if (this.ZartE == true)
            {
                return "ZÁRVA";
            }

            return "NYITVA";
        }

        protected override bool OnTesztFuttatasa()
        {
            return true;
        }

        public override void GyariBeallitasokVisszaallitasa()
        {
            base.GyariBeallitasokVisszaallitasa();

            this.pinKod = "0000";
            this.ZartE = true;
        }
    }
}