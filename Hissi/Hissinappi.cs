using System;
namespace Hissisovellus
{
    //nappi joka on hississä
    class Hissinappi : Nappi
    {
        private int kerros;
        public event NapinPainallus Painallus;
        public HissiNappiPainettu e;
        public delegate void NapinPainallus(Hissinappi h, HissiNappiPainettu e);

        //alustus
        public Hissinappi(int _level, bool _serviceCodePressed, bool _pressed)
        {
            kerros = _level;
            this.serviceCodePressed = _serviceCodePressed;
            this.pressed = _pressed;
        }

        //tapahtuma jossa hississä on painettu jotain kerroksen numeroa
        public void painakerros(int kerrosnro, bool huoltaja)
        {
           
           //Console.WriteLine("Painoit nappia " + kerrosnro);
           //Console.WriteLine("Plim plom, hissi menossa kohti kerrosta " + kerrosnro);
           HissiNappiPainettu args = new Hissisovellus.HissiNappiPainettu();
           args.kerros = kerrosnro;
           args.huoltaja = huoltaja;
           Painallus(this, args);

        }
        
    }

    //argumentit tapahtumalle: kerros
    public class HissiNappiPainettu : EventArgs
    {
        public int kerros { get; set; }
        public bool huoltaja { get; set; }
    }
}