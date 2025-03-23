using System.Drawing;

class Corner : Piece
{
    private int _orientation;
    private ConsoleColor _colorTwo;
    private ConsoleColor _colorThree;

    public Corner() : base()
    {
        _orientation = 1;
        _colorTwo = ConsoleColor.Gray;
        _colorThree = ConsoleColor.Gray;
    }
    public Corner(string homePosition, ConsoleColor color, ConsoleColor colorTwo, ConsoleColor colorThree) : base(homePosition, color)
    {
        _orientation = 1;
        _colorTwo = colorTwo;
        _colorThree = colorThree;
    }
    public Corner(string dataString) : base()
    {
        Dictionary<string, ConsoleColor> colorInterpreter = new Dictionary<string, ConsoleColor>{["White"] = ConsoleColor.White, ["DarkRed"] = ConsoleColor.DarkRed, ["Green"] = ConsoleColor.Green, ["Red"] = ConsoleColor.Red, ["Blue"] = ConsoleColor.Blue, ["Yellow"] = ConsoleColor.Yellow};
        string[] components = dataString.Split(",");
        _homePosition = components[0];
        _color = colorInterpreter[components[1]];
        _colorTwo = colorInterpreter[components[2]];
        _colorThree = colorInterpreter[components[3]];
        _orientation = Convert.ToInt32(components[4]);
    }

    public void TwistClockwise()
    {
        _orientation = (_orientation + 1) % 3 + 1;
        ConsoleColor tempColorOne = _color;
        ConsoleColor tempColorTwo = _colorTwo;
        ConsoleColor tempColorThree = _colorThree;

        _color = tempColorThree;
        _colorTwo = tempColorOne;
        _colorThree = tempColorTwo;
    }
    public void TwistCounterClockwise()
    {
         _orientation = (_orientation - 1) % 3 + 1;
         ConsoleColor tempColorOne = _color;
        ConsoleColor tempColorTwo = _colorTwo;
        ConsoleColor tempColorThree = _colorThree;

        _color = tempColorTwo;
        _colorTwo = tempColorThree;
        _colorThree = tempColorOne;
    }
    public override ConsoleColor GetColorTwo()
    {
        return _colorTwo;
    }
    public override ConsoleColor GetColorThree()
    {
        return _colorThree;
    }
    public int GetOrientation()
    {
        return _orientation;
    }
}