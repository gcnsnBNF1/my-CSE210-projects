using System;

public abstract class Goals
{
    private string _shortName;
    private string _description;
    private int _points;

    public Goals(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetails()
    {
        if (IsComplete())
        {
            return $"[X] {_shortName} ({_description})";
        }
        else
        {
            return $"[ ] {_shortName} ({_description})";
        }
    }

    public abstract string GetRepresentation();

    public string GetName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }
}