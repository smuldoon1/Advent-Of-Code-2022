using System.Text.RegularExpressions;

public static class Utils
{
    public static int Mod(int a, int b) => ((a % b) + b) % b;

    public static int[] GetInts(string line) => Regex.Split(line, @"\D+").Select(x => int.Parse(x)).ToArray();
} 
