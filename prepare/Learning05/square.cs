class Square : Shape
{
    private double _side;
    
    public Square() : base()
    {
        _side = 0;
    }
    public Square(double side, string color) : base(color)
    {
        _side = side;
    }
    public override double GetArea()
    {
        return (_side * _side);
    }
}