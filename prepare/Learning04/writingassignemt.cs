class Writing : Assignment
{
    private string _title;
    public Writing() : base()
    {
        _title = "";
    }
    public Writing(string title, string name, string topic) : base(name, topic)
    {
        _title = title;
    }

    public string GetWritingInformaton()
    {
        return _title;
    }
}