class Cycling : Activity
{
    private double speedKph;

    public Cycling(string date, int durationMinutes, double speedKph)
        : base(date, durationMinutes)
    {
        this.speedKph = speedKph;
    }

    public override double GetDistance()
    {
        return (speedKph * DurationMinutes) / 60;
    }

    public override double GetSpeed()
    {
        return speedKph;
    }

    public override double GetPace()
    {
        return 60 / GetSpeed();
    }
}



