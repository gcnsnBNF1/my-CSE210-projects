using System;
using System.Diagnostics.Contracts;

public class ChecklistGoals : Goals
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoals(string shortName, string description, int points, 
        int target, int bonus) : base(shortName, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetails()
    {
        string shortName = GetName();
        string description = GetDescription();
        if (IsComplete())
        {
            return $"[X] {shortName} ({description}) - Currently completed: {_amountCompleted}/{_target}";
        }
        else
        {
            return $"[ ] {shortName} ({description}) - Currently completed: {_amountCompleted}/{_target}";
        }
    }

    public override string GetRepresentation()
    {
        string shortName = GetName();
        string description = GetDescription();
        int points = GetPoints();
        return $"ChecklistGoals:{shortName}:{description}:{points}:{_bonus}:{_target}:{_amountCompleted}";
    }

    public int AmountCompleted
    {
        get { return _amountCompleted; }
        set { _amountCompleted = value; }
    }

    public int GetBonus()
    {
        return _bonus;
    }
}