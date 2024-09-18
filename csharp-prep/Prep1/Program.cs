using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What's your first name? ");
        string fname = Console.ReadLine();

        Console.Write("What's your last name? ");
        string lname = Console.ReadLine();

        Console.WriteLine($"Your name is {lname}, {fname} {lname}.");
    }
}