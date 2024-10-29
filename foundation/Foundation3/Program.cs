using System;
using System.Collections.Generic;
using System.Linq;

// Base Activity class
public abstract class Activity
{
    private DateTime _date;
    private int _lengthInMinutes;
    private string _notes; // New: Added notes field for user comments

    public Activity(DateTime date, int lengthInMinutes, string notes = "")
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
        _notes = notes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} {GetType().Name} ({_lengthInMinutes} min)- " +
               $"Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile" +
               (_notes != "" ? $"\nNotes: {_notes}" : "");
    }

    protected int GetLengthInMinutes()
    {
        return _lengthInMinutes;
    }

    // New: Calculate calories burned (to be overridden in derived classes)
    public abstract int CalculateCaloriesBurned();
}

public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int lengthInMinutes, double distance, string notes = "") 
        : base(date, lengthInMinutes, notes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / GetLengthInMinutes()) * 60;
    public override double GetPace() => GetLengthInMinutes() / _distance;

    // New: Calculate calories burned for running
    public override int CalculateCaloriesBurned() => (int)(GetLengthInMinutes() * 11.4); // Assuming 11.4 calories per minute
}

public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int lengthInMinutes, double speed, string notes = "") 
        : base(date, lengthInMinutes, notes)
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed * GetLengthInMinutes()) / 60;
    public override double GetSpeed() => _speed;
    public override double GetPace() => 60 / _speed;

    // New: Calculate calories burned for cycling
    public override int CalculateCaloriesBurned() => (int)(GetLengthInMinutes() * 7.5); // Assuming 7.5 calories per minute
}

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int lengthInMinutes, int laps, string notes = "") 
        : base(date, lengthInMinutes, notes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 50 / 1000 * 0.62;
    public override double GetSpeed() => (GetDistance() / GetLengthInMinutes()) * 60;
    public override double GetPace() => GetLengthInMinutes() / GetDistance();

    // New: Calculate calories burned for swimming
    public override int CalculateCaloriesBurned() => (int)(GetLengthInMinutes() * 8.3); // Assuming 8.3 calories per minute
}

// New: FitnessTracker class to manage activities and provide statistics
public class FitnessTracker
{
    private List<Activity> _activities = new List<Activity>();

    public void AddActivity(Activity activity)
    {
        _activities.Add(activity);
    }

    public void DisplayAllActivities()
    {
        foreach (var activity in _activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine($"Calories Burned: {activity.CalculateCaloriesBurned()}");
            Console.WriteLine();
        }
    }

    public void DisplayStatistics()
    {
        Console.WriteLine("Fitness Statistics:");
        Console.WriteLine($"Total Activities: {_activities.Count}");
        Console.WriteLine($"Total Distance: {_activities.Sum(a => a.GetDistance()):F1} miles");
        Console.WriteLine($"Total Calories Burned: {_activities.Sum(a => a.CalculateCaloriesBurned())}");
        Console.WriteLine($"Most Common Activity: {_activities.GroupBy(a => a.GetType().Name).OrderByDescending(g => g.Count()).First().Key}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        FitnessTracker tracker = new FitnessTracker();

        tracker.AddActivity(new Running(new DateTime(2022, 11, 3), 30, 3.0, "Felt great today!"));
        tracker.AddActivity(new Cycling(new DateTime(2022, 11, 4), 45, 15.0, "Windy but enjoyable"));
        tracker.AddActivity(new Swimming(new DateTime(2022, 11, 5), 60, 40, "Worked on my freestyle"));
        tracker.AddActivity(new Running(new DateTime(2022, 11, 6), 25, 2.5, "Short recovery run"));

        tracker.DisplayAllActivities();
        tracker.DisplayStatistics();
    }
}