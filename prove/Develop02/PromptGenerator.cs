using System;

public class PromptGenerator
{
    public List<string> _prompts = new List<string> 
        {"What was the best part of my day?", "If I had one thing I could do over today, what would it be?",
        "What kind of exercise did I get today?", "What sort of story ideas did I come up with today?",
        "How did I see the hand of the Lord in my life today?", "What time did I get up today?"};

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}