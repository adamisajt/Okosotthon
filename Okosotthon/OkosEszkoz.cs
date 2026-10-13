using System;

namespace Okosotthon
{
    public abstract class OkosEszkoz
    {
        private string azonosito;
        private string nev;
        private bool onlineE;
        private DateTime utolsoFrissites;

        public string Azonosito
        {
            get { return this.azonosito; }
            private set { this.azonosito = value; }
        }

        public string Nev
        {
            get { return this.nev; }
            private set { this.nev = value; }
        }

        public bool OnlineE
        {
            get { return this.onlineE; }
            private set { this.onlineE = value; }
        }

        public DateTime UtolsoFrissites
        {
            get { return this.utolsoFrissites; }
            protected set { this.utolsoFrissites = value; }
        }

        public OkosEszkoz(string azonosito, string nev)
        {
            this.Azonosito = azonosito;
            this.Nev = nev;
            this.OnlineE = false;
            this.UtolsoFrissites = DateTime.Now;
        }

        public void Csatlakozas()
        {
            this.OnlineE = true;
        }

        public void KapcsolatBontasa()
        {
            this.OnlineE = false;
        }

        public bool DiagnosztikaFuttatasa()
        {
            if (this.OnlineE == false)
            {
                return false;
            }

            return this.OnTesztFuttatasa();
        }

        public virtual void GyariBeallitasokVisszaallitasa()
        {
            this.OnlineE = false;
            this.UtolsoFrissites = DateTime.Now;
        }

        public abstract void ParancsVegrehajtasa(string parancs);

        public abstract string AllapotJelentes();

        protected abstract bool OnTesztFuttatasa();
    }
}