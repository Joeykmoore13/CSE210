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
    public void DisablePiece()
    {
        //Change the display colors
    }
    public void EnablePiece()
    {
        //Change the display colors
    }
    // Add a DisablePiece method that sets a bool for the piece
    // Add an EnablePiece method that sets a bool for the piece
    // Change the get color methods to return gray if the piece is disabled
}