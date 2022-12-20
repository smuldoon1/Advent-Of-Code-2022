using System.Text.RegularExpressions;

public static class Utils
{
    public static int Mod(int a, int b) => ((a % b) + b) % b;

    public static long Mod(long a, long b) => ((a % b) + b) % b;

    public static int[] GetInts(string line) => Regex.Split(line, @"[^0-9-]+").Skip(1).Select(x => int.Parse(x)).ToArray();

    public static int GetInt(string line) => GetInts(line).Single();
} 
