using System;
using System.ComponentModel.Design;
using System.Collections.Generic;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        string loadingMessage = "Loading: ";
        while (true)
        {
            ShowMenu();

            Console.Write("Select from the menu: ");
            string userInput = Console.ReadLine();

            int selection;
            if(int.TryParse(userInput, out selection))
            {
                Console.Clear();
                switch (selection)
                {
                    case 1:
                        BreathingActivity breathingActivity = new BreathingActivity("Breathing Activity",
                            "In this session, we'll calm our minds by taking deep breaths. We'll inhale for 4 seconds, hold it for 7 seconds, and exhale for 8 seconds.");
                        breathingActivity.DisplayStartingMessage();
                        Console.Write(loadingMessage);
                        breathingActivity.ShowSpinner(5);
                        breathingActivity.ClearLoadingMessage(loadingMessage);
                        breathingActivity.Run();
                        breathingActivity.DisplayEndingMessage();
                        Console.Write(loadingMessage);
                        breathingActivity.ShowSpinner(5);
                        breathingActivity.ClearLoadingMessage(loadingMessage);
                        break;

                    case 2:
                        ReflectingActivity reflectingActivity = new ReflectingActivity("Reflecting Activity", 
                            "This session will help you reflect on times when you've shown strength. Helping you recognize the power you really have and how you can apply it in the future.");
                        reflectingActivity.DisplayStartingMessage();
                        Console.Write(loadingMessage);
                        reflectingActivity.ShowSpinner(5);
                        reflectingActivity.ClearLoadingMessage(loadingMessage);
                        reflectingActivity.Run();
                        reflectingActivity.DisplayEndingMessage();
                        Console.Write(loadingMessage);
                        reflectingActivity.ShowSpinner(5);
                        reflectingActivity.ClearLoadingMessage(loadingMessage);
                        break;

                    case 3:
                        ListingActivity listingActivity = new ListingActivity("Listing Activity", 
                            "The session will help you realize the good things that have happened in your life by listing as much as you can in a specific category.");
                        listingActivity.DisplayStartingMessage();
                        Console.Write(loadingMessage);
                        listingActivity.ShowSpinner(5);
                        listingActivity.ClearLoadingMessage(loadingMessage);
                        listingActivity.Run();
                        listingActivity.DisplayEndingMessage();
                        Console.Write(loadingMessage);
                        listingActivity.ShowSpinner(5);
                        listingActivity.ClearLoadingMessage(loadingMessage);
                        break;
                    
                    case 4:
                        Console.WriteLine("Quitting the program.");
                        return;

                    default:
                        Console.WriteLine("Invalid number. Please try again.");
                        break;
                }
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number");
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("   1. Start breathing activity");
        Console.WriteLine("   2. Start reflecting activity");
        Console.WriteLine("   3. Start listing activity");
        Console.WriteLine("   4. Quit\n");
    }
}