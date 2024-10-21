using System;

public class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }
    public override double GetArea()
    {
        double pi = Math.PI;
        return pi * (_radius * _radius);
    }

    public override string GetShape()
    {
        return "Circle";
    }
}