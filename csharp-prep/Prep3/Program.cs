using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);
        Console.WriteLine("I'm thinking of a number between 1 and 100");

        int guessNumber;
        do
        {
            Console.Write("What do you guess? ");
            string guess = Console.ReadLine();
            guessNumber = int.Parse(guess);

            if (guessNumber < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guessNumber > magicNumber)
            {
                Console.WriteLine("Lower");
            }
        } while (guessNumber != magicNumber);

        if (guessNumber == magicNumber)
        {
            Console.WriteLine("Hooray! You guessed it!");
        }
    }
}