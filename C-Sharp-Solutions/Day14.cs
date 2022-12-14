// Part 1 - 
// Part 2 - 
using System.Text;

class Day14 : Day
{
    public Day14(string inputPath, bool continueOnError = false) : base(inputPath, continueOnError)
    {
    }

    public override string PartOne(string[] input)
    {
        var grid = CreateMap(input);
        int totalSand = Simulate(grid);
        //DisplayGrid(grid, 378, 608, 0, 165);
        return totalSand.ToString();
    }

    public override string PartTwo(string[] input)
    {
        var grid = CreateMap(input, floor: true);
        int totalSand = Simulate(grid);
        //DisplayGrid(grid, 370, 600, 0, 165);
        return totalSand.ToString();
    }

    // 0 = air, 1 = rock
    private static int[,] CreateMap(string[] input, bool floor = false)
    {
        int[,] grid = new int[1000, 1000];
        int lowestPoint = 0;
        foreach (string line in input)
        {
            (int x, int y)[] points = line.Split(" -> ").Select(a => (int.Parse(a.Split(",")[0]), int.Parse(a.Split(",")[1]))).ToArray();
            for (int i = 1; i < points.Length; i++)
            {
                int x = points[i - 1].x;
                int y = points[i - 1].y;
                int xStep = Math.Clamp(points[i].x - points[i - 1].x, -1, 1);
                int yStep = Math.Clamp(points[i].y - points[i - 1].y, -1, 1);
                while (x != points[i].x || y != points[i].y)
                {
                    grid[x, y] = 1;
                    x += xStep;
                    y += yStep;
                }
                grid[x, y] = 1;
            }
            lowestPoint = Math.Max(lowestPoint, points.Select(a => a.y).Max());
        }
        if (floor)
        {
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                grid[x, lowestPoint + 2] = 1;
            }
        }
        return grid;
    }

    private static int Simulate(int[,] grid)
    {
        int totalSand = 0;
        while (true)
        {
            int[]? sand = DropSand(grid, 500, 0);
            if (sand != null)
            {
                grid[sand[0], sand[1]] = 2;
                totalSand++;
            }
            else
            {
                break;
            }
        }
        return totalSand;
    }

    private static int[]? DropSand(int[,] grid, int x, int y)
    {
        if (grid[x, y] != 0)
            return null;
        while (y < 500)
        {
            if (grid[x, y + 1] == 0)
            {
                
            }
            else if (grid[x - 1, y + 1] == 0)
            {
                x--;
            }
            else if (grid[x + 1, y + 1] == 0)
            {
                x++;
            }
            else
            {
                return new [] { x, y };
            }
            y++;
        }
        return null;
    }

    private void DisplayGrid(int[,] grid, int x1, int x2, int y1, int y2)
    {
        StringBuilder s = new StringBuilder();
        for (int j = y1; j < y2; j++)
        {
            for (int i = x1; i < x2; i++)
            {
                s.Append(grid[i, j] switch
                {
                    0 => ' ',
                    1 => '▓',
                    2 => '░',
                    _ => '?'
                });
            }
            s.Append("\n");
        }
        Console.Write(s);
    }
}