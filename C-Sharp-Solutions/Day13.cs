// Part 1 - 
// Part 2 - 

using System.Text.RegularExpressions;

class Day13 : Day
{
    public Day13(string inputPath, bool continueOnError = false) : base(inputPath, continueOnError)
    {
    }

    public override string PartOne(string[] input)
    {
        for (int i = 0; i < input.Length; i += 3)
        {
            int depth = 0;
            int cursor = 0;
            while (true)
            {
                string a = Regex.Match(input[i].Substring(cursor), @".(\d+)?").Value;
                string b = Regex.Match(input[i+1].Substring(cursor), @".(\d+)?").Value;
                if (a == "[" && b == "[")
                {
                    depth++;
                    cursor++;
                }
            }
        }
        return "";
    }

    public override string PartTwo(string[] input)
    {
        return "";
    }
}