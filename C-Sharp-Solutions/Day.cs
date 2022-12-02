using System;
using System.Collections.Generic;
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
        try
        {
            int day1 = PartOne(input);
            int day2 = PartTwo(input);
            PrintResult(day1, day2);
        }
        catch
        {
            if (!continueOnError)
                throw;
            Console.WriteLine($"An error occured when solving {InputPath}\n");
        }
    }

    public abstract int PartOne(string[] input);

    public abstract int PartTwo(string[] input);

    public void PrintResult(int answer1, int answer2)
    {
        Console.WriteLine($"Solution for {InputPath}\nPart 1: {answer1}\nPart 2: {answer2}\n");
    }
}
