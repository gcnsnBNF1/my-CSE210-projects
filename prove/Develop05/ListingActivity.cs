using System;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        "Who is someone who has inspired you recently?",
        "What was a moment that made you feel proud?",
        "Who is someone you would like to thank and why?",
        "What is a challenge you overcame recently?",
        "What is something you learned this week?",
        "How did you make someone’s day better recently?",
        "What is a goal you achieved and how did you do it?",
        "Who has been a positive influence in your life?",
        "What is a recent act of kindness you witnessed or performed?",
        "What is a personal accomplishment you're proud of?",
        "Who is someone you helped this month?",
        "What is a lesson you learned the hard way?",
        "How did you support a friend in need?",
        "What is a meaningful experience you had recently?",
        "What is a new skill you developed?"
    };
    private Random _random = new Random();

    public ListingActivity(string name, string description)
        : base(name, description)
    {
    }

    public void Run()
    {
        Console.Clear();
        Console.WriteLine("List as responses to this prompt as you can:");
        Console.WriteLine($" --- {GetRandomPrompt()} --- \n");
        Console.Write("You may begin in\n");
        ShowCountDown(5);

        Thread.Sleep(1000);
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.Write(new string(' ', "You may begin in\n".Length + 1));
        Console.SetCursorPosition(0, Console.CursorTop - 1);

        Console.WriteLine("\nYou may begin\n");
        List<string> responses = GetListFromUser();

        Console.WriteLine($"You listed {responses.Count} items!\n");
        Console.WriteLine("Finished!!\n");
    }

    public string GetRandomPrompt()
    {
        int i = _random.Next(_prompts.Count);
        return _prompts[i];
    }

    public List<string> GetListFromUser()
    {
        int count = GetDuration();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(count);

        List<string> answers = new List<string>();
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string answer = Console.ReadLine();
            if (!string.IsNullOrEmpty(answer))
            {
                answers.Add(answer);
            }
        }

        return answers;
    }
}