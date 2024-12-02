﻿var input = File.ReadAllLines("SampleFile.txt");

List<Report> reports = new List<Report>();

foreach (var line in input)
{
    reports.Add(new Report(line));
}

Console.WriteLine(reports.Count(r => r.Safe()));
Console.ReadLine();


public class Report
{
    public Report(string line)
    {
        Levels = new List<int>();

        var elements = line.Split(" ");

        foreach (var element in elements)
        {
            Levels.Add(int.Parse(element));
        }
    }

    List<int> Levels { get; set; }

    private bool AllAscending()
    {
        return Levels == Levels.OrderBy(e => e);
    }

    private bool AllDescending()
    {
        return Levels == Levels.OrderByDescending(e => e);
    }

    private bool HasGaps()
    {
        var elements = Levels.ToArray();

        for (int i = 0; i < elements.GetLength(0); i++)
        {
            var diff = Math.Abs(elements[i] - elements[i + 1]);

            if (diff < 1 || diff > 3)
            {
                return true;
            }
        }

        return false;
    }

    public bool Safe()
    {
        return (AllAscending() || AllDescending()) && !HasGaps();
    }
}