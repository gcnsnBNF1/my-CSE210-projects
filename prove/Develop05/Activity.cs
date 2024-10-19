using System;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 60;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}.\n \n{_description}\n \nEach session lasts {_duration} seconds.\n");
        Console.Write("Press enter when your ready: ");
        Console.ReadLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"You've completed another {_name}.");
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animation = new List<string>
        {
            "|", "/", "-", "\\"
        };

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);

        int i = 0;

        do
        {
            string frame = animation[i % animation.Count];
            Console.Write(frame);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;

        } while(DateTime.Now < futureTime);

        ClearLoadingMessage(new string(' ', 1));
    }

    public void ShowCountDown(int seconds)
    {
        string dots = new string('.', seconds);
        Console.Write(dots);
        
        for (int i = dots.Length - 1; i >= 0; i--)
        {
            Thread.Sleep(1000);
            Console.SetCursorPosition(i, Console.CursorTop);
            Console.Write(" ");
        }
        Console.SetCursorPosition(0, Console.CursorTop);
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void ClearLoadingMessage(string message)
    {
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', message.Length));
        Console.SetCursorPosition(0, Console.CursorTop);
    }
}