class Cube
{
    protected Dictionary<string, Corner> _cornerList;
    protected List<CubeState> _stateList;
    //I dont know if having a display manager object is actually good practice but it made my code much cleaner so I kept it
    protected DisplayManager _displayManager;

    public Cube()
    {
        //Add the pieces to this
        _cornerList = new Dictionary<string, Corner>();
        _cornerList.Add("ac", new Corner("A", "White", "Orange", "Blue"));
        _cornerList.Add("bc", new Corner("B", "White", "Blue", "Red"));
        _cornerList.Add("cc", new Corner("C", "White", "Red", "Green"));
        _cornerList.Add("dc", new Corner("D", "White", "Green", "Orange"));
        _cornerList.Add("uc", new Corner("U", "Yellow", "Orange", "Green"));
        _cornerList.Add("vc", new Corner("V", "Yellow", "Green", "Red"));
        _cornerList.Add("wc", new Corner("W", "Yellow", "Red", "Blue"));
        _cornerList.Add("xc", new Corner("X", "Yellow", "Blue", "Orange"));
        _stateList = new List<CubeState>();
        _displayManager = new DisplayManager();
    }

    public virtual CubeState GenerateCubeState()
    {
        _stateList.Add(new CubeState(_cornerList));
        return _stateList.Last();
    }

    public virtual void Display()
    {
        _displayManager.Display(GenerateCubeState());
    }

    //All of the methods below corespond to a move on the rubik's cube. The p stands for 'prime' which means it is counterclockwise. The 2 means twice. No p or 2 means clockwise.
    //Each letter coresponds to a face of the rubik's cube. R means right, U for up, F for front.
    //These were not named with cammel case on purpose. Rubik's cube notation uses capital letters and 2's for moves so I formated the methods that perform moves to match.
    public virtual void R()
    {

    }
    public virtual void Rp()
    {

    }
    public virtual void R2()
    {

    }
    public virtual void U()
    {

    }
    public virtual void Up()
    {

    }
    public virtual void U2()
    {

    }
    public virtual void F()
    {

    }
    public virtual void Fp()
    {

    }
    public virtual void F2()
    {

    }
    //These are to simplify moving pieces around
    public virtual void ClockwiseTurn()
    {

    }
    public virtual void CounterClockwiseTurn()
    {

    }
    public virtual void DoubleTurn()
    {

    }

    

}