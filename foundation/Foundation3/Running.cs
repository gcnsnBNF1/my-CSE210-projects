using System;

public class Running : Activity
{
    private double _distance;

    public Running(DateTime dateTime, int minutes, double distance) : base(dateTime, minutes)
    {
        _distance = distance;
    }

    public override string GetSummary()
    {
        DateTime date = GetDate();
        int minutes = GetMinutes();
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        string summary = $"{date.ToString("dd MMM yyyy")} Running ({minutes} min) - Distance: {distance:0.00} miles, Speed: {speed:0.00} mph, Pace: {pace:0.00} min per mile\n";
        return summary;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        int minutes = GetMinutes();
        
        double speedInMPH = (_distance / minutes) * 60;
        return speedInMPH;
    }

    public override double GetPace()
    {
        double speed = GetSpeed();

        double paceInMinPerMile = 60 / speed;
        return paceInMinPerMile;
    }
}