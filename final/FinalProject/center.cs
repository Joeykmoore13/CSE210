class Center : Piece
{
    private int _orientation;

    public Center() : base()
    {
        _orientation = 0;
    }
    public Center(string color) : base("1", color)
    {
        _orientation = 0;
    }

    public int GetOrientation()
    {
        return _orientation;
    }

    private void M()
    {

    }
    private void Mp()
    {

    }
    private void M2()
    {

    }
}