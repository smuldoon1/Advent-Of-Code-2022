// Part 1 - 18m 06s 17
// Part 2 - 27m 13s 44
class Day1
{
    static void Main()
    {
        string[] input = File.ReadAllLines(@"F:\Advent-Of-Code-2022\C-Sharp-Solutions\Day1.txt");
        PartOne(input);
        PartTwo(input);
    }

    static void PartOne(string[] input)
    {
        int maxCalories = 0;
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
        maxCalories = Math.Max(currentTotal, maxCalories);

        Console.WriteLine($"Part 1: { maxCalories }");
    }

    static void PartTwo(string[] input)
    {
        int[] maxCalories = new int[3];
        int currentTotal = 0;
        foreach (string line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                SetTopValues(ref maxCalories, currentTotal);
                currentTotal = 0;
                continue;
            }
            currentTotal += int.Parse(line);
        }
        SetTopValues(ref maxCalories, currentTotal);

        Console.WriteLine($"Part 2: { maxCalories.Sum() }");
    }

    static void SetTopValues(ref int[] maxCalories, int count)
    {
        if (count > maxCalories[0])
            maxCalories[0] = count;
        Array.Sort(maxCalories);
    }
}