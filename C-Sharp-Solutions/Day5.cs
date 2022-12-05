// Part 1 - 44m 26s 89
// Part 2 - 50m 18s 59
using System.Text;
using System.Text.RegularExpressions;

class Day5 : Day
{
    public Day5(string inputPath, bool continueOnError = false) : base(inputPath, continueOnError)
    {
    }

    public override string PartOne(string[] input)
    {
        (int firstInstruction, Stack<char>[] stacks) = GetStacks(input);
        for (int i = firstInstruction; i < input.Length; i++)
        {
            var ins = Regex.Split(input[i][5..], @"\D+");
            MoveCratesP1(stacks, int.Parse(ins[0]), int.Parse(ins[1]) - 1, int.Parse(ins[2]) - 1);
        }
        StringBuilder sb = new StringBuilder();
        foreach (var stack in stacks)
        {
            sb.Append(stack.Pop());
        }
        return sb.ToString();
    }

    public override string PartTwo(string[] input)
    {
        (int firstInstruction, Stack<char>[] stacks) = GetStacks(input);
        for (int i = firstInstruction; i < input.Length; i++)
        {
            var ins = Regex.Split(input[i][5..], @"\D+");
            MoveCratesP2(stacks, int.Parse(ins[0]), int.Parse(ins[1]) - 1, int.Parse(ins[2]) - 1);
        }
        StringBuilder sb = new StringBuilder();
        foreach (var stack in stacks)
        {
            sb.Append(stack.Pop());
        }
        return sb.ToString();
    }

    static (int, Stack<char>[]) GetStacks(string[] input)
    {
        Stack<char>[] stacks;
        int stackNumbersRow = 2;
        while (input[stackNumbersRow] != "") stackNumbersRow++;
        stackNumbersRow--;

        int noOfStacks = int.Parse(input[stackNumbersRow].Trim().Split("   ").Last());
        stacks = new Stack<char>[noOfStacks];
        for (int i = 0; i < noOfStacks; i++)
            stacks[i] = new Stack<char>();

        for (int i = stackNumbersRow - 1; i >= 0; i--)
        {
            for (int j = 0; j < noOfStacks; j++)
            {
                char c = input[i][j * 4 + 1];
                if (c != ' ')
                {
                    stacks[j].Push(c);
                }
            }
        }
        return (stackNumbersRow + 2, stacks);
    }

    static void MoveCratesP1(Stack<char>[] stacks, int noOfCrates, int fromStack, int toStack)
    {
        for (int i = 0; i < noOfCrates; i++)
        {
            stacks[toStack].Push(stacks[fromStack].Pop());
        }
    }

    static void MoveCratesP2(Stack<char>[] stacks, int noOfCrates, int fromStack, int toStack)
    {
        List<char> crates = new List<char>();
        for (int i = 0; i < noOfCrates; i++)
        {
            crates.Add(stacks[fromStack].Pop());
        }
        crates.Reverse();
        foreach (char crate in crates)
        {
            stacks[toStack].Push(crate);
        }
    }
}