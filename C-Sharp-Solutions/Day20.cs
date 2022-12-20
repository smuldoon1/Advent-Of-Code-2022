// Part 1 - 
// Part 2 - 

class Day20 : Day
{
    public Day20(string inputPath, bool continueOnError = false) : base(inputPath, continueOnError)
    {
    }

    public override string PartOne(string[] input)
    {
        int listCount = input.Length;
        var numList = new List<int>();
        foreach (var num in input)
            numList.Add(int.Parse(num));

        var indexList = Enumerable.Range(0, listCount).ToList();
        for (int i = 0; i < listCount; i++)
        {
            var index = indexList.IndexOf(i);
            int number = numList[index];
            int newIndex = Utils.Mod(index + numList[index], listCount - 1);
            numList.RemoveAt(index);
            numList.Insert(newIndex, number);
            indexList.RemoveAt(index);
            indexList.Insert(newIndex, i);
        }
        var zeroIndex = numList.IndexOf(0);
        return (numList[Utils.Mod(zeroIndex + 1000, listCount)] +
            numList[Utils.Mod(zeroIndex + 2000, listCount)] +
            numList[Utils.Mod(zeroIndex + 3000, listCount)]).ToString();
    }

    public override string PartTwo(string[] input)
    {
        int listCount = input.Length;
        var numList = new List<long>();
        foreach (var num in input)
            numList.Add(int.Parse(num) * 811589153L);

        var indexList = Enumerable.Range(0, listCount).ToList();
        for (int x = 0; x < 10; x++)
        {
            for (int i = 0; i < listCount; i++)
            {
                var index = indexList.IndexOf(i);
                long number = numList[index];
                int newIndex = (int)Utils.Mod(index + numList[index], listCount - 1);
                numList.RemoveAt(index);
                numList.Insert(newIndex, number);
                indexList.RemoveAt(index);
                indexList.Insert(newIndex, i);
            }
        }
        var zeroIndex = numList.IndexOf(0);
        return (numList[Utils.Mod(zeroIndex + 1000, listCount)] +
            numList[Utils.Mod(zeroIndex + 2000, listCount)] +
            numList[Utils.Mod(zeroIndex + 3000, listCount)]).ToString();
    }
}