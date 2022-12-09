using System.Text;

// Part 1 - 39m 15s 12
// Part 2 - 1h 24m 06s 87
class Day9 : Day
{
    public Day9(string inputPath, bool continueOnError = false) : base(inputPath, continueOnError)
    {
    }

    public override string PartOne(string[] input)
    {
        return GetTailPositions(input, 2).ToString();
    }

    public override string PartTwo(string[] input)
    {
        return GetTailPositions(input, 10).ToString();
    }

    private static int GetTailPositions(string[] input, int ropeLength, bool visualiseRope = false)
    {
        List<(int, int)>[] ropePositions = new List<(int, int)>[ropeLength];
        for (int i = 0; i < ropeLength; i++)
        {
            ropePositions[i] = new List<(int, int)>() { (0, 0) };
        }

        for (int i = 0; i < input.Length; i++)
        {
            var line = input[i].Split(' ');
            string direction = line[0];
            int distance = int.Parse(line[1]);

            (int prevHeadHor, int prevHeadVer) = ropePositions[0].Last();
            ropePositions[0].Add(direction switch
            {
                "L" => (prevHeadHor - distance, prevHeadVer),
                "R" => (prevHeadHor + distance, prevHeadVer),
                "U" => (prevHeadHor, prevHeadVer + distance),
                "D" => (prevHeadHor, prevHeadVer - distance),
                _ => throw new NotImplementedException()
            });

            bool hasRopeSettled;
            do {
                hasRopeSettled = true;
                for (int j = 1; j < ropeLength; j++)
                {
                    (int x, int y) head = ropePositions[j - 1].Last();
                    (int x, int y) tail = ropePositions[j].Last();
                    if (!AreKnotsAdjacent(head, tail))
                    {
                        hasRopeSettled = false;
                        int horMovement = Math.Clamp(head.x - tail.x, -1, 1);
                        int verMovement = Math.Clamp(head.y - tail.y, -1, 1);
                        ropePositions[j].Add((tail.x + horMovement, tail.y + verMovement));
                    }
                }
                if (visualiseRope) VisualiseRope(ropePositions);
            }
            while (!hasRopeSettled);
        }
        return ropePositions[ropeLength - 1].Distinct().Count();
    }

    private static bool AreKnotsAdjacent((int x, int y) knot1, (int x, int y) knot2) => !(knot2.x < knot1.x - 1 || knot2.x > knot1.x + 1 || knot2.y < knot1.y - 1 || knot2.y > knot1.y + 1);

    private static void VisualiseRope(List<(int, int)>[] ropePositions, int millisecondsTimeout = 0)
    {
        StringBuilder display = new();
        (int centerX, int centerY) = ropePositions[0].Last();
        for (int y = ((int)Math.Round(centerY / 25.0)) * 25 + 30; y > ((int)Math.Round(centerY / 25.0)) * 25 - 30; y--)
        {
            for (int x = ((int)Math.Round(centerX / 80.0)) * 80 - 100; x < ((int)Math.Round(centerX / 80.0)) * 80 + 100; x++)
            {
                string s = ".";
                if (ropePositions[0].Last() == (x, y))
                    s = "H";
                else if (ropePositions[ropePositions.Length - 1].Contains((x, y)))
                    s = ",";
                for (int i = 1; i < ropePositions.Length; i++)
                {
                    if (ropePositions[i].Last() == (x, y))
                    {
                        s = (i % 10).ToString();
                        break;
                    }
                }
                display.Append(s);
            }
            display.Append('\n');
        }
        Console.Write(display);
        Thread.Sleep(millisecondsTimeout);
        Console.SetCursorPosition(0, Console.CursorTop - 60);
    }
}