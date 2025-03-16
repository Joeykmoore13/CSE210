abstract class Goal
{
    protected string _goalName;
    protected string _goalDescription;
    protected int _pointValue;

    public Goal()
    {
        _goalName = "";
        _goalDescription = "";
        _pointValue = 0;
    }
    public Goal(int pointValue, string goalName, string goalDescripton)
    {
        _pointValue = pointValue;
        _goalName = goalName;
        _goalDescription = goalDescripton;
    }
    public abstract bool IsComplete();
    public virtual int GetEarnedPoints()
    {
        return 0;
    }
    public abstract void Display();
    public abstract string GetDataString();
    public abstract void RecordEvent();
}