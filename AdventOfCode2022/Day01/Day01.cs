namespace AdventOfCode2022.Day01
{
    public class Day01
    {
        private readonly string[] _input;

        public Day01()
        {
            _input = File.ReadAllLines("Day01/Input01.txt");
        }

        public string Stage1()
        {
            var localCount = 0;
            var max = 0;

            foreach (var text in _input)
            {
                if (!string.IsNullOrWhiteSpace(text))
                {
                    var count = int.Parse(text);
                    localCount += count;

                    if (localCount > max)
                        max = localCount;
                }
                else
                {
                    localCount = 0;
                }
            }

            return max.ToString();
        }

        public string Stage2()
        {
            var localCount = 0;
            var max = 0;
            List<int> all = new List<int>();

            foreach (var text in _input)
            {
                if (!string.IsNullOrWhiteSpace(text))
                {
                    var number = int.Parse(text);
                    localCount += number;

                    if (localCount > max)
                    {
                        max = localCount;
                    }
                }
                else
                {
                    all.Add(max);
                    localCount = 0;
                    max = 0;
                }
            }

            return all.OrderByDescending(d => d).Take(3).Sum().ToString();
        }
    }
}
