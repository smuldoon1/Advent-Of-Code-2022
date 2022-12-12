using System.Text.RegularExpressions;

public static class Utils
{
    public static int Mod(int a, int b) => ((a % b) + b) % b;

    public static int[] GetInts(string line) => Regex.Split(line, @"\D+").Skip(1).Select(x => int.Parse(x)).ToArray();

    public static int GetInt(string line) => int.Parse(Regex.Match(line, @"\d+").Value);
} 
