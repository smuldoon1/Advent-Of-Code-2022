// Part 1 - 15m 57s 30
// Part 2 - 16m 49s 46
class Day6 : Day
{
    public Day6(string inputPath, bool continueOnError = false) : base(inputPath, continueOnError)
    {
    }

    public override string PartOne(string[] input)
    {
        return GetMarker(input[0], 4).ToString();
    }

    public override string PartTwo(string[] input)
    {
        return GetMarker(input[0], 14).ToString();
    }

    static int GetMarker(string str, int length)
    {
        for (int i = length - 1; i < str.Length; i++)
        {
            var substring = str.Substring(i - length + 1, length);
            if (IsMarker(substring))
                return ++i;
        }
        return -1;
    }

    static bool IsMarker(string substring)
    {
        foreach (char c in substring)
            if (substring.Count(x => x == c) > 1)
                return false;
        return true;
    }
}