using System;

public class EternalGoals : Goals
{
    public EternalGoals(string shortName, string description, int points) : base(shortName, description, points)
    {}

    public override void RecordEvent()
    {}

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetRepresentation()
    {
        string shortName = GetName();
        string description = GetDescription();
        int points = GetPoints();
        return $"EternalGoals:{shortName}:{description}:{points}";
    }
}