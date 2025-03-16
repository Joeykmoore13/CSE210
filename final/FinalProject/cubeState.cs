class CubeState
{
    private Dictionary<string, Piece> _pieces;
    private bool _is3x3;

    public CubeState()
    {
        _is3x3 = false;
        _pieces = new Dictionary<string, Piece>();
    }
    public CubeState(Dictionary<string, Corner> cornerList)
    {
        Console.WriteLine("Initialized CubeState w/ corner dictionary");
        _is3x3 = false;
        cornerList.ToList().ForEach(x => _pieces.Add(x.Key, x.Value));
    }
    public CubeState(Dictionary<string, Edge> edgeList, Dictionary<string, Corner> cornerList, Center center)
    {
        _is3x3 = true;
        _pieces = new Dictionary<string, Piece>();
        edgeList.ToList().ForEach(x => _pieces.Add(x.Key, x.Value));
        cornerList.ToList().ForEach(x => _pieces.Add(x.Key, x.Value));
        _pieces.Add("Center", center);
    }
    public Dictionary<string, Piece> GetPieces()
    {
        return _pieces;
    }
}