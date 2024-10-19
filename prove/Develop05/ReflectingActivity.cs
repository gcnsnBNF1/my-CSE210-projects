using System;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you overcame a personal fear.",
        "Think of a time when you inspired someone else.",
        "Think of a time when you took a significant risk.",
        "Think of a time when you experienced an unexpected kindness.",
        "Think of a time when you made a difficult decision.",
        "Think of a time when you had to adapt to a major change.",
        "Think of a time when you stood your ground.",
        "Think of a time when you found joy in a challenging situation.",
        "Think of a time when you learned something new about yourself.",
        "Think of a time when you made a positive impact on someone’s life."
    };
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
        "What motivated you to take that action?",
        "How did the outcome compare to your expectations?",
        "What was the most challenging part of this experience?",
        "How did others react to your actions?",
        "What personal values influenced your decisions during this experience?",
        "What skills or strengths did you discover or use during this experience?",
        "If you could change one thing about this experience, what would it be and why?",
        "How did this experience shape your future actions?",
        "What advice would you give to someone facing a similar situation?",
        "How did this experience affect your view of yourself or others?"
    };

    private Random _random = new Random();

    public ReflectingActivity(string name, string description)
        : base(name, description)
    {
    }

    public void Run()
    {
        int duration = GetDuration();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        Console.Clear();
        Console.WriteLine("Consider this prompt:");
        DisplayPrompt();
        Console.Write("When you have something in mind, press enter.\n");
        Console.ReadLine();

        Console.Clear();
        DisplayQuestions();
        while (DateTime.Now < endTime)
        {
            ShowSpinner(10);
            DisplayQuestions();
        }

        Console.WriteLine("\nFinished!!\n");
    }

    public string GetRandomPrompt()
    {
        int i = _random.Next(_prompts.Count);
        return _prompts[i];
    }

    public string GetRandomQuestion()
    {
        int i = _random.Next(_questions.Count);
        return _questions[i];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine($"\n --- {GetRandomPrompt()} --- \n");
    }

    public void DisplayQuestions()
    {
        Console.WriteLine($"> {GetRandomQuestion()}");
    }
}