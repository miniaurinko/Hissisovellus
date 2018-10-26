using System;
namespace Hissisovellus
{
    class Hissinappi : Nappi
    {
        private int kerros;
        public event NapinPainallus Painallus;
        public HissiNappiPainettu e;
        public delegate void NapinPainallus(Hissinappi h, HissiNappiPainettu e);

        public Hissinappi(int _level, bool _serviceCodePressed, bool _pressed)
        {
            kerros = _level;
            this.serviceCodePressed = _serviceCodePressed;
            this.pressed = _pressed;
        }

        public void painakerros(int kerrosnro)
        {
            Console.WriteLine("Plim plom, hissi menossa kohti kerrosta " +kerrosnro);
            HissiNappiPainettu args = new Hissisovellus.HissiNappiPainettu();
            args.kerros = kerrosnro;
            Painallus(this, args);
        }

        
    }
    public class HissiNappiPainettu : EventArgs
    {
        public int kerros { get; set; }
    }
}