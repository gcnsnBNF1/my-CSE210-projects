using System;

class Program
{
    static void Main(string[] args)
    {
        string message = $"Hold on......";
        int dotCount = 6;

        Console.WriteLine("\n");
        Console.Write(message);
        
        for (int i = message.Length - 1; i >= message.Length - dotCount; i--)
        {
            Thread.Sleep(1000);
            Console.SetCursorPosition(i, Console.CursorTop);
            Console.Write(" ");
        }

        Thread.Sleep(1000);
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', message.Length));
        Console.SetCursorPosition(0, Console.CursorTop - 1);

        Console.WriteLine("Finished.");

        // string message = $"Waiting: ";
        // Console.Write(message);

        // List<string> animation = new List<string>
        // {
            // "|", "/", "-", "\\"
        // };

        // DateTime startTime = DateTime.Now;
        // DateTime futureTime = startTime.AddSeconds(10);

        // int i = 0;

        // do
        // {
            // string frame = animation[i % animation.Count];
            // Console.Write(frame);
            // Thread.Sleep(250);
            // Console.Write("\b \b");
            // i++;

        // } while(DateTime.Now < futureTime);

        // Console.SetCursorPosition(0, Console.CursorTop);
        // Console.Write(new string(' ', message.Length));
        // Console.SetCursorPosition(0, Console.CursorTop);

        // Console.WriteLine("Finished.");
    }
}