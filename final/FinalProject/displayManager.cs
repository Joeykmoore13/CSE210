class DisplayManager
{
    private CubeState _currentDisplay;
    private List<string> _keyList;
    public DisplayManager()
    {
        _currentDisplay = null;
    }
    public void Display(CubeState cubeState)
    {
        _currentDisplay = cubeState;
        _keyList = new List<string>(_currentDisplay.GetPieces().Keys);
        foreach (var key in _keyList)
        {
            Console.WriteLine(_keyList);
            //Keep working from right here
        }


        Console.ResetColor();
    }

    private void Break()
    {
        Console.WriteLine();
    }
    private void Black()
    {
        Draw(ConsoleColor.Black);
    }
    private void White()
    {
        Draw(ConsoleColor.White);
    }
    private void Green()
    {
        Draw(ConsoleColor.Green);
    }
    private void Red()
    {
        Draw(ConsoleColor.DarkRed);
    }
    private void Blue()
    {
        Draw(ConsoleColor.Blue);
    }
    private void Orange()
    {
        Draw(ConsoleColor.Red);
    }
    private void Yellow()
    {
        Draw(ConsoleColor.Yellow);
    }
    private void Draw(ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write("\u2588");
        Console.Write("\u2588");
        //line();
    }
}