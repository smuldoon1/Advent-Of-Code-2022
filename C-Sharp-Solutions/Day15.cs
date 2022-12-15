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
        return "";
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
            var xPoints = new List<int>();
            for (int x = -1000000; x < 5000000; x++)
            {
                int distance = Math.Abs(x - X) + Math.Abs(row - Y);
                if (distance <= Distance)
                {
                    xPoints.Add(x);
                }
            }
            return xPoints;
        }
    }
}