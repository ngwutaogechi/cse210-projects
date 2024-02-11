//To exceeed requirment for this assignment, i added additional kinds of goals, such as making progress towards a large goal or incorporating "negative goals" where points are deducted for bad habits, in order to achieve this, i expanded the functionality of the Goal class and create new subclasses for these types of goals.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Base class for goals
abstract class Goal
{
    protected string name;
    protected int value;

    public Goal(string name, int value)
    {
        this.name = name;
        this.value = value;
    }

    public int Value => value; // Protected property to access value
    public string Name => name;
    public abstract void Complete();

    public virtual void ShowProgress()
    {
        Console.WriteLine($"Goal: {name}");
    }
}

// Simple goal class
class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value) : base(name, value)
    {
    }

    public override void Complete()
    {
        Console.WriteLine($"Completed {name}! You gained {Value} points.");
    }
}

// Eternal goal class
class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value)
    {
    }

    public override void Complete()
    {
        Console.WriteLine($"Performed {name}! You gained {Value} points.");
    }
}

// Checklist goal class
class ChecklistGoal : Goal
{
    private int target;
    private int completedCount = 0;

    public ChecklistGoal(string name, int value, int target) : base(name, value)
    {
        this.target = target;
    }

    public override void Complete()
    {
        completedCount++;
        Console.WriteLine($"Completed {name} ({completedCount}/{target})! You gained {Value} points.");

        if (completedCount == target)
        {
            Console.WriteLine($"Congratulations! You completed the checklist goal '{name}' and gained a bonus of {Value * 2} points.");
        }
    }

    public override void ShowProgress()
    {
        Console.WriteLine($"Goal: {name} (Completed {completedCount}/{target} times)");
    }
}

// Progress goal class for making progress towards a large goal
class ProgressGoal : Goal
{
    private int target;
    private int progress = 0;

    public ProgressGoal(string name, int value, int target) : base(name, value)
    {
        this.target = target;
    }

    public void MakeProgress(int amount)
    {
        progress += amount;
        if (progress >= target)
        {
            Console.WriteLine($"Congratulations! You reached the goal '{name}' and gained {Value} points.");
        }
        else
        {
            Console.WriteLine($"Progressed {name} ({progress}/{target})! You gained {Value} points.");
        }
    }

    public override void Complete()
    {
        // Progress goals are completed based on making progress, not by direct completion
        throw new InvalidOperationException("Progress goals are completed by making progress, not by direct completion.");
    }

    public override void ShowProgress()
    {
        Console.WriteLine($"Goal: {name} (Progress: {progress}/{target})");
    }
}

// Negative goal class for deducting points for bad habits
class NegativeGoal : Goal
{
    public NegativeGoal(string name, int value) : base(name, value)
    {
    }

    public override void Complete()
    {
        Console.WriteLine($"Oops! You indulged in {name} and lost {Value} points.");
    }
}

// Player class to manage goals and score
class Player
{
    private List<Goal> goals = new List<Goal>();
    private int score = 0;

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        var goal = goals.FirstOrDefault(g => g.Name == goalName);

        if (goal != null)
        {
            goal.Complete();
            score += goal.Value;
        }
        else
        {
            Console.WriteLine($"Goal '{goalName}' not found.");
        }
    }

    public void ShowGoalsProgress()
    {
        Console.WriteLine("Goals Progress:");
        foreach (var goal in goals)
        {
            goal.ShowProgress();
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"Current Score: {score}");
    }

    public void SaveProgress(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Value}");
            }
            writer.WriteLine($"Score,{score}");
        }
    }

    public void LoadProgress(string filename)
    {
        goals.Clear();
        score = 0;

        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts[0] == "SimpleGoal")
                    {
                        goals.Add(new SimpleGoal(parts[1], int.Parse(parts[2])));
                    }
                    else if (parts[0] == "EternalGoal")
                    {
                        goals.Add(new EternalGoal(parts[1], int.Parse(parts[2])));
                    }
                    else if (parts[0] == "ChecklistGoal")
                    {
                        goals.Add(new ChecklistGoal(parts[1], int.Parse(parts[2]), int.Parse(parts[3])));
                    }
                    else if (parts[0] == "ProgressGoal")
                    {
                        goals.Add(new ProgressGoal(parts[1], int.Parse(parts[2]), int.Parse(parts[3])));
                    }
                    else if (parts[0] == "NegativeGoal")
                    {
                        goals.Add(new NegativeGoal(parts[1], int.Parse(parts[2])));
                    }
                    else if (parts[0] == "Score")
                    {
                        score = int.Parse(parts[1]);
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File '{filename}' not found. Starting with a new progress.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading progress: {ex.Message}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Player player = new Player();

        // Load previous progress
        player.LoadProgress("progress.txt");

        while (true)
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals Progress");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save Progress");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Choose goal type:");
                    Console.WriteLine("1. Simple Goal");
                    Console.WriteLine("2. Eternal Goal");
                    Console.WriteLine("3. Checklist Goal");
                    Console.WriteLine("4. Progress Goal");
                    Console.WriteLine("5. Negative Goal");
                    int goalType = int.Parse(Console.ReadLine());
                    Console.Write("Enter goal name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter value: ");
                    int value = int.Parse(Console.ReadLine());
                    switch (goalType)
                    {
                        case 1:
                            player.AddGoal(new SimpleGoal(name, value));
                            break;
                        case 2:
                            player.AddGoal(new EternalGoal(name, value));
                            break;
                        case 3:
                            Console.Write("Enter target: ");
                            int target = int.Parse(Console.ReadLine());
                            player.AddGoal(new ChecklistGoal(name, value, target));
                            break;
                        case 4:
                            Console.Write("Enter target: ");
                            int progressTarget = int.Parse(Console.ReadLine());
                            player.AddGoal(new ProgressGoal(name, value, progressTarget));
                            break;
                        case 5:
                            player.AddGoal(new NegativeGoal(name, value));
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                    break;
                case 2:
                    Console.Write("Enter goal name to record event: ");
                    string goalName = Console.ReadLine();
                    player.RecordEvent(goalName);
                    break;
                case 3:
                    player.ShowGoalsProgress();
                    break;
                case 4:
                    player.ShowScore();
                    break;
                case 5:
                    player.SaveProgress("progress.txt");
                    Console.WriteLine("Progress saved.");
                    break;
                case 6:
                    player.SaveProgress("progress.txt");
                    Console.WriteLine("Progress saved. Exiting program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
