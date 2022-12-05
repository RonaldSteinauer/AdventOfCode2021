using AdventOfCode2022.Day01;
using AdventOfCode2022.Day02;

internal class Program
{
    private static void Main(string[] args)
    {
        Day02 day = new Day02();

        var result = day.Stage2();

        Console.WriteLine(result);

        File.WriteAllText("Output.txt", result);

        Console.ReadKey();
    }
}