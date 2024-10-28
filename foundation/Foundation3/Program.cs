using System;

class Program
{
    static void Main(string[] args)
    {
        DateTime currentDate = DateTime.Now;

        List<Activity> activities = new List<Activity>
        {
            new Swimming(currentDate, 30, 10),
            new Running(currentDate, 60, 10.11),
            new Cycling(currentDate, 90, 7.75),
            new Swimming(currentDate, 120, 15),
            new Running(currentDate, 150, 15.15),
            new Cycling(currentDate, 180, 7.75)
        };

        for (int i = 0; i < activities.Count; i++)
        {
            Console.WriteLine(activities[i].GetSummary());
        }
    }
}