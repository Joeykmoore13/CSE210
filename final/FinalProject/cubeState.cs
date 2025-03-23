using System.Text.RegularExpressions;

class CubeState
{
    private Dictionary<string, Piece> _pieces;
    private Dictionary<string, Edge> _edges;
    private Dictionary<string, Corner> _corners;
    private Center currentCenter = null;

    public CubeState()
    {
        _pieces = new Dictionary<string, Piece>();
        _edges = new Dictionary<string, Edge>();
        _corners = new Dictionary<string, Corner>();
    }
    public CubeState(Dictionary<string, Corner> cornerList)
    {
        _pieces = new Dictionary<string, Piece>();
        _edges = new Dictionary<string, Edge>();
        _corners = new Dictionary<string, Corner>(cornerList);
        cornerList.ToList().ForEach(x => _pieces.Add(x.Key, x.Value));
    }
    public CubeState(Dictionary<string, Corner> cornerList, Dictionary<string, Edge> edgeList, Center center)
    {
        _edges = new Dictionary<string, Edge>(edgeList);
        _corners = new Dictionary<string, Corner>(cornerList);
        currentCenter = center;
        _edges = edgeList;
        _corners = cornerList;
        _pieces = new Dictionary<string, Piece>();
        edgeList.ToList().ForEach(x => _pieces.Add(x.Key, x.Value));
        cornerList.ToList().ForEach(x => _pieces.Add(x.Key, x.Value));
        _pieces.Add("center", center);
    }
    public CubeState(string dataString)
    {
        //Fill this out to load cubeStates
    }
    public Dictionary<string, Piece> GetPieces()
    {
        return _pieces;
    }
    public string GetDataString()
    {
        List<string> pieceKeys = new List<string>(_pieces.Keys);
        string subString = "";
        string dataString = "";
        var cornerSearch = new Regex(@"\w{1}[c]");
        foreach (var key in pieceKeys)
        {
            if (cornerSearch.IsMatch(key))
            {
                subString = $"2;{key};{_corners[key].GetHomePosition()},{_corners[key].GetColor()},{_corners[key].GetColorTwo()},{_corners[key].GetColorThree()},{_corners[key].GetOrientation()}";
            }
            else if (key == "center")
            {
                subString = $"3;{key};{currentCenter.GetOrientation()},{currentCenter.GetColor()}";
            }
            else
            {
                subString = $"1;{key};{_edges[key].GetHomePosition()},{_edges[key].GetColor()},{_edges[key].GetColorTwo()},{_edges[key].IsOriented}";
            }
            dataString = dataString + $"|{subString}";


        }
        return dataString;
    }
}