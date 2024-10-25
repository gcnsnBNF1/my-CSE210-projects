using System;
using System.Xml.Schema;

public class SimpleGoals : Goals
{
    private bool _isComplete;

    public SimpleGoals(string shortName, string description, int points) : base(shortName, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetRepresentation()
    {
        string shortName = GetName();
        string description = GetDescription();
        int points = GetPoints();
        return $"SimpleGoals:{shortName}:{description}:{points}:{_isComplete}";
    }
}