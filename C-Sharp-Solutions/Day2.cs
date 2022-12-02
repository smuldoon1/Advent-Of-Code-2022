// Part 1 - 13m 22s 01
// Part 2 - 19m 50s 03
class Day2
{
    static void Main()
    {
        string[] input = File.ReadAllLines(@"F:\Advent-Of-Code-2022\C-Sharp-Solutions\Day2.txt");
        PartOne(input);
        PartTwo(input);
    }

    static void PartOne(string[] input)
    {
        int score = 0;
        foreach (string round in input)
        {
            char opponent = round[0];
            char player = (char)(round[2] - 23);
            if (opponent == player)
                score += 3;
            else if ((opponent == 'A' && player == 'B') || (opponent == 'B' && player == 'C') || (opponent == 'C' && player == 'A'))
                score += 6;

            if (player == 'A')
                score += 1;
            else if (player == 'B')
                score += 2;
            else
                score += 3;
        }
        Console.WriteLine($"Day 1: { score }");
    }

    static void PartTwo(string[] input)
    {
        int score = 0;
        foreach (string round in input)
        {
            char opponent = round[0];
            char result = round[2];
            if (result == 'Y')
            {
                score += 3;
                if (opponent == 'A')
                    score += 1;
                else if (opponent == 'B')
                    score += 2;
                else
                    score += 3;
            }
            else if (result == 'Z')
            {
                score += 6;
                if (opponent == 'A')
                    score += 2;
                else if (opponent == 'B')
                    score += 3;
                else
                    score += 1;
            }
            else
            {
                if (opponent == 'A')
                    score += 3;
                else if (opponent == 'B')
                    score += 1;
                else
                    score += 2;
            }
        }
        Console.WriteLine($"Day 2: { score }");
    }
}