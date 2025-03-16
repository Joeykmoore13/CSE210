using Microsoft.Win32.SafeHandles;

class Piece
{
    protected string _homePosition;
    private string _color;

    public Piece()
    {
        _homePosition = "";
        _color = "Gray";
    }
    public Piece(string homePosition, string color)
    {
        _homePosition = homePosition;
        _color = color;
    }
    
    public string GetColor()
    {
        return _color;
    }
}