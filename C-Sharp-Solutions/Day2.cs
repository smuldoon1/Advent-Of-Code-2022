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
        return score;
    }

    public override int PartTwo(string[] input)
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
        return score;
    }
}