abstract class Shape
{
    private string _color;
    public Shape()
    {
        _color = "";
    }
    public Shape(string color)
    {
        _color = color;
    }
    public abstract double GetArea();
    public string GetColor()
    {
        return _color;
    }
}