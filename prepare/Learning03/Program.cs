using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction n1 = new Fraction();
        Console.WriteLine(n1.GetFraction());
        Console.WriteLine(n1.GetDecimal());

        Fraction n2 = new Fraction(5);
        Console.WriteLine(n2.GetFraction());
        Console.WriteLine(n2.GetDecimal());

        Fraction n3 = new Fraction(5, 8);
        Console.WriteLine(n3.GetFraction());
        Console.WriteLine(n3.GetDecimal());

        Fraction n4 = new Fraction(4, 13);
        Console.WriteLine(n4.GetFraction());
        Console.WriteLine(n4.GetDecimal());

        Fraction n5 = new Fraction(7, 12);
        Console.WriteLine(n5.GetFraction());
        Console.WriteLine(n5.GetDecimal());
    }
}