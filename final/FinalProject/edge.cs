using System.Diagnostics;

class Edge : Piece
{
    private bool _oriented;
    private ConsoleColor _colorTwo;

    public Edge() : base()
    {
        _oriented = true;
        _colorTwo = ConsoleColor.Gray;
    }
    public Edge(string homePosition, ConsoleColor color, ConsoleColor colorTwo) : base(homePosition, color)
    {
        _oriented = true;
        _colorTwo = colorTwo;
    }
    public Edge(string dataString) :base()
    {
        Dictionary<string, ConsoleColor> colorInterpreter = new Dictionary<string, ConsoleColor>{["White"] = ConsoleColor.White, ["DarkRed"] = ConsoleColor.DarkRed, ["Green"] = ConsoleColor.Green, ["Red"] = ConsoleColor.Red, ["Blue"] = ConsoleColor.Blue, ["Yellow"] = ConsoleColor.Yellow};
        string[] components = dataString.Split(",");
        _homePosition = components[0];
        _color = colorInterpreter[components[1]];
        _colorTwo = colorInterpreter[components[2]];
        _oriented = Convert.ToBoolean(components[3]);
    }

    public void FlipEdge()
    {
        _oriented = !_oriented;
        ConsoleColor tempColor1 = _color;
        ConsoleColor tempColor2 = _colorTwo;
        _color = tempColor2;
        _colorTwo = tempColor1;
    }
    public bool IsOriented()
    {
        return _oriented;
    }
    public override ConsoleColor GetColorTwo()
    {
        return _colorTwo;
    }
}