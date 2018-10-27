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

        //alustus
        public Kerrosnappi(int _level, int _direction, bool _serviceCodePressed, bool _pressed)
        {
            level = _level;
            direction = _direction;
            this.serviceCodePressed = _serviceCodePressed;
            this.pressed = _pressed;
        }

        //suoritetaan tapahtuma, jossa kerrosnappia on painettu
        public void painanappi(int suunta, bool huoltaja)
        {
            direction = suunta;
            Console.WriteLine("Painoit nappia kerroksessa " +level+ " menossa "+suuntaan() );
            KerrosNappiPainettu args = new Hissisovellus.KerrosNappiPainettu();
            args.kerros = this.level;
            args.direction = suunta;
            args.huoltaja = huoltaja;
            Painallusk(this, args);
        }
        //apualiohjelma suunnan kirjoittamiseksi
        public string suuntaan ()
        {
            if (direction == 0) return "alaspäin";
            else return "ylöspäin";
        }

    }
    //tapahtuman argumentit: kerros ja suunta
    public class KerrosNappiPainettu : EventArgs
    {
        public int kerros { get; set; }
        public int direction { get; set; }
        public bool huoltaja { get; set; }
    }
}