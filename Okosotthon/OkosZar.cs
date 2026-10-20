using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosZar : OkosEszkoz, IHangjelzo, IStatisztika
    {
        private string pinKod;
        private int nyitasokSzama;

        public bool ZartE { get; private set; }

        public OkosZar(string azonosito, string nev, string pinKod)
            : base(azonosito, nev)
        {
            this.pinKod = pinKod;
            this.ZartE = true;
            this.nyitasokSzama = 0;
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
                            if (this.ZartE == true)
                            {
                                this.nyitasokSzama++;
                            }

                            this.ZartE = false;
                            this.UtolsoFrissites = DateTime.Now;
                        }
                        else
                        {
                            this.Csipog(300);
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
            this.nyitasokSzama = 0;
        }

        public void Csipog(int hosszu)
        {
            if (hosszu > 0)
            {
                Console.WriteLine(this.Nev + ": csipogás");
                Console.Beep(1000, hosszu);
            }
        }

        public void VeszjelzesInditasa()
        {
            Console.WriteLine(this.Nev + ": VÉSZJELZÉS!");
            this.Csipog(1000);
        }

        public string StatisztikatKeszit()
        {
            return this.Nev
                + " | Nyitások száma: " + this.nyitasokSzama
                + " | Állapot: " + this.AllapotJelentes();
        }
    }
}