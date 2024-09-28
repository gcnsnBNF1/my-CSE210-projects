using System;
using System.IO.Enumeration;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to my Journal Program!");

        Journal newJournal = new Journal();
        int selectionNumber = 0;

        do {
            Console.WriteLine("Please select one of the following choices:\n1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            Console.Write("What would you like to do? ");
            string typeSelection = Console.ReadLine();

            if (int.TryParse(typeSelection, out selectionNumber))
            {
                if (selectionNumber == 1)
                {
                    Entry nextEntry = new Entry();

                    DateTime theDateAndTime = DateTime.Now;
                    nextEntry._date = theDateAndTime.ToShortDateString();

                    PromptGenerator prompt1 = new PromptGenerator();
                    nextEntry._promptText = prompt1.GetRandomPrompt();
                    string newPrompt = nextEntry._promptText;

                    Console.WriteLine(newPrompt);
                    Console.Write("> ");
                    nextEntry._entryText = Console.ReadLine();

                    newJournal.AddEntry(nextEntry);
                }
                else if (selectionNumber == 2)
                {
                    newJournal.DisplayAll();
                }
                else if (selectionNumber == 3)
                {
                    Console.Write("What is the file name? ");
                    string fileName = Console.ReadLine();

                    newJournal.LoadFromFile(fileName);
                }
                else if (selectionNumber == 4)
                {
                    Console.Write("What is the file name? ");
                    string fileName = Console.ReadLine();

                    newJournal.SaveToFile(fileName);
                }
                else if (selectionNumber != 5)
                {
                    Console.WriteLine("Invalid selection. Number does not exist in list");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        } while (selectionNumber != 5);
        
        Console.WriteLine("Thank you for using my Journal program. Have a SUPER great day!");
    }
}