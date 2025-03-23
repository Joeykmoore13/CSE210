using System.Diagnostics;

class Algorithm
{
    private string _algName;
    private string _moves;

    public Algorithm()
    {
        _algName = "";
        _moves = "";
    }
    public Algorithm(string algName, string moves)
    {
        _algName = algName;
        _moves = moves;
    }
    public Algorithm(string dataString)
    {
        string[] splitData = dataString.Split(";");
        _algName = splitData[0].Trim();
        _moves = splitData[1];
        
    }
    public string GetMoves()
    {
        return _moves;
    }
    public string GetAlgName()
    {
        return _algName;
    }
}