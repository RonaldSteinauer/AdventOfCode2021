using AdventOfCode2022.Day01;
using AdventOfCode2022.Day02;
using AdventOfCode2022.Day03;
using AdventOfCode2022.Day04;

internal class Program
{
    private static void Main(string[] args)
    {
        Day04 day = new Day04();

        var result = day.Stage2();

        Console.WriteLine(result);

        File.WriteAllText("Output.txt", result);

        Console.ReadKey();
    }
}