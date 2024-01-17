// Resume.cs

using System;
using System.Collections.Generic;

public class Resume
{
    // Member variables
    private string _personName;
    private List<Job> _jobs;

    // Constructor
    public Resume(string personName)
    {
        _personName = personName;
        _jobs = new List<Job>();
    }

    // Add a job to the list of jobs
    public void AddJob(Job job)
    {
        _jobs.Add(job);
    }

    // Display resume details
    public void Display()
    {
        Console.WriteLine($"Name: {_personName}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}
