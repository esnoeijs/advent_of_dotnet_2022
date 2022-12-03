
namespace aoc;
using System;
using System.Collections.Generic;
using System.CommandLine;

readonly record struct elf(int nr, int calories);

class Aoc
{
    static async Task<int> Main(string[] args)
    {
        var fileOption = new Option<FileInfo?>(
            name: "--file",
            description: "The file to read and display on the console.");

        var day1Command = new Command("day1"){fileOption};
        day1Command.SetHandler((file) => Day1(file!), fileOption);

        var day2Command = new Command("day2"){fileOption};
        day2Command.SetHandler((file) => Day2(file!), fileOption);

        var rootCommand = new RootCommand("Sample app for System.CommandLine");
        rootCommand.AddCommand(day1Command);
        rootCommand.AddCommand(day2Command);

        return await rootCommand.InvokeAsync(args);

    }
    
    internal static Task Day1(FileInfo file)
    {
        using (var sr = new StreamReader(file.FullName))
        {
            var elfNr = 1;
            var elfCalories = 0;

            var topElves = new List<elf>();
            while (sr.Peek() >= 0)
            {
                var line = sr.ReadLine();
                if (line?.Length > 1)
                {
                    elfCalories += int.Parse(line);
                }
                else
                {
                    topElves.Add(new elf(elfNr, elfCalories));
                    elfNr++;
                    elfCalories = 0;
                }
            }
            topElves.Sort((x, y) => y.calories.CompareTo(x.calories));

            Console.WriteLine($"{topElves[0].nr} {topElves[0].calories}");
            Console.WriteLine($"{topElves.Take(3).Sum(x => x.calories)}");
        }

        return Task.CompletedTask;
    }

    internal static Task Day2(FileInfo file)
    {
        using (var sr = new StreamReader(file.FullName))
        {

            while (sr.Peek() >= 0)
            {
                var line = sr.ReadLine();
                Console.WriteLine(line);
            }

        }

        return Task.CompletedTask;
    }
}