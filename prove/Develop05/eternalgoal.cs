class EternalGoal : Goal
{
    private int _numComplete;
    public EternalGoal() : base()
    {
        _numComplete = 0;
    }
    public EternalGoal(string dataString) : base()
    {
        //"Goal name","Goal description",<point value>,<num complete int>
        string[] split = dataString.Split(",");
        _goalName = split[0];
        _goalDescription =  split[1];
        _pointValue = Convert.ToInt32(split[2]);
        _numComplete = Convert.ToInt32(split[3]);
    }
    public EternalGoal(int pointValue, string goalName, string goalDescripton) : base(pointValue, goalName, goalDescripton)
    {
        _numComplete = 0;
    }
    public override bool IsComplete()
    {
        return false;
    }
    public override int GetEarnedPoints()
    {
        return _numComplete * _pointValue;
    }
    public override void Display()
    {
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"{_numComplete}");
        Console.ResetColor();
        Console.WriteLine($"] {_goalName} ({_goalDescription}) (worth {_pointValue * _numComplete} points total)");
    }
    public override void RecordEvent()
    {
        _numComplete++;
        Console.WriteLine($"Event Recorded! You earned {_pointValue} more points!");
    }
    public override string GetDataString()
    {
        return $"2;{_goalName},{_goalDescription},{_pointValue},{_numComplete}";
        // (<goalType> : 1|2|3);"Goal name","Goal description",<point value>,<num complete int>
    }
}