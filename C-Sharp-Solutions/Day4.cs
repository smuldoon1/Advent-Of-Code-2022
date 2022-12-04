// Part 1 - 11m 20s 66
// Part 2 - 14m 38s 23
class Day4 : Day
{
    public Day4(string inputPath, bool continueOnError = false) : base(inputPath, continueOnError)
    {
    }

    public override int PartOne(string[] input)
    {
        int overlaps = 0;
        foreach (string pair in input)
        {
            var pairs = pair.Split(',');
            int[] pair1 = pairs[0].Split('-').Select(x => int.Parse(x)).ToArray();
            int[] pair2 = pairs[1].Split('-').Select(x => int.Parse(x)).ToArray();
            if ((pair1[0] <= pair2[0] && pair1[1] >= pair2[1]) ||
                (pair2[0] <= pair1[0] && pair2[1] >= pair1[1]))
            {
                overlaps++;
            }
        }
        return overlaps;
    }

    public override int PartTwo(string[] input)
    {
        int overlaps = 0;
        foreach (string pair in input)
        {
            var pairs = pair.Split(',');
            int[] pair1 = pairs[0].Split('-').Select(x => int.Parse(x)).ToArray();
            int[] pair2 = pairs[1].Split('-').Select(x => int.Parse(x)).ToArray();
            if ((pair1[0] <= pair2[1] && pair1[1] >= pair2[0]) ||
                (pair2[0] <= pair1[1] && pair2[1] >= pair1[0]))
            {
                overlaps++;
            }
        }
        return overlaps;
    }
}