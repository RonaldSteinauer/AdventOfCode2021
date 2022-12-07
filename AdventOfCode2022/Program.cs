using AdventOfCode2022.Day01;
using AdventOfCode2022.Day02;
using AdventOfCode2022.Day03;
using AdventOfCode2022.Day04;
using AdventOfCode2022.Day05;

internal class Program
{
    private static void Main(string[] args)
    {
        Day05 day = new Day05();

        var result = day.Stage2();

        Console.WriteLine(result);

        File.WriteAllText("Output.txt", result);

        Console.ReadKey();
    }
}