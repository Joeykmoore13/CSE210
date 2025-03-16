class ThreeXThree : Cube
{
    private Center center;
    private Dictionary<string, Edge> _edgeList;

    public ThreeXThree() : base()
    {
        center = new Center("White");
        // Add edges to this list
        _edgeList = new Dictionary<string, Edge>();
        _edgeList.Add("A", new Edge("A", "White", "Blue"));
        _edgeList.Add("B", new Edge("B", "White", "Red"));
        _edgeList.Add("C", new Edge("C", "White", "Green"));
        _edgeList.Add("D", new Edge("D", "White", "Orange"));
        _edgeList.Add("L", new Edge("L", "Green", "Orange"));
        _edgeList.Add("J", new Edge("J", "Green", "Red"));
        _edgeList.Add("R", new Edge("R", "Blue", "Orange"));
        _edgeList.Add("T", new Edge("T", "Blue", "Red"));
        _edgeList.Add("U", new Edge("U", "Yellow", "Green"));
        _edgeList.Add("V", new Edge("V", "Yellow", "Red"));
        _edgeList.Add("W", new Edge("W", "Yellow", "Blue"));
        _edgeList.Add("X", new Edge("X", "Yellow", "Orange"));
    }

    public override void Display()
    {
        //Use the same display here as for the cubeStates. We dont want to always make and save a new cube state just to display what the cube looks like
    }
    public override CubeState GenerateCubeState()
    {
        //Add the cube states manually when trying to save a cube state for later. This prevents having unwanted cubestates saved
        return _stateList.Last();
    }

    //The same applies to these move methods as in the cube class. The odd formatting is on purpose to match notation.
    //Like in the cube class, all of the methods below corespond to a move on the rubik's cube. The R, F, and U methods are being overwritten to include moving edge pieces around
    public override void R()
    {
        base.R();
    }
    public override void Rp()
    {
        base.Rp();
    }
    public override void R2()
    {
        base.R2();
    }
    public override void U()
    {
        base.U();
    }
    public override void Up()
    {
        base.Up();
    }
    public override void U2()
    {
        base.R2();
    }
    public override void F()
    {
        base.F();
    }
    public override void Fp()
    {
        base.Fp();
    }
    public override void F2()
    {
        base.F2();
    }
    public void M()
    {

    }
    public void Mp()
    {

    }
    public void M2()
    {

    }
    public void L()
    {

    }
    public void Lp()
    {

    }
    public void L2()
    {

    }
    public void B()
    {

    }
    public void Bp()
    {

    }
    public void B2()
    {

    }
    public void D()
    {

    }
    public void Dp()
    {

    }
    public void D2()
    {

    }
    public void Rw()
    {

    }
    public void Rwp()
    {

    }
    public void Rw2()
    {

    }
    public void Lw()
    {

    }
    public void Lwp()
    {

    }
    public void Lw2()
    {

    }
    public override void ClockwiseTurn()
    {
        base.ClockwiseTurn();
    }
    public override void CounterClockwiseTurn()
    {
        base.CounterClockwiseTurn();
    }
    public override void DoubleTurn()
    {
        base.DoubleTurn();
    }
}