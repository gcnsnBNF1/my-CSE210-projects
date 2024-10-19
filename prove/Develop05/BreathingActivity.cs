using System;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description)
        : base(name, description)
    {
    }

    public void Run()
    {
        int duration = GetDuration();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);
        
        Console.Clear();
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("\nBreathe in");
            ShowCountDown(4);

            Console.WriteLine("Hold it");
            ShowCountDown(7);

            Console.WriteLine("And breathe out");
            ShowCountDown(8);
        }
        
        Thread.Sleep(1000);
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', "And breath out".Length));
        Console.SetCursorPosition(0, Console.CursorTop);

        Console.WriteLine("Finished!!\n");
    }
}