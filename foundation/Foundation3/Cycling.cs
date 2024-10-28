using System;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime dateTime, int minutes, double speed) : base(dateTime, minutes)
    {
        _speed = speed;
    }

    public override string GetSummary()
    {
        DateTime date = GetDate();
        int minutes = GetMinutes();
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        string summary = $"{date.ToString("dd MMM yyyy")} Cycling ({minutes} min) - Distance: {distance:0.00} miles, Speed: {speed:0.00} mph, Pace: {pace:0.00} min per mile\n";
        return summary;
    }

    public override double GetDistance()
    {
        int minutes = GetMinutes();
        
        double distance = _speed * (minutes / 60);
        return distance;
    }
    public override double GetSpeed()
    {
        return _speed;
    }
    public override double GetPace()
    {
        double pace = 60 / _speed;
        return pace;
    }
}