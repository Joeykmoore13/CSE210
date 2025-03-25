using Microsoft.Win32.SafeHandles;

class Piece
{
    protected string _homePosition;
    protected ConsoleColor _color;

    public Piece()
    {
        _homePosition = "";
        _color = ConsoleColor.Gray;
    }
    public Piece(string homePosition, ConsoleColor color)
    {
        _homePosition = homePosition;
        _color = color;
    }

    public string GetHomePosition()
    {
        return _homePosition;
    }
    public virtual ConsoleColor GetColor()
    {
        return _color;
    }
    public virtual ConsoleColor GetColorTwo()
    {
        return ConsoleColor.Gray;
    }
    public virtual ConsoleColor GetColorThree()
    {
        return ConsoleColor.Gray;
    }
}