// Part 1 - 
// Part 2 - 

using System.Text.RegularExpressions;

class Day16 : Day
{
    public Day16(string inputPath, bool continueOnError = false) : base(inputPath, continueOnError)
    {
    }

    public override string PartOne(string[] input)
    {
        Valve startingValve = Valve.CreateNodeMap(input);
        return ""; // startingValve.GetBestPath(30).ToString();
    }

    public override string PartTwo(string[] input)
    {
        return "";
    }

    public class Valve
    {
        public static Dictionary<string, Valve> valves = new Dictionary<string, Valve>();

        public List<Valve> connections = new List<Valve>();
        public string name;
        public int flowRate = -1;

        public Valve(string name)
        {
            this.name = name;
            valves.Add(name, this);
        }

        public static Valve GetValve(string name)
        {
            Valve valve;
            if (!valves.ContainsKey(name))
                valve = new Valve(name);
            else
                valve = valves[name];
            return valve;
        }

        public static Valve CreateNodeMap(string[] input)
        {
            foreach (var line in input)
            {
                string[] values = Regex.Matches(line, @"[A-Z]{2}|[0-9]+").Select(x => x.Value).ToArray();
                Valve valve = GetValve(values[0]);
                valve.flowRate = int.Parse(values[1]);
                for (int i = 2; i < values.Length; i++)
                    valve.connections.Add(GetValve(values[i]));
            }
            return valves["AA"];
        }

        //public static int GetBestPath()
        //{
        //    foreach (Valve valve in valves.Select(x => x.Value))
        //    {
        //        foreach (var connection in valve.connections)
        //        {
        //            if ()
        //        }
        //    }
        //}
    }
}