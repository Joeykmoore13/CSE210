class Breathe : Activity
{
    public Breathe() : base()
    {

    }
    public Breathe(int duration) : base(duration, "This activity will help you relax by walking you through breathing in and out slowly.", "breathing")
    {
        _duration = duration;
    }
    public override void ActivityLoop()
    {
        base.ActivityLoop();
        var _startTime = DateTime.Now;
        var _endTime = _startTime.AddSeconds(_duration);
        while (DateTime.Now < _endTime)
        {
            Console.Clear();
            Console.WriteLine("Breathe in...");
            ShowAnimation(5);
            Console.Clear();
            Console.WriteLine("Breathe out...");
            ShowAnimation(5);
        }
        EndingMessage(_startTime);
    }
}