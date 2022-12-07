using System.Text;

namespace AdventOfCode2022.Day05
{
    public class Day05
    {
        private readonly string _input;

        public Day05()
        {
            _input = File.ReadAllText("Day05/Input05.txt");
        }

        public string Stage1()
        {
            var input = _input.Split("\r\n\r\n");

            var ship = input[0];
            var commands = input[1].Split("\r\n").Select(d => new Command(d)).ToList();

            var stacks = GetStacks(ship).ToList();

            foreach (var command in commands)
            {
                Move(command, stacks);
            }

            StringBuilder s = new StringBuilder();

            stacks.Select(d => d.Containers.LastOrDefault()).ToList().ForEach(d => s.Append(d));

            return s.ToString();
        }

        private void Move(Command command, List<Stack> stacks)
        {
            var fromStack = stacks.First(d => d.Id == command.From);
            var toStack = stacks.First(d => d.Id == command.To);

            for (int i = 0; i < command.Amount; i++)
            {
                var container = fromStack.Containers.Last();

                fromStack.Containers.RemoveAt(fromStack.Containers.Count - 1);
                toStack.Containers.Add(container);
            }
        }

        public string Stage2()
        {
            var input = _input.Split("\r\n\r\n");

            var ship = input[0];
            var commands = input[1].Split("\r\n").Select(d => new Command(d)).ToList();

            var stacks = GetStacks(ship).ToList();

            foreach (var command in commands)
            {
                MoveStack(command, stacks);
            }

            StringBuilder s = new StringBuilder();

            stacks.Select(d => d.Containers.LastOrDefault()).ToList().ForEach(d => s.Append(d));

            return s.ToString();
        }

        private void MoveStack(Command command, List<Stack> stacks)
        {
            var fromStack = stacks.First(d => d.Id == command.From);
            var toStack = stacks.First(d => d.Id == command.To);

            int insertIndex = toStack.Containers.Count;

            for (int i = 0; i < command.Amount; i++)
            {
                var container = fromStack.Containers.Last();

                fromStack.Containers.RemoveAt(fromStack.Containers.Count - 1);
                toStack.Containers.Insert(insertIndex, container);
            }
        }

        private IEnumerable<Stack> GetStacks(string input)
        {
            var rows = input.Split("\r\n");

            var stackCount = rows.Last().Replace("[", "").Replace("]", "").Split(" ").Where(d => !string.IsNullOrWhiteSpace(d)).Count();

            List<char> sample = new List<char>();
            for (int i = 1; i <= stackCount; i++)
            {
                var indexRow = rows.Last();
                var id = int.Parse(indexRow[i * 4 - 3].ToString());

                var tmpRows = rows.ToList();
                tmpRows.Remove(indexRow);
                tmpRows.Reverse();

                List<char> containers = new List<char>();
                foreach (var row in tmpRows)
                {
                    var container = row[i * 4 - 3];
                    if (container == ' ')
                    {
                        break;
                    }

                    containers.Add(container);
                }

                yield return new Stack(id, containers);
            }
        }
    }

    public class Command
    {
        public Command(string input)
        {
            var words = input.Split(" ");

            Amount = int.Parse(words[1]);

            From = int.Parse(words[3]);

            To = int.Parse(words[5]);
        }

        public int Amount { get; set; }

        public int From { get; set; }

        public int To { get; set; }
    }

    public class Stack
    {
        public Stack(int id, List<char> containers)
        {
            Id = id;
            Containers = containers;
        }

        public int Id { get; set; }

        public List<char> Containers { get; set; }
    }
}
