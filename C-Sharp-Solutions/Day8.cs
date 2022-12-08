// Part 1 - 34m 01s 83
// Part 2 - 56m 15s 32
class Day8 : Day
{
    public Day8(string inputPath, bool continueOnError = false) : base(inputPath, continueOnError)
    {
    }

    public override string PartOne(string[] input)
    {
        // Set up tree map
        int height = input.Length;
        int width = input[0].Length;
        var treeMap = new (int height, bool isVisible)[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                treeMap[i, j] = new(int.Parse(input[i][j].ToString()), false);
                if (i == 0 || j == 0 || i == width - 1 || j == height - 1)
                    treeMap[i, j].isVisible = true;
            }
        }

        // Set tree visibility
        for (int i = 1; i < treeMap.GetLength(1) - 1; i++)
        {
            SetVisibleTreesHorizontal(treeMap, i);
        }
        for (int i = 1; i < treeMap.GetLength(0) - 1; i++)
        {
            SetVisibleTreesVertical(treeMap, i);
        }

        // Count visible trees
        int visibleTrees = 0;
        foreach (var (_, isVisible) in treeMap)
        {
            if (isVisible)
                visibleTrees++;
        }
        return visibleTrees.ToString();
    }

    public override string PartTwo(string[] input)
    {
        // Set up tree map
        int height = input.Length;
        int width = input[0].Length;
        var treeMap = new int[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                treeMap[i, j] = int.Parse(input[i][j].ToString());
            }
        }

        int maxScore = -1;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                maxScore = Math.Max(maxScore, GetScore(treeMap, i, j));
            }
        }
        return maxScore.ToString();
    }

    private static void SetVisibleTreesHorizontal( (int height, bool isVisible)[,] treeMap, int row)
    {
        // West to east
        int maxHeight = treeMap[row, 0].height;
        for (int i = 1; i < treeMap.GetLength(0) - 1 && maxHeight < 9; i++)
        {
            if (treeMap[row, i].height > maxHeight)
            {
                treeMap[row, i].isVisible = true;
                maxHeight = treeMap[row, i].height;
            }
        }
        // East to west
        maxHeight = treeMap[row, treeMap.GetLength(0) - 1].height;
        for (int i = treeMap.GetLength(0) - 1; i > 0 && maxHeight < 9; i--)
        {
            if (treeMap[row, i].height > maxHeight)
            {
                treeMap[row, i].isVisible = true;
                maxHeight = treeMap[row, i].height;
            }
        }
    }

    private static void SetVisibleTreesVertical((int height, bool isVisible)[,] treeMap, int col)
    {
        // North to south
        int maxHeight = treeMap[0, col].height;
        for (int i = 1; i < treeMap.GetLength(1) - 1 && maxHeight < 9; i++)
        {
            if (treeMap[i, col].height > maxHeight)
            {
                treeMap[i, col].isVisible = true;
                maxHeight = treeMap[i, col].height;
            }
        }
        // South to north
        maxHeight = treeMap[treeMap.GetLength(1) - 1, col].height;
        for (int i = treeMap.GetLength(1) - 1; i > 0 && maxHeight < 9; i--)
        {
            if (treeMap[i, col].height > maxHeight)
            {
                treeMap[i, col].isVisible = true;
                maxHeight = treeMap[i, col].height;
            }
        }
    }

    private static int GetScore(int[,] treeMap, int row, int col)
    {
        int n, s, e, w;
        n = s = e = w = 0;
        // North
        int maxHeight = treeMap[row, col];
        for (int i = row - 1; i >= 0; i--)
        {
            n++;
            if (treeMap[i, col] >= maxHeight)
                break;
        }
        // South
        for (int i = row + 1; i < treeMap.GetLength(1); i++)
        {
            s++;
            if (treeMap[i, col] >= maxHeight)
                break;
        }
        // East
        for (int i = col - 1; i >= 0; i--)
        {
            e++;
            if (treeMap[row, i] >= maxHeight)
                break;
        }
        // West
        for (int i = col + 1; i < treeMap.GetLength(0); i++)
        {
            w++;
            if (treeMap[row, i] >= maxHeight)
                break;
        }
        return n * s * e * w;
    }
}