namespace AdventOfCode2022.Day06
{
    internal class Day06
    {
        private readonly string _input;

        public Day06()
        {
            _input = File.ReadAllText("Day06/Input06.txt");
        }

        public string Stage1()
        {
            return FindMarker(4);
        }

        private string FindMarker(int length)
        {
            for (int i = 0; i < _input.Length - length; i++)
            {
                var marker = _input.Substring(i, length);

                if (marker.ToArray().Distinct().Count() == length)
                {
                    return (i + length).ToString();
                }
            }

            return "Not found!";
        }

        public string Stage2()
        {
            return FindMarker(14);
        }
    }
}
