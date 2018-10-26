using System;

namespace Hissisovellus
{
    class Kerrosnappi : Nappi
    {
        private int level;
        //1 up 0 down
        private int direction;
        public event NapinPainallus Painallusk;
        public KerrosNappiPainettu e;
        public delegate void NapinPainallus(Kerrosnappi k, KerrosNappiPainettu e);


        public Kerrosnappi(int _level, int _direction, bool _serviceCodePressed, bool _pressed)
        {
            level = _level;
            direction = _direction;
            this.serviceCodePressed = _serviceCodePressed;
            this.pressed = _pressed;
        }

        public void painanappi(int suunta)
        {
            direction = suunta;
            Console.WriteLine("Painoit nappia kerroksessa " +level+ "menossa "+suuntaan() );
            KerrosNappiPainettu args = new Hissisovellus.KerrosNappiPainettu();
            args.kerros = this.level;
            args.direction = suunta;
            Painallusk(this, args);
        }

        public string suuntaan ()
        {
            if (direction == 0) return "alaspäin";
            else return "ylöspäin";
        }

    }
    public class KerrosNappiPainettu : EventArgs
    {
        public int kerros { get; set; }
        public int direction { get; set; }
    }
}