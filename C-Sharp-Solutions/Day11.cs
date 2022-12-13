// Part 1 - 1h 22m 12s 45
// Part 2 - 

class Day11 : Day
{
    public Day11(string inputPath, bool continueOnError = false) : base(inputPath, continueOnError)
    {
    }

    public override string PartOne(string[] input)
    {
        for (int i = 0; i < input.Length; i += 7)
        {
            var monkey = Monkey.AddMonkey();
            monkey.items.AddRange(Utils.GetInts(input[i + 1]));
            monkey.operation = GetOperation(input[i + 2].Split(" ")[5..]);
            monkey.divisibleBy = Utils.GetInt(input[i + 3]);
            monkey.throwToWhenTrue = Utils.GetInt(input[i + 4]);
            monkey.throwToWhenFalse = Utils.GetInt(input[i + 5]);
        }
        for (int i = 0; i < 20; i++)
        {
            Monkey.monkeys.ForEach(x => x.InspectItems());
        }
        var topTwo = Monkey.monkeys.OrderBy(x => x.inspections).Reverse().Take(2).Select(x => x.inspections).ToList();
        return (topTwo[0] * topTwo[1]).ToString();
    }

    public override string PartTwo(string[] input)
    {
        for (int i = 0; i < input.Length; i += 7)
        {
            var monkey = Monkey2.AddMonkey();
            monkey.items.AddRange(Utils.GetInts(input[i + 1]).Select(x => (long)x));
            monkey.operation = GetOperationL(input[i + 2].Split(" ")[5..]);
            monkey.divisibleBy = Utils.GetInt(input[i + 3]);
            monkey.throwToWhenTrue = Utils.GetInt(input[i + 4]);
            monkey.throwToWhenFalse = Utils.GetInt(input[i + 5]);
        }
        for (int i = 0; i < 10000; i++)
        {
            Monkey2.monkeys.ForEach(x => x.InspectItems());
        }
        var topTwo = Monkey2.monkeys.OrderBy(x => x.inspections).Reverse().Take(2).Select(x => x.inspections).ToList();
        return (topTwo[0] * topTwo[1]).ToString();
    }

    static Func<int, int> GetOperation(string[] line)
    {
        if (line[1] == "+")
        {
            if (line[0] == "old" && int.TryParse(line[2], out int _))
                return (value) => value + int.Parse(line[2]);
            if (line[0] == "old" && line[2] == "old")
                return (value) => value + value;
            else
                return (value) => int.Parse(line[0]) * value;
        }
        else
        {
            if (line[0] == "old" && int.TryParse(line[2], out int _))
                return (value) => value * int.Parse(line[2]);
            if (line[0] == "old" && line[2] == "old")
                return (value) => value * value;
            else
                return (value) => int.Parse(line[0]) * value;
        }
    }

    static Func<long, long> GetOperationL(string[] line)
    {
        if (line[1] == "+")
        {
            if (line[0] == "old" && long.TryParse(line[2], out long _))
                return (value) => value + long.Parse(line[2]);
            if (line[0] == "old" && line[2] == "old")
                return (value) => value + value;
            else
                return (value) => long.Parse(line[0]) * value;
        }
        else
        {
            if (line[0] == "old" && long.TryParse(line[2], out long _))
                return (value) => value * long.Parse(line[2]);
            if (line[0] == "old" && line[2] == "old")
                return (value) => value * value;
            else
                return (value) => long.Parse(line[0]) * value;
        }
    }

    private class Monkey
    {
        public static List<Monkey> monkeys = new List<Monkey>();

        public List<int> items = new List<int>();
        public Func<int, int> operation = (int _) => throw new NotImplementedException();
        public int divisibleBy = 0;
        public int throwToWhenTrue = -1;
        public int throwToWhenFalse = -1;
        public int inspections = 0;

        public static Monkey AddMonkey()
        {
            var monkey = new Monkey();
            monkeys.Add(monkey);
            return monkey;
        }

        public void InspectItems()
        {
            while (items.Count > 0)
            {
                items[0] = operation(items[0]) / 3;
                if (items[0] % divisibleBy == 0)
                    monkeys[throwToWhenTrue].items.Add(items[0]);
                else
                    monkeys[throwToWhenFalse].items.Add(items[0]);
                items.RemoveAt(0);
                inspections++;
            }
        }
    }

    private class Monkey2
    {
        public static List<Monkey2> monkeys = new List<Monkey2>();
        public static long Lcd => monkeys.Select(x => x.divisibleBy).Aggregate(1L, (x, y) => x * y);

        public List<long> items = new List<long>();
        public Func<long, long> operation = (long _) => throw new NotImplementedException();
        public long divisibleBy = 0;
        public int throwToWhenTrue = -1;
        public int throwToWhenFalse = -1;
        public long inspections = 0;

        public static Monkey2 AddMonkey()
        {
            var monkey = new Monkey2();
            monkeys.Add(monkey);
            return monkey;
        }

        public void InspectItems()
        {
            while (items.Count > 0)
            {
                items[0] = operation((int)items[0]) % Lcd;
                if (items[0] % divisibleBy == 0)
                {
                    monkeys[throwToWhenTrue].items.Add(items[0]);
                }
                else
                    monkeys[throwToWhenFalse].items.Add(items[0]);
                items.RemoveAt(0);
                inspections++;
            }
        }
    }
}