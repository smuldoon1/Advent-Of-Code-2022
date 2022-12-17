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
            var a = GetPacketList(input[i][1..^1]);
        }
        return "";
    }

    public override string PartTwo(string[] input)
    {
        return "";
    }

    private static List<object> GetPacketList(string line)
    {
        var list = new List<object>();
        list.Add(Regex.Match(line, @"^[^\[|\]]*").Value.Split(',').Select(x => int.Parse(x)));
        int bracketIndex = line.IndexOfAny(new char[] { '[', ']' });
        if (bracketIndex != -1 && line[bracketIndex] == '[')
        {
            list.Add(GetPacketList(Regex.Match(line[1..], @"^[^\[|\]]*").Value));
        }
        return list;
    }
}