//Day 1 - 18m 06s 17
class Day1
{
    static void Main()
    {
        string[] input = File.ReadAllLines(@"F:\Advent-Of-Code-2022\C-Sharp-Solutions\Day1.txt");
        int maxCalories = -1;
        int currentTotal = 0;
        foreach (string line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                maxCalories = Math.Max(currentTotal, maxCalories);
                currentTotal = 0;
                continue;
            }
            currentTotal += int.Parse(line);
        }
        Console.WriteLine($"Max calories: {maxCalories}");
    }
}