namespace AdventOfCode2022.Day04
{
    public class Day04
    {
        private readonly string _input;

        public Day04()
        {
            _input = File.ReadAllText("Day04/Input04.txt");
        }

        public string Stage1()
        {
            var rows = _input.Split("\r\n").Select(d => new Row(d));

            var obsolte = rows.Where(d => d.Contains).Count();

            return obsolte.ToString();
        }

        public string Stage2()
        {
            var rows = _input.Split("\r\n").Select(d => new Row(d));

            var obsolte = rows.Where(d => d.Overlap).Count();

            return obsolte.ToString();
        }
    }

    public class Row
    {
        public Row(string input)
        {
            var values = input.Split(",");

            Left = new Data(values[0]);
            Right = new Data(values[1]);
        }

        public Data Left { get; set; }

        public Data Right { get; set; }

        public bool Contains => (Left.From >= Right.From && Left.To <= Right.To) || (Right.From >= Left.From && Right.To <= Left.To);

        public bool Overlap => Left.From <= Right.To && Left.To >= Right.From;
    }

    public class Data
    {
        public Data(string input)
        {
            var values = input.Split("-").ToArray();

            From = int.Parse(values[0]);
            To = int.Parse(values[1]);
        }

        public int From { get; set; }

        public int To { get; set; }
    }
}
