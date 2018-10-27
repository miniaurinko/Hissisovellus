
//ovi joka osaa mennä auki ja kiinni
class Ovi
{
    private bool Closed;

    public Ovi(bool _closed)
    {
        Closed = _closed;
    }

    public void open()
    {
        Closed = false;
    }

    public void close()
    {
        Closed = true;
    }
}