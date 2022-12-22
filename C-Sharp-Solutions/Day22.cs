using System.Text;
using System.Text.RegularExpressions;

class Day22 : Day
{
    public Day22(string inputPath, bool continueOnError = false) : base(inputPath, continueOnError)
    {
    }

    public override string PartOne(string[] input)
    {
        var gridLines = input.TakeWhile(x => x.Length > 0);
        int[,] grid = new int[gridLines.Max(x => x.Length), gridLines.Count()];
        for (int j = 0; j < grid.GetLength(1); j++)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                if (i >= input[j].Length || input[j][i] == ' ')
                    grid[i, j] = -1;
                else if (input[j][i] == '.')
                    grid[i, j] = 0;
                else
                    grid[i, j] = 1;
            }
        }
        int c = 0;
        do { c++; }
        while (input[c].Length > 0);

        (int x, int y)[] stepDirections = new[] { (1, 0), (0, 1), (-1, 0), (0, -1) };
        (int x, int y) = (0, 0);
        Direction facing = Direction.RIGHT;
        var instructions = Regex.Matches(string.Concat(input[c..]), @"(\d+)|(\D)").Select(x => x.Value).ToArray();
        for (int i = 0; i < instructions.Length; i++)
        {
            if (i % 2 == 0)
            {
                int step = 0;
                while (step < int.Parse(instructions[i]))
                {
                    (int newX, int newY) = (x, y);
                    do
                    {
                        newX = Utils.Mod(newX + stepDirections[(int)facing].x, grid.GetLength(0));
                        newY = Utils.Mod(newY + stepDirections[(int)facing].y, grid.GetLength(1));
                    } while (grid[newX, newY] == -1);
                    if (grid[newX, newY] == 1)
                        break;
                    (x, y) = (newX, newY);
                    step++;
                }
            }
            else
                facing = (Direction)Utils.Mod((int)facing + (instructions[i] == "L" ? -1 : 1), 4);
        }
        return (((y + 1) * 1000) + ((x + 1) * 4) + (int)facing).ToString();
    }

    public override string PartTwo(string[] input)
    {
        return "";
    }

    private static string DisplayGrid(int[,] grid)
    {
        var s = new StringBuilder("\n");
        for (int j = 0; j < grid.GetLength(1); j++)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                s.Append(grid[i, j] switch
                {
                    0 => '.',
                    1 => '#',
                    _ => ' ',
                });
            }
            s.Append('\n');
        }
        return s.ToString();
    }

    enum Direction
    {
        RIGHT, DOWN, LEFT, UP
    }
}