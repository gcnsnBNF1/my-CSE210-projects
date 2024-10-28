using System;

public class Swimming : Activity
{
    private int _numberOfLaps;
    private const double _lapDistanceInMiles = 50.0 / 1609.34;

    public Swimming(DateTime dateTime, int minutes, int numberOfLaps) : base(dateTime, minutes)
    {
        _numberOfLaps = numberOfLaps;
    }

    public override string GetSummary()
    {
        DateTime date = GetDate();
        int minutes = GetMinutes();
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        string summary = $"{date.ToString("dd MMM yyyy")} Swimming ({minutes} min) - Distance: {distance:0.00} miles, Speed: {speed:0.00} mph, Pace: {pace:0.00} min per mile\n";
        return summary;
    }

    public override double GetDistance()
    {
        double distanceInMiles = _numberOfLaps * _lapDistanceInMiles;
        return distanceInMiles;
    }

    public override double GetSpeed()
    {
        double distance = GetDistance();
        int minutes = GetMinutes();

        double speedInMPH = (distance / minutes) * 60;
        return speedInMPH;
    }
        
    public override double GetPace()
    {
        int minutes = GetMinutes();
        double distance = GetDistance();

        double paceInMinPerMile = minutes / distance;
        return paceInMinPerMile;
    }
}