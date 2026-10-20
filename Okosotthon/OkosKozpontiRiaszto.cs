using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosKozpontiRiaszto : OkosEszkoz,
        IIdozitheto, IHangjelzo, IStatisztika
    {
        private DateTime idozitoVege;
        private int riasztasokSzama;

        public OkosKozpontiRiaszto(string azonosito, string nev)
            : base(azonosito, nev)
        {
            this.idozitoVege = DateTime.Now;
            this.riasztasokSzama = 0;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs == "RIASZTAS")
            {
                this.VeszjelzesInditasa();
            }
        }

        public override string AllapotJelentes()
        {
            return this.Nev
                + " | Online: " + this.OnlineE
                + " | Hátralévõ idõ: " + this.GetMaradtIdo() + " perc";
        }

        protected override bool OnTesztFuttatasa()
        {
            return true;
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
            this.riasztasokSzama++;
            this.UtolsoFrissites = DateTime.Now;

            Console.WriteLine(this.Nev + ": VÉSZJELZÉS!");
            this.Csipog(1000);
        }

        public string StatisztikatKeszit()
        {
            return this.Nev
                + " | Riasztások száma: " + this.riasztasokSzama
                + " | Hátralévõ idõ: " + this.GetMaradtIdo() + " perc";
        }

        public override void GyariBeallitasokVisszaallitasa()
        {
            base.GyariBeallitasokVisszaallitasa();

            this.idozitoVege = DateTime.Now;
            this.riasztasokSzama = 0;
        }
    }
}