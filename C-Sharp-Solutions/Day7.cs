// Part 1 - 47m 40s 65
// Part 2 - 1h 10m 32s 77
class Day7 : Day
{
    Directory rootDirectory;

    public Day7(string inputPath, bool continueOnError = false) : base(inputPath, continueOnError)
    {
    }

    public override string PartOne(string[] input)
    {
        rootDirectory = new Directory(null);
        RunCommands(input);
        return rootDirectory.GetDirectorySizes(100000).ToString();
    }

    public override string PartTwo(string[] input)
    {
        rootDirectory = new Directory(null);
        RunCommands(input);
        var list = rootDirectory.ListDirectoryFileSizes(new List<int>());
        list.Sort();
        foreach(int size in list)
        {
            if (70000000 - rootDirectory.Size + size >= 30000000)
                return size.ToString();
        }
        return "-1";
    }

    public void RunCommands(string[] commands)
    {
        Directory? currentDirectory = rootDirectory;
        foreach (string line in commands)
        {
            string[] args = line.Split(" ");
            if (args[0] == "$")
            {
                if (args[1] != "ls")
                {
                    if (args[2] == "/")
                        currentDirectory = rootDirectory;
                    else if (args[2] == "..")
                        currentDirectory = currentDirectory?.Parent;
                    else
                        currentDirectory = currentDirectory?.Directories[args[2]];
                }
            }
            else
            {
                if (args[0] == "dir")
                    currentDirectory?.Directories.Add(args[1], new Directory(currentDirectory));
                else
                    currentDirectory?.Files.Add(args[1], int.Parse(args[0]));
            }
        }
    }

    public class Directory
    {
        public Directory? Parent { get; set; }
        public Dictionary<string, Directory> Directories { get; set; }
        public Dictionary<string, int> Files { get; set; }

        public int Size
        {
            get
            {
                int total = 0;
                foreach (var dir in Directories.Values)
                {
                    total += dir.Size;
                }
                foreach (var fileSize in Files.Values)
                {
                    total += fileSize;
                }
                return total;
            }
        }

        public Directory(Directory? parent)
        {
            Parent = parent;
            Directories = new Dictionary<string, Directory>();
            Files = new Dictionary<string, int>();
        }

        public int GetDirectorySizes(int maxSize)
        {
            int total = 0;
            if (Size < maxSize)
                total += Size;
            foreach (var dir in Directories.Values)
            {
                total += dir.GetDirectorySizes(maxSize);
            }
            return total;
        }

        public List<int> ListDirectoryFileSizes(List<int> list)
        {
            list.Add(Size);
            foreach (Directory dir in Directories.Values)
            {
                list = dir.ListDirectoryFileSizes(list);
            }
            return list;
        }
    }
}