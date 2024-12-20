class Running : Activity
{
    private double distanceKm;

    public Running(string date, int durationMinutes, double distanceKm)
        : base(date, durationMinutes)
    {
        this.distanceKm = distanceKm;
    }

    public override double GetDistance()
    {
        return distanceKm;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / DurationMinutes) * 60;
    }

    public override double GetPace()
    {
        return DurationMinutes / GetDistance();
    }
}

