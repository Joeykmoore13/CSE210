class Corner : Piece
{
    private string _orientation;
    private string _colorTwo;
    private string _colorThree;

    public Corner() : base()
    {
        _orientation = "";
        _colorTwo = "Gray";
        _colorThree = "Gray";
    }
    public Corner(string orientation, string color, string colorTwo, string colorThree) : base(orientation, color)
    {
        _orientation = orientation;
        _colorTwo = colorTwo;
        _colorThree = colorThree;
    }

    public void TwistClockwise()
    {

    }
    public void TwistCounterClockwise()
    {

    }
}