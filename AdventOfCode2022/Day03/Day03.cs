using System.Text;

namespace AdventOfCode2022.Day03
{
    public class Day03
    {
        private readonly string _input;

        public Day03()
        {
            _input = File.ReadAllText("Day03/Input03.txt");
        }

        public string Stage1()
        {
            var input = _input.Split("\r\n").Select(d => new Stage1Helper(d[..^(d.Length / 2)], d[(d.Length / 2)..])).ToList();

            var lowerCase = Enumerable.Range('a', 26).Select(x => ((char)x, x - 96)).ToList();
            var upperCase = Enumerable.Range('A', 26).Select(x => ((char)x, x - 38)).ToList();
            var letters = lowerCase.Union(upperCase);

            var priority = 0;

            for (int i = 0; i < input.Count; i++)
            {
                StringBuilder s = new StringBuilder();
                List<char> doneChars = new List<char>();
                foreach (var letter in input[i].Left)
                {
                    if (!doneChars.Contains(letter) && input[i].Right.Contains(letter))
                    {
                        doneChars.Add(letter);

                        var value = letters.First(d => d.Item1 == letter).Item2;
                        priority = priority + value;
                    }
                }
            }

            return priority.ToString();
        }

        public string Stage2()
        {
            var input = _input.Split("\r\n").ToList();

            var lowerCase = Enumerable.Range('a', 26).Select(x => ((char)x, x - 96)).ToList();
            var upperCase = Enumerable.Range('A', 26).Select(x => ((char)x, x - 38)).ToList();
            var letters = lowerCase.Union(upperCase);

            List<Stage2Helper> groups = new List<Stage2Helper>();
            for (int i = 0; i < input.Count; i = i + 3)
            {
                groups.Add(new Stage2Helper(input[i], input[i + 1], input[i + 2]));
            }

            int priority = 0;
            foreach (var group in groups)
            {
                foreach (var letter in group.Letters)
                {
                    if (group.First.Contains(letter) && group.Second.Contains(letter) && group.Thired.Contains(letter))
                    {
                        var value = letters.First(d => d.Item1 == letter).Item2;
                        priority = priority + value;
                    }
                }
            }

            return priority.ToString();
        }
    }

    public class Stage1Helper
    {
        public Stage1Helper(string left, string right)
        {
            Left = left;
            Right = right;
        }

        public string Left { get; set; }

        public string Right { get; set; }
    }

    public class Stage2Helper
    {
        public Stage2Helper(string first, string second, string thired)
        {
            First = first;
            Second = second;
            Thired = thired;
        }

        public string First { get; set; }

        public string Second { get; set; }

        public string Thired { get; set; }

        public List<char> Letters => (First + Second + Thired).Distinct().ToList();
    }
}
