class Center : Piece
{
    private int _orientation;

    public Center() : base()
    {
        _orientation = 0;
    }
    public Center(ConsoleColor color) : base("1", color)
    {
        _orientation = 0;
    }
    public Center(string dataString) :base()
    {
        Dictionary<string, ConsoleColor> colorInterpreter = new Dictionary<string, ConsoleColor>{["White"] = ConsoleColor.White, ["DarkRed"] = ConsoleColor.DarkRed, ["Green"] = ConsoleColor.Green, ["Red"] = ConsoleColor.Red, ["Blue"] = ConsoleColor.Blue, ["Yellow"] = ConsoleColor.Yellow};
        string[] components = dataString.Split(",");
        _orientation = Convert.ToInt32(components[0]);
        _color = colorInterpreter[components[1]];
    }

    public int GetOrientation()
    {
        return _orientation;
    }
    public string[] GetColors()
    {
        if (_orientation == 1)
        {
            return ["white", "green", "yellow", "blue"];
        }
        else if (_orientation == 2)
        {
            return ["green", "yellow", "blue", "white"];

        }
        else if (_orientation == 3)
        {
            return ["yellow", "blue", "white", "green"];
        }
        else
        {
            return ["blue", "white", "green", "yellow"];
        }
    }
    public void M()
    {
        _orientation = (_orientation - 1) % 4;
    }
    public void Mp()
    {
        _orientation = (_orientation + 1) % 4;
    }
    public void M2()
    {
        _orientation = (_orientation + 2) % 4;
    }
}