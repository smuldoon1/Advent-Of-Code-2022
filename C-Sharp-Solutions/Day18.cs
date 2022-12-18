// Part 1 - 
// Part 2 - 

class Day18 : Day
{
    public int[,,] cubes = new int[25,25,25];

    public Day18(string inputPath, bool continueOnError = false) : base(inputPath, continueOnError)
    {
    }

    public override string PartOne(string[] input)
    {
        foreach (var line in input)
        {
            var coords = Utils.GetInts(',' + line);
            cubes[coords[0], coords[1], coords[2]] = 1;
        }
        return GetTotalSurfaceArea().ToString();
    }

    public override string PartTwo(string[] input)
    {
        foreach (var line in input)
        {
            var coords = Utils.GetInts(',' + line);
            cubes[coords[0], coords[1], coords[2]] = 1;
        }
        for (int i = 0; i < cubes.GetLength(0); i++)
        {
            for (int j = 0; j < cubes.GetLength(1); j++)
            {
                for (int k = 0; k < cubes.GetLength(2); k++)
                {
                    if (cubes[i, j, k] == 0)
                    {
                        var visited = new HashSet<(int x, int y, int z)>();
                        if (Fill(i, j, k, ref visited))
                            cubes[i, j, k] = 2;
                    }
                }
            }
        }
        for (int k = 0; k < cubes.GetLength(2); k++)
        {
            for (int i = 0; i < cubes.GetLength(0); i++)
            {
                for (int j = 0; j < cubes.GetLength(1); j++)
                {
                    Console.Write(cubes[i, j, k] switch
                    {
                        0 => '.',
                        1 => '█',
                        2 => '#',
                        _ => throw new NotImplementedException()
                    });
                }
                Console.Write("\n");
            }
            Console.WriteLine($"\nDepth:{k}");
        }
        return GetTotalSurfaceArea().ToString();
    }

    private bool IsInterior(int i, int j, int k)
    {
        HashSet<(int x, int y, int z)> visited = new HashSet<(int x, int y, int z)>() { (i, j, k) };
        (int x, int y, int z) previous = (0, -1, 0);
        for (int c = 0; c < 100000; c++)
        {
            if (i == 0 || j == 0 || k == 0 || i == cubes.GetLength(0) - 1 || j == cubes.GetLength(1) - 1 || k == cubes.GetLength(2) - 1)
                return false;
            if (!visited.Contains((i + previous.x, j + previous.y, k + previous.z)) &&
                cubes[i + previous.x, j + previous.y, k + previous.z] == 0) { }
            // Go in previous direction
            else if (!visited.Contains((i - 1, j, k)) && cubes[i - 1, j, k] == 0)
                previous = (-1, 0, 0);
            else if (!visited.Contains((i + 1, j, k)) && cubes[i + 1, j, k] == 0)
                previous = (1, 0, 0);
            else if (!visited.Contains((i, j - 1, k)) && cubes[i, j - 1, k] == 0)
                previous = (0, -1, 0);
            else if (!visited.Contains((i, j + 1, k)) && cubes[i, j + 1, k] == 0)
                previous = (0, 1, 0);
            else if (!visited.Contains((i, j, k - 1)) && cubes[i, j, k - 1] == 0)
                previous = (0, 0, -1);
            else if (!visited.Contains((i, j, k + 1)) && cubes[i, j, k + 1] == 0)
                previous = (0, 0, 1);
            else
            {
                if (cubes[i + previous.x, j + previous.y, k + previous.z] == 0) { }
                // Go in previous direction
                else if (cubes[i - 1, j, k] == 0)
                    previous = (-1, 0, 0);
                else if (cubes[i + 1, j, k] == 0)
                    previous = (1, 0, 0);
                else if (cubes[i, j - 1, k] == 0)
                    previous = (0, -1, 0);
                else if (cubes[i, j + 1, k] == 0)
                    previous = (0, 1, 0);
                else if (cubes[i, j, k - 1] == 0)
                    previous = (0, 0, -1);
                else if (cubes[i, j, k + 1] == 0)
                    previous = (0, 0, 1);
                return true;
            }
            i += previous.x;
            j += previous.y;
            k += previous.z;
            if (!visited.Contains((i, j, k)))
                visited.Add((i, j, k));
        }
        return true;
    }

    private bool Fill(int i, int j, int k, ref HashSet<(int x, int y, int z)> visited)
    {
        if (visited.Contains((i, j, k)))
            return false;
        else
            visited.Add((i, j, k));
        if (i == 0 || j == 0 || k == 0 || i == cubes.GetLength(0) - 1 || j == cubes.GetLength(1) - 1 || k == cubes.GetLength(2) - 1)
            return true;
        return
            Fill(i - 1, j, k, ref visited) ||
            Fill(i + 1, j, k, ref visited) ||
            Fill(i, j - 1, k, ref visited) ||
            Fill(i, j + 1, k, ref visited) ||
            Fill(i, j, k - 1, ref visited) ||
            Fill(i, j, k + 1, ref visited);
    }

    private int GetTotalSurfaceArea()
    {
        int surfaceArea = 0;
        for (int i = 0; i < cubes.GetLength(0); i++)
        {
            for (int j = 0; j < cubes.GetLength(1); j++)
            {
                for (int k = 0; k < cubes.GetLength(2); k++)
                {
                    if (cubes[i, j, k] == 1)
                        surfaceArea += CountSurfaceSides(i, j, k);
                }
            }
        }
        return surfaceArea;
    }

    private int CountSurfaceSides(int i, int j, int k)
    {
        int count = 0;
        if (i == 0 || cubes[i - 1, j, k] == 0) count++;
        if (j == 0 || cubes[i, j - 1, k] == 0) count++;
        if (k == 0 || cubes[i, j, k - 1] == 0) count++;
        if (i == cubes.GetLength(0) - 1 || cubes[i + 1, j, k] == 0) count++;
        if (j == cubes.GetLength(1) - 1 || cubes[i, j + 1, k] == 0) count++;
        if (k == cubes.GetLength(2) - 1 || cubes[i, j, k + 1] == 0) count++;
        return count;
    }
}