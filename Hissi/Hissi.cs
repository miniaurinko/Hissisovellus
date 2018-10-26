namespace Hissisovellus
{
    class Hissi
    {
        private int level;
        private bool moving;

        public Hissi(int _level, bool _moving)
        {
            level = _level;
            moving = _moving;
        }
        public void stop()
        {
            moving = false;
        }

        public bool getMoving() { return moving; }


        public void move(int kerros)
        {
            moving = true;
            //tässä välissä hissillä menisi oikeasti aikaa siirtyä
            level = kerros;
            moving = false;
        }


    }
}