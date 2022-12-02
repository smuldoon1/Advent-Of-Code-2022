// Part 1 - 13m 22s 01
// Part 2 - 19m 50s 03
class Day2 : Day
{
    public Day2(string inputPath, bool continueOnError = false) : base(inputPath, continueOnError)
    {
    }

    public override int PartOne(string[] input)
    {
        int score = 0;
        foreach (string round in input)
        {
            int opponent = MapChar(round[0]);
            int player = MapChar(round[2]);
            score += Utils.Mod(player - opponent, 3) switch
            {
                0 => 3, 1 => 6, _ => 0
            };
            score += player + 1;
        }
        return score;
    }

    public override int PartTwo(string[] input)
    {
        int score = 0;
        foreach (string round in input)
        {
            int opponent = MapChar(round[0]);
            int result = MapChar(round[2]) - 1;
            score += result switch
            {
                0 => 3, 1 => 6, _ => 0
            };
            score += Utils.Mod(opponent + result, 3) + 1;
        }
        return score;
    }

    static int MapChar(char c)
    {
        return c switch
        {
            'A' or 'X' => 0,
            'B' or 'Y' => 1,
            'C' or 'Z' => 2,
            _ => throw new NotImplementedException("Invalid char")
        };
    }
}