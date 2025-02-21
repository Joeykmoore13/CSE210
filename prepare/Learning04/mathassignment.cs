class Math : Assignment
{
    public string _textbookSection;
    public string _problems;
    public Math() : base()
    {
        _textbookSection = "";
        _problems = "";
    }
    public Math(string textbookSection, string problems, string name, string topic) : base(name, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }
    public string GetHomeworkList()
    {
        return $"{_textbookSection}: {_problems}";
    }
}