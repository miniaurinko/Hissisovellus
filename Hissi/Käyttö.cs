using System.Collections;
using System.Collections.Generic;

namespace Hissisovellus
{
    class Käyttö
    {
        //tästä voit käyttää hissiä
        //hissin sisällä: .painakerros(a) jossa a on haluttu kerros
        //kerroksen ulkopuolella: painetaan kerrosta vastaavaa nappia
        //.painanappi(b), jossa b on joko 0(alas) tai 1(ylös)
        public static void Main()
        {
            Hissinappi h = new Hissisovellus.Hissinappi(0,false,false);

            //hissi joka ei ole huollossa
            Hissiohjain ho = new Hissiohjain(0, 0, false);

            //hissi joka on huollossa
            //Hissiohjain ho = new Hissiohjain(0, 0, true);


            Kerrosnappi k0 = new Hissisovellus.Kerrosnappi(0, 0, false, false);
            Kerrosnappi k1 = new Hissisovellus.Kerrosnappi(1, 0, false, false);
            Kerrosnappi k2 = new Hissisovellus.Kerrosnappi(2, 0, false, false);
            Kerrosnappi k3 = new Hissisovellus.Kerrosnappi(3, 0, false, false);
            ho.SubscribeK(k0);
            ho.SubscribeK(k1);
            ho.SubscribeK(k2);
            ho.SubscribeK(k3);


            //List<Kerrosnappi> list = addbuttons(ho, 3);
            ho.SubscribeH(h);
            h.painakerros(3,false);
            h.painakerros(2,true);
            k0.painanappi(1, false);
            k1.painanappi(1, true);






        }


        
    }
}