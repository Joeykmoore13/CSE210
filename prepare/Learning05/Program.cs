using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapeList = new List<Shape>();
        shapeList.Add(new Square(5, "Green"));
        shapeList.Add(new Circle(5, "Blue"));
        shapeList.Add(new Rectangle(5, 7, "Red"));
        foreach (Shape shape in shapeList)
        {
            Console.WriteLine($"Area: {shape.GetArea()}, Color: {shape.GetColor()}");
        }
    }

}