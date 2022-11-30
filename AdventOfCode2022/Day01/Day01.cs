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
            var output = string.Empty;
            
            foreach (var text in _input)
            {
                output += text;
            }

            return output;
        }
    }
}
