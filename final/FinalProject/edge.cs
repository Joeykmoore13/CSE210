using System.Diagnostics;

class Edge : Piece
{
    private bool _oriented;
    private string _colorTwo;

    public Edge() : base()
    {
        _oriented = true;
        _colorTwo = "Gray";
    }
    public Edge(string homePosition, string color, string colorTwo) : base(homePosition, color)
    {
        _oriented = true;
        _colorTwo = colorTwo;
    }

    private void FlipEdge()
    {
        _oriented = !_oriented;
    }
}