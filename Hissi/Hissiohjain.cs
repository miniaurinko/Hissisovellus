using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hissisovellus;

namespace Hissisovellus
{
    class Hissiohjain
    {
        private int level;
        private int targetlevel;
        private bool huollossa;
        private Hissi hissi = new Hissi(0,false);
        private Ovi ovi = new Ovi(true);

        public Hissiohjain (int _level, int _targetlevel, bool _huollossa)
        {
            level = _level;
            targetlevel = _targetlevel;
            huollossa = _huollossa;
            
        }
        public int gettarget()
        {
            return this.targetlevel;
        }

        

        public void SubscribeH(Hissinappi h)
        {
            h.Painallus += new Hissinappi.NapinPainallus(saatu);
        }
        public void SubscribeK(Kerrosnappi k)
        {
            k.Painallusk += new Kerrosnappi.NapinPainallus(saatu);
        }

        private void saatu(Hissinappi h, HissiNappiPainettu e)
        {
            this.targetlevel = e.kerros;
            hissi.move(e.kerros);
            if (hissi.getMoving()) ovi.open();
            this.level = e.kerros;
            Console.WriteLine("plim, hissi perillä kerroksessa " + e.kerros );

        }
        private void saatu(Kerrosnappi k, KerrosNappiPainettu e)
        {
            this.targetlevel = e.kerros;
            hissi.move(e.kerros);
            if(hissi.getMoving()) ovi.open();
            this.level = e.kerros;
            Console.WriteLine("(Hissin ovi aukeaa edessäsi)");
        }

    }


}
