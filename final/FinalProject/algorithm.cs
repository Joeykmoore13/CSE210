using System.Diagnostics;

class Algorithm
{
    private string _algName;
    private List<string> _moves;
    private bool _is3x3;

    public Algorithm()
    {
        _algName = "";
        _moves = new List<string>();
        _is3x3 = false;
    }
    public Algorithm(string algName, List<string> moves, bool is3x3)
    {
        _algName = algName;
        _moves = moves;
        _is3x3 = is3x3;
    }
}