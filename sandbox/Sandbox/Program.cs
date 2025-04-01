using System;
using System.Text.RegularExpressions;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        ClassTwo _classTwo = new ClassTwo();
        ClassThree _classThree = new ClassThree();
        _classTwo.Display();
        _classThree.Display();
    }
}

abstract class ClassOne
{
    public ClassOne()
    {

    }
    public abstract void Display();
}
class ClassTwo : ClassOne
{
    public ClassTwo() : base()
    {

    }
    public override void Display()
    {
        Console.WriteLine("ClasTwo display");
    }
}
class ClassThree : ClassTwo
{
    public ClassThree() : base()
    {

    }
    public override void Display()
    {
        Console.WriteLine("ClassThree display");
    }
}