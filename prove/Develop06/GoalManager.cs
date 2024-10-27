using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private int _streak;
    private List<string> _achievements;
    private Dictionary<string, List<Goal>> _categories;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _streak = 0;
        _achievements = new List<string>();
        _categories = new Dictionary<string, List<Goal>>();
    }

    public void Start()
    {
        bool quit = false;
        while (!quit)
        {
            Console.WriteLine("\n--- Eternal Quest ---");
            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Display Player Info");
            Console.WriteLine("  7. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    DisplayPlayerInfo();
                    break;
                case "7":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal;

        switch (type)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        Console.Write("Enter a category for this goal (or press Enter for no category): ");
        string category = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(category))
        {
            if (!_categories.ContainsKey(category))
            {
                _categories[category] = new List<Goal>();
            }
            _categories[category].Add(newGoal);
        }

        _goals.Add(newGoal);
        Console.WriteLine("Goal created successfully!");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        foreach (var category in _categories)
        {
            Console.WriteLine($"\nCategory: {category.Key}");
            foreach (var goal in category.Value)
            {
                Console.WriteLine($"  {goal.GetDetailsString()}");
            }
        }

        Console.WriteLine("\nUncategorized Goals:");
        foreach (var goal in _goals)
        {
            if (!_categories.Values.Any(list => list.Contains(goal)))
            {
                Console.WriteLine($"  {goal.GetDetailsString()}");
            }
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            goal.RecordEvent();
            int points = goal.GetPoints();
            _score += points;
            _streak++;
            Console.WriteLine($"Congratulations! You have earned {points} points!");
            Console.WriteLine($"You now have {_score} points.");
            
            CheckLevelUp();
            CheckAchievements();
            Console.WriteLine($"Current streak: {_streak} days");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
            _streak = 0;
            Console.WriteLine("Streak reset to 0 days");
        }
    }

    private void CheckLevelUp()
    {
        int newLevel = 1 + (_score / 1000);
        if (newLevel > _level)
        {
            Console.WriteLine($"Level Up! You are now level {newLevel}!");
            _level = newLevel;
        }
    }

    private void CheckAchievements()
    {
        if (_goals.Count >= 5 && !_achievements.Contains("Goal Setter"))
        {
            _achievements.Add("Goal Setter");
            Console.WriteLine("Achievement Unlocked: Goal Setter - Create 5 goals");
        }

        if (_streak >= 7 && !_achievements.Contains("Week Warrior"))
        {
            _achievements.Add("Week Warrior");
            Console.WriteLine("Achievement Unlocked: Week Warrior - Maintain a 7-day streak");
        }

        if (_score >= 5000 && !_achievements.Contains("Point Master"))
        {
            _achievements.Add("Point Master");
            Console.WriteLine("Achievement Unlocked: Point Master - Reach 5000 points");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"{_score},{_level},{_streak}");
            outputFile.WriteLine(string.Join(",", _achievements));
            foreach (var category in _categories)
            {
                outputFile.WriteLine($"Category:{category.Key}");
                foreach (var goal in category.Value)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            outputFile.WriteLine("Uncategorized:");
            foreach (var goal in _goals)
            {
                if (!_categories.Values.Any(list => list.Contains(goal)))
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        _goals.Clear();
        _categories.Clear();

        string[] lines = System.IO.File.ReadAllLines(filename);

        string[] playerInfo = lines[0].Split(",");
        _score = int.Parse(playerInfo[0]);
        _level = int.Parse(playerInfo[1]);
        _streak = int.Parse(playerInfo[2]);

        _achievements = lines[1].Split(",").ToList();

        string currentCategory = "";
        for (int i = 2; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("Category:"))
            {
                currentCategory = lines[i].Substring(9);
                _categories[currentCategory] = new List<Goal>();
            }
            else if (lines[i] == "Uncategorized:")
            {
                currentCategory = "";
            }
            else
            {
                Goal goal = CreateGoalFromString(lines[i]);
                _goals.Add(goal);
                if (!string.IsNullOrEmpty(currentCategory))
                {
                    _categories[currentCategory].Add(goal);
                }
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }

    private Goal CreateGoalFromString(string goalString)
    {
        string[] parts = goalString.Split(":");
        string[] goalData = parts[1].Split(",");

        Goal goal;
        switch (parts[0])
        {
            case "SimpleGoal":
                goal = new SimpleGoal(goalData[0], goalData[1], int.Parse(goalData[2]));
                if (bool.Parse(goalData[3]))
                {
                    goal.RecordEvent();
                }
                break;
            case "EternalGoal":
                goal = new EternalGoal(goalData[0], goalData[1], int.Parse(goalData[2]));
                break;
            case "ChecklistGoal":
                goal = new ChecklistGoal(goalData[0], goalData[1], int.Parse(goalData[2]), int.Parse(goalData[3]), int.Parse(goalData[4]));
                for (int j = 0; j < int.Parse(goalData[5]); j++)
                {
                    goal.RecordEvent();
                }
                break;
            default:
                Console.WriteLine($"Unknown goal type: {parts[0]}");
                return null;
        }

        return goal;
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\n--- Player Info ---");
        Console.WriteLine($"Level: {_level}");
        Console.WriteLine($"Score: {_score}");
        Console.WriteLine($"Current Streak: {_streak} days");
        Console.WriteLine("\nAchievements:");
        foreach (var achievement in _achievements)
        {
            Console.WriteLine($"  {achievement}");
        }
    }
}