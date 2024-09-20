using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string user = PromptUserName();
        int userNumber = PromptUserNumber();

        int numberSquared = SquareNumber(userNumber);

        DisplayResult(user, numberSquared);
    }

    static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string usersName = Console.ReadLine();
            return usersName;
        }

        static int PromptUserNumber()
        {
            Console.Write("What's your favorite number? ");
            int favoriteNumber = int.Parse(Console.ReadLine());
            
            return favoriteNumber;
        }

        static int SquareNumber(int number)
        {
            int squareNumber = number * number;

            return squareNumber;
        }

        static void DisplayResult(string name, int number)
        {
            Console.WriteLine($"Hello, {name}, the square of your number is {number}");
        }
}