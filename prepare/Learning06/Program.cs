using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square s1 = new Square("Red", 3);
        Rectangle r1 = new Rectangle("Yellow", 4, 5);
        Circle c1 = new Circle("Blue", 6);
        shapes.AddRange(new Shape[] {s1, r1, c1});

        Square s2 = new Square("Orange", 7);
        Rectangle r2 = new Rectangle("Green", 8, 9);
        Circle c2 = new Circle("Violet", 10);
        shapes.AddRange(new Shape[] {s2, r2, c2});

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();
            double area = s.GetArea();
            string shape = s.GetShape();

            Console.ForegroundColor = GetTextColor(color);
            Console.WriteLine($"The {color} {shape} has an area of {area:0.00}.\n");
            Console.ResetColor();
        }
    }

    static ConsoleColor GetTextColor(string color)
    {
        switch (color.ToLower())
        {
            case "red":
                return ConsoleColor.Red;
            case "yellow":
                return ConsoleColor.Yellow;
            case "blue":
                return ConsoleColor.Blue;
            case "orange":
                return ConsoleColor.DarkYellow;
            case "green":
                return ConsoleColor.Green;
            case "violet":
                return ConsoleColor.Magenta;
            default:
                return ConsoleColor.White;
        }
    }
}