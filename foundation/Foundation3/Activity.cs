using System;

public abstract class Activity
{
    private DateTime _dateTime;
    private int _minutes;

    public Activity(DateTime dateTime, int minutes)
    {
        _dateTime = dateTime;
        _minutes = minutes;
    }

    public DateTime GetDate()
    {
        return _dateTime;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public abstract string GetSummary();
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
}