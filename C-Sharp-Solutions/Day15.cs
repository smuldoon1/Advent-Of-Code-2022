// Part 1 - 
// Part 2 - 

class Day15 : Day
{
    public Day15(string inputPath, bool continueOnError = false) : base(inputPath, continueOnError)
    {
    }

    public override string PartOne(string[] input)
    {
        int row = 2000000;
        var sensors = new List<Sensor>();
        var beaconsOnRow = new List<int>();
        foreach (string line in input)
        {
            var sensor = new Sensor(Utils.GetInts(line));
            sensors.Add(sensor);
            if (sensor.BeaconY == row && !beaconsOnRow.Contains(sensor.BeaconX))
            {
                beaconsOnRow.Add(sensor.BeaconX);
            }
        }
        var coverage = new List<int>();
        foreach (var sensor in sensors)
        {
            coverage = coverage.Union(sensor.GetBeaconCoverage(row)).ToList();
        }
        return (coverage.Count - beaconsOnRow.Count).ToString();
    }

    public override string PartTwo(string[] input)
    {
        var sensors = new List<Sensor>();
        foreach (string line in input)
        {
            var sensor = new Sensor(Utils.GetInts(line));
            sensors.Add(sensor);
        }
        var positions = new List<(int x, int y)>();
        foreach (var sensor in sensors)
        {
            positions.AddRange(sensor.PositionsOutsideRadius());
        }
        foreach (var position in positions)
        {
            if (IsDistressBeacon(position.x, position.y, sensors))
            {
                return (position.x * 4000000L + position.y).ToString();
            }
        }
        return "-1";
    }

    private static bool IsDistressBeacon(int x, int y, List<Sensor> sensors)
    {
        foreach (var sensor in sensors)
        {
            var distance = Math.Abs(x - sensor.X) + Math.Abs(y - sensor.Y);
            if (distance <= sensor.Distance ||
                x < 0 || y < 0 || x > 4000000 || y > 4000000)// || (x == 3859433 && y == 3323143) || (x == 2911363 && y == 2855041))
            {
                return false;
            }
        }
        return true;
    }

    private class Sensor
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int BeaconX { get; set; }
        public int BeaconY { get; set; }
        public int Distance { get; set; }

        public Sensor(int[] ints)
        {
            X = ints[0];
            Y = ints[1];
            BeaconX = ints[2];
            BeaconY = ints[3];
            Distance = Math.Abs(BeaconX - X) + Math.Abs(BeaconY - Y);
        }

        public List<int> GetBeaconCoverage(int row)
        {
            int range = Distance - Math.Abs(row - Y);
            if (range < 0)
                return new List<int>();
            var ints = Enumerable.Range(X - range, range * 2 + 1).ToList();
            return ints;
        }

        public List<(int, int)> PositionsOutsideRadius()
        {
            var points = new List<(int, int)>();
            for (int y = -Distance; y < Distance + 1; y++)
            {
                int x = Math.Abs(y) - Distance - 1;
                points.Add((X - x, Y - y));
                points.Add((X + x, Y - y));
            }
            points.Add((X, Y - Distance - 1));
            points.Add((X, Y + Distance + 1));
            return points;
        }
    }
}