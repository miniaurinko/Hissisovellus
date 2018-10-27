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

        //alustus
        public Hissiohjain (int _level, int _targetlevel, bool _huollossa)
        {
            level = _level;
            targetlevel = _targetlevel;
            huollossa = _huollossa;
        }

        //saadaan tarvittaessa kohdekerros
        public int gettarget()
        {
            return this.targetlevel;
        }

        
        //tilataan ilmoitukset napeilta
        public void SubscribeH(Hissinappi h)
        {
            h.Painallus += new Hissinappi.NapinPainallus(saatu);
        }
        public void SubscribeK(Kerrosnappi k)
        {
            k.Painallusk += new Kerrosnappi.NapinPainallus(saatu);
        }

        //mitä tehdään kun saadaan hissin napilta viesti
        private void saatu(Hissinappi h, HissiNappiPainettu e)
        {
              
            if (huollossa && e.huoltaja == false)
            {
                Console.WriteLine("Hissi on tällä hetkellä huollossa");
            }
            if (huollossa && e.huoltaja)
            {
                this.targetlevel = e.kerros;
                hissi.move(e.kerros);
                if (hissi.getMoving()) ovi.open();
                this.level = e.kerros;
                Console.WriteLine("Tervetuloa hissiin huoltaja, olethan varovainen");
                Console.WriteLine("Hissi menossa kerrokseen " + e.kerros);
                Console.WriteLine("plim, hissi perillä kerroksessa " + e.kerros);
                Console.WriteLine("ovi aukeaa");
            }
            if(huollossa == false)
            {
                Console.WriteLine("Painoit nappia " + e.kerros);
                Console.WriteLine("Hissi menossa kerrokseen " + e.kerros);
                this.targetlevel = e.kerros;
                hissi.move(e.kerros);
                if (hissi.getMoving()) ovi.open();
                this.level = e.kerros;
                Console.WriteLine("plim, hissi perillä kerroksessa " + e.kerros);
                Console.WriteLine("ovi aukeaa");
            }


        }

        //mitä tehdään kun sadaan kerroksen napilta viesti
        private void saatu(Kerrosnappi k, KerrosNappiPainettu e)
        {
            if (huollossa && e.huoltaja == false)
            {
                Console.WriteLine("Hissi huollossa, nappi ei toimi");
            }
            if (huollossa && e.huoltaja)
            {
                Console.WriteLine("Hei huoltaja, hissi tulossa kerrokseen"+e.kerros);
                this.targetlevel = e.kerros;
                if (hissi.getMoving() == false) ovi.close();
                hissi.move(e.kerros);
                this.level = e.kerros;
                Console.WriteLine("(Hissin ovi aukeaa edessäsi)");

            }
            if (huollossa == false)
            {

                this.targetlevel = e.kerros;


                if (hissi.getMoving() == false) ovi.close();

                hissi.move(e.kerros);
                this.level = e.kerros;
                Console.WriteLine("(Hissin ovi aukeaa edessäsi)");
            }
        }

    }


}
