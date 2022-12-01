using AdventOfCode2022.Day01;

internal class Program
{
    private static void Main(string[] args)
    {
        Day01 day = new Day01();

        var result = day.Stage2();

        Console.WriteLine(result);

        File.WriteAllText("Output.txt", result);

        Console.ReadKey();
    }
}