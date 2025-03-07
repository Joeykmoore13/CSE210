class Rectangle : Shape
{
    private int _length;
    private double _width;
    
    public Rectangle() : base()
    {
        _length = 0;
        _width = 0;
    }
    public Rectangle(int length, int width, string color) : base(color)
    {
        _length = length;
        _width = width;
    }
    public override double GetArea()
    {
        return (_length * _width);
    }
}