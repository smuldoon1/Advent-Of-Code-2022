using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Day
{
    public string InputPath { get; set; } = "";

    public Day(string inputPath, bool continueOnError = false)
    {
        InputPath = inputPath;
        string[] input = File.ReadAllLines(@$"F:\Advent-Of-Code-2022\C-Sharp-Solutions\{InputPath}.txt");
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        string day1 = PartOne(input);
        TimeSpan time1 = stopwatch.Elapsed;
        string day2 = PartTwo(input);
        TimeSpan time2 = stopwatch.Elapsed;
        stopwatch.Stop();
        PrintResult(day1, day2, time1, time2);
    }

    public abstract string PartOne(string[] input);

    public abstract string PartTwo(string[] input);

    public void PrintResult(string answer1, string answer2, TimeSpan time1, TimeSpan time2)
    {
        Console.WriteLine($"Solution for {InputPath}\nPart 1: {answer1} ({time1.Seconds}s)\nPart 2: {answer2} ({time2.Seconds}s)\n");
    }
}
