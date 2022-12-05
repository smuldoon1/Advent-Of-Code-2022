// Part 1 - 12m 39s 16
// Part 2 - 25m 43s 25
class Day3 : Day
{
    public Day3(string inputPath, bool continueOnError = false) : base(inputPath, continueOnError)
    {
    }

    public override string PartOne(string[] input)
    {
        int sum = 0;
        foreach (string line in input)
        {
            string p1 = line.Substring(0, line.Length / 2);
            string p2 = line.Substring(line.Length / 2, line.Length / 2);
            for (int i = 0; i < p1.Length; i++)
            {
                if (p1.Contains(p2[i]))
                {
                    if (p2[i] > 96)
                        sum += p2[i] - 96;
                    else
                        sum += p2[i] - 38;
                    i+= 10000;
                }
            }
        }
        return sum.ToString();
    }

    public override string PartTwo(string[] input)
    {
        int sum = 0;
        for (int i = 0; i < input.Length; i += 3)
        {
            int index = 2;
            if (input[i].Length >= input[i + 1].Length && input[i].Length >= input[i + 2].Length)
                index = 0;
            else if (input[i + 1].Length >= input[i].Length && input[i + 1].Length >= input[i + 2].Length)
                index = 1;

            for (int j = 0; j < input[index + i].Length; j++)
            {
                if (input[i].Contains(input[index + i][j]) &&
                    input[i + 1].Contains(input[index + i][j]) &&
                    input[i + 2].Contains(input[index + i][j]))
                {
                    if (input[index + i][j] > 96)
                        sum += input[index + i][j] - 96;
                    else
                        sum += input[index + i][j] - 38;
                    j += 100000000;
                }
            }
        }
        return sum.ToString();
    }
}