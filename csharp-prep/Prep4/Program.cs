using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int inputNumber;
        do
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            inputNumber = int.Parse(input);
            
            if (inputNumber != 0)
            {
                numbers.Add(inputNumber);
            }

        } while (inputNumber != 0);

        int listSum = 0;
        foreach (int number in numbers)
        {
            listSum += number;
        }

        int listAmount = numbers.Count;
        float listAverage = listSum / (float)listAmount;
        int listMaxNumber = numbers.Max();

        Console.WriteLine($"The sum is: {listSum}");
        Console.WriteLine($"The average is: {listAverage}");
        Console.WriteLine($"The largest number is: {listMaxNumber}");
    }
}