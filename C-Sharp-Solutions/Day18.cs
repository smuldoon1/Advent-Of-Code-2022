// Part 1 - 
// Part 2 - 

class Day18 : Day
{
    public int[,,] cubes = new int[25,25,25];

    public List<(int x, int y, int z)> directions = new List<(int x, int y, int z)>
    {
        (-1, 0, 0),
        (1, 0, 0),
        (0, -1, 0),
        (0, 1, 0),
        (0, 0, -1),
        (0, 0, 1)
    };

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
                        if (IsInterior(i, j, k))
                            cubes[i, j, k] = 2;
                    }
                }
            }
        }
        return GetTotalSurfaceArea().ToString();
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

    private bool IsInterior(int i, int j, int k)
    {
        var toCheck = new Queue<(int x, int y, int z)>();
        var visited = new HashSet<(int x, int y, int z)>();
        toCheck.Enqueue((i, j, k));
        visited.Add((i, j, k));
        while (toCheck.Count > 0)
        {
            var (x, y, z) = toCheck.Dequeue();
            if (cubes[x, y, z] == 2)
                return true;
            if (x == 0 || y == 0 || z == 0 || x == cubes.GetLength(0) - 1 || y == cubes.GetLength(1) - 1 || z == cubes.GetLength(2) - 1)
                return false;

            foreach (var dir in directions)
            {
                (int x, int y, int z) neighbour = (x + dir.x, y + dir.y, z + dir.z);
                if (cubes[neighbour.x, neighbour.y, neighbour.z] != 1 && !visited.Contains(neighbour))
                {
                    toCheck.Enqueue(neighbour);
                    visited.Add(neighbour);
                }
            }
        }
        return true;
    }
}