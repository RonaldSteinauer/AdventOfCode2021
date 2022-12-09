using AdventOfCode2022.Day01;
using AdventOfCode2022.Day02;
using AdventOfCode2022.Day03;
using AdventOfCode2022.Day04;
using AdventOfCode2022.Day05;
using AdventOfCode2022.Day06;

internal class Program
{
    private static void Main(string[] args)
    {
        Day06 day = new Day06();

        var result = day.Stage2();

        Console.WriteLine(result);

        File.WriteAllText("Output.txt", result);

        Console.ReadKey();
    }
}