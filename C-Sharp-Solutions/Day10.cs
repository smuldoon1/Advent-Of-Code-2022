// Part 1 - 15m 53s 28
// Part 2 - 
class Day10 : Day
{
    public Day10(string inputPath, bool continueOnError = false) : base(inputPath, continueOnError)
    {
    }

    public override string PartOne(string[] input)
    {
        int register = 1;
        int sum = 0;
        int cycle = 1;
        foreach (string line in input)
        {
            var ins = line.Split(' ');
            if (ins[0] == "addx")
            {
                for (int i = 0; i < 2; i++, cycle++)
                {
                    if ((cycle + 20) % 40 == 0)
                        sum += register * cycle;
                }
                register += int.Parse(ins[1]);
            }
            else
                cycle++;
        }
        return sum.ToString();
    }

    public override string PartTwo(string[] input)
    {
        bool[] crt = new bool[240];
        int sprite = 1;
        int cycle = 1;
        foreach (string line in input)
        {
            var ins = line.Split(' ');
            if (ins[0] == "addx")
            {
                for (int i = 0; i < 2; i++, cycle++)
                {
                    crt[cycle - 1] = cycle % 40 >= sprite && cycle % 40 <= sprite + 2; 
                }
                sprite += int.Parse(ins[1]);
            }
            else
                cycle++;
        }
        DisplayCrt(crt);
        return "".ToString();
    }

    private static void DisplayCrt(bool[] crt)
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 40; j++)
            {
                Console.Write(crt[i * 40 + j] ? "█" : ".");
            }
            Console.Write("\n");
        }
    }
}