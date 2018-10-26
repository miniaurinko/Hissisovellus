using System.Collections;
using System.Collections.Generic;

namespace Hissisovellus
{
    class Käyttö
    {
        public static void Main()
        {
            Hissinappi h = new Hissisovellus.Hissinappi(0,false,false);
            Hissiohjain ho = new Hissiohjain(0, 0, false);
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
            h.painakerros(3);
            k0.painanappi(0);



        }

        public static List<Kerrosnappi> addbuttons(Hissiohjain h, int nro)
        {
            List<Kerrosnappi> a = new List<Kerrosnappi>(); 
            for(int i = 0;i<nro;i++)
            {
                Kerrosnappi kr = new Hissisovellus.Kerrosnappi(i, 0, false, false);
                a.Add(kr);
                h.SubscribeK(kr);
            }
            return a;
        }

        
    }
}