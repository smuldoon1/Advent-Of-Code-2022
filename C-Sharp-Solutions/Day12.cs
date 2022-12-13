// Part 1 - 
// Part 2 - 

class Day12 : Day
{
    public Day12(string inputPath, bool continueOnError = false) : base(inputPath, continueOnError)
    {
    }

    public override string PartOne(string[] input)
    {
        return FindShortestPath(input, 'S').ToString();
    }

    public override string PartTwo(string[] input)
    {
        return FindShortestPath(input, 'a').ToString();
    }

    private static int FindShortestPath(string[] input, char searchFor)
    {
        var path = new (char c, int distance)[input[0].Length, input.Length];
        var queue = new Queue<(int x, int y)>();
        for (int y = 0; y < input.Length; y++)
        {
            for (int x = 0; x < input[y].Length; x++)
            {
                path[x, y].c = input[y][x];
                path[x, y].distance = 9999;
                if (path[x, y].c == 'E')
                {
                    queue.Enqueue((x, y));
                    path[x, y].c = 'z';
                    path[x, y].distance = 0;
                }
            }
        }
        while (true)
        {
            var pos = queue.Dequeue();
            if (Search(queue, ref path, pos.x, pos.y, searchFor))
            {
                return path[pos.x, pos.y].distance;
            }
        }
    }

    private static bool Search(Queue<(int, int)> queue, ref (char c, int distance)[,] path, int x, int y, char searchFor)
    {
        var current = path[x, y];
        if (current.c == searchFor)
            return true;
        if (x > 0 && CanMove(current.c, path[x - 1, y].c) && path[x - 1, y].distance >= current.distance)
        {
            path[x - 1, y].distance = current.distance + 1;
            if (!queue.Contains((x - 1, y)))
                queue.Enqueue((x - 1, y));
        }
        if (x < path.GetLength(0) - 1 && CanMove(current.c, path[x + 1, y].c) && path[x + 1, y].distance >= current.distance)
        {
            path[x + 1, y].distance = current.distance + 1;
            if (!queue.Contains((x + 1, y)))
                queue.Enqueue((x + 1, y));
        }
        if (y > 0 && CanMove(current.c, path[x, y - 1].c) && path[x, y - 1].distance >= current.distance)
        {
            path[x, y - 1].distance = current.distance + 1;
            if (!queue.Contains((x, y - 1)))
                queue.Enqueue((x, y - 1));
        }
        if (y < path.GetLength(1) - 1 && CanMove(current.c, path[x, y + 1].c) && path[x, y + 1].distance >= current.distance)
        {
            path[x, y + 1].distance = current.distance + 1;
            if (!queue.Contains((x, y + 1)))
                queue.Enqueue((x, y + 1));
        }
        return false;
    }

    private static bool CanMove(char a, char b) => (b >= a - 1 || b == 'S');
}