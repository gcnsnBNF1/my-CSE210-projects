using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private List<Goals> _goals = new List<Goals>();
    private int _score;
    private int _xp;
    private int _level;
    private int _xpToNextLevel;

    private readonly string[] _ranks = 
        { "Novice", "Rookie", "Explorer", "Adventurer", "Pathfinder",
        "Champion", "Master", "Grandmaster", "Legend", "Mythic" };

    public GoalManager()
    {
        _level = 1;
        _xp = 0;
        _xpToNextLevel = 100;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine($"\nYou have {_score} points.");
            Console.WriteLine($"Your current level is {_level}.");
            Console.WriteLine($"{_ranks[_level - 1]} is your rank.");

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            Console.Write("Select a choice from the menu: ");
            string menuInput = Console.ReadLine();
            int menuSelection;

            if (int.TryParse(menuInput, out menuSelection))
            {
                switch(menuSelection)
                {
                    case 1:
                        CreateGoal();
                        break;
                    
                    case 2:
                        ListGoalDetails();
                        break;

                    case 3:
                        SaveGoals();
                        break;

                    case 4:
                        LoadGoals();
                        break;

                    case 5:
                        RecordEvent();
                        break;

                    case 6:
                        Console.WriteLine("Quiting the program.\n");
                        return;

                    default:
                        Console.WriteLine("Invalid number. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        
    }

    public void DisplayPlayerInfo(int rewardPoints)
    {
        Console.WriteLine($"\nYou've been rewarded {rewardPoints} points and XP.");
        AddXP(rewardPoints);
    }

    public void ListGoalDetails()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetails()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThere are three types of Goals:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        
        Console.Write("Which of these would you like to make? ");
        string goalInput = Console.ReadLine();
        int goalSelection;

        if (int.TryParse(goalInput, out goalSelection))
        {
            switch(goalSelection)
            {
                case 1:
                    Console.Write("What's your goal's name? ");
                    string simpleGoalName = Console.ReadLine();

                    Console.Write("Give a short description of your goal: ");
                    string simpleGoalDescription = Console.ReadLine();

                    Console.Write("How many points is your goal worth? ");
                    string simpleGoalPoints = Console.ReadLine();
                    int simplePoints = int.Parse(simpleGoalPoints);

                    SimpleGoals simpleGoal = new SimpleGoals(simpleGoalName, simpleGoalDescription, simplePoints);
                    _goals.Add(simpleGoal);
                    break;

                case 2:
                    Console.Write("What's your goal's name? ");
                    string eternalGoalName = Console.ReadLine();

                    Console.Write("Give a short description of your goal: ");
                    string eternalGoalDescription = Console.ReadLine();

                    Console.Write("How many points is your goal worth? ");
                    string eternalGoalPoints = Console.ReadLine();
                    int eternalPoints = int.Parse(eternalGoalPoints);

                    EternalGoals eternalGoal = new EternalGoals(eternalGoalName, eternalGoalDescription, eternalPoints);
                    _goals.Add(eternalGoal);
                    break;

                case 3:
                    Console.Write("What's your goal's name? ");
                    string checkGoalName = Console.ReadLine();

                    Console.Write("Give a short description of your goal: ");
                    string checkGoalDescription = Console.ReadLine();

                    Console.Write("How many points is your goal worth? ");
                    string checkGoalPoints = Console.ReadLine();
                    int checklistPoints = int.Parse(checkGoalPoints);

                    Console.Write("How many times must this goal be completed to get the bonus? ");
                    string checkGoalTarget = Console.ReadLine();
                    int checklistTarget = int.Parse(checkGoalTarget);

                    Console.Write($"What bonus should you get for completing it {checklistTarget} times? ");
                    string checkGoalBonus = Console.ReadLine();
                    int checklistBonus = int.Parse(checkGoalBonus);

                    ChecklistGoals checklistGoal = new ChecklistGoals
                        (checkGoalName, checkGoalDescription, checklistPoints, checklistTarget, checklistBonus);
                    _goals.Add(checklistGoal);
                    break;

                default:
                    Console.WriteLine("Invalid number.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }

    public void RecordEvent()
    {
        Console.Write("Which goal have you completed? ");
        string input = Console.ReadLine();
        int completedGoal;

        if (int.TryParse(input, out completedGoal) && completedGoal > 0 && completedGoal <= _goals.Count)
        {
            Goals goal = _goals[completedGoal - 1];
            int newPoints = goal.GetPoints();
            goal.RecordEvent();
            if (goal is EternalGoals || goal.IsComplete())
            {
                _score += newPoints;
                if (goal is ChecklistGoals checklistGoal && checklistGoal.IsComplete())
            {
                _score += checklistGoal.GetBonus();
                newPoints += checklistGoal.GetBonus();
            }
            }
            DisplayPlayerInfo(newPoints);
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What's the name of the file you'd like to save to? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            outputFile.WriteLine(_xp);
            outputFile.WriteLine(_level);
            foreach (Goals goal in _goals)
            {
                outputFile.WriteLine(goal.GetRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        _goals.Clear();

        Console.Write("What's the name of the file you'd like to load? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _xp = int.Parse(lines[1]);
            _level = int.Parse(lines[2]);

            for (int i = 3; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string goalType = parts[0];
                string goalName = parts[1];
                string goalDescription = parts[2];
                int goalPoints = int.Parse(parts[3]);

                if (goalType == "SimpleGoals")
                {
                    _goals.Add(new SimpleGoals(goalName, goalDescription, goalPoints));
                }
                else if (goalType == "EternalGoals")
                {
                    _goals.Add(new EternalGoals(goalName, goalDescription, goalPoints));
                }
                else if (goalType == "ChecklistGoals")
                {
                    int bonus = int.Parse(parts[4]);
                    int target = int.Parse(parts[5]);
                    int amountCompleted = int.Parse(parts[6]);
                    _goals.Add(new ChecklistGoals(goalName, goalDescription, goalPoints, target, bonus) {AmountCompleted = amountCompleted});
                }
            }
        }
        else
        {
            Console.WriteLine("File not found. Please check the filename and try again.");
        }
    }

    private void AddXP(int xp)
    {
        _xp += xp;
        if (_xp >= _xpToNextLevel)
        {
            _level++;
            _xp -= _xpToNextLevel;
            _xpToNextLevel += 100;
            if (_level % 2 == 0)
            {
                Console.WriteLine($"Congratulations! You've reached Level {_level} and earned the rank of {_ranks[(_level / 2) - 1]}!");
            }
            else
            {
                Console.WriteLine($"Congratulations! You've reached Level {_level}!");
            }
        }
    }
}