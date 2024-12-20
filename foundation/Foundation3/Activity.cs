abstract class Activity
{
    private string _date;
    private int _durationMinutes;

    protected Activity(string date, int durationMinutes)
    {
        _date = date;
        _durationMinutes = durationMinutes;
    }

    public string Date => _date;
    public int DurationMinutes => _durationMinutes;

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public string GetSummary()
    {
        return $"{Date} {GetType().Name} ({DurationMinutes} min): " +
               $"Distance: {GetDistance():F2} km, Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
    }
}



