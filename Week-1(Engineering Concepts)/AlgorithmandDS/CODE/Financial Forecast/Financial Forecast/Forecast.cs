using System;

class Forecast
{
    public static double Predict(double value, double rate, int years)
    {
        if (years == 0) return value;
        return Predict(value * (1 + rate), rate, years - 1);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine(Forecast.Predict(1000, 0.1, 3));
    }
}
