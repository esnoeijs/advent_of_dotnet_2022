
namespace aoc;
using System;
using System.CommandLine;
using days;

class Aoc
{
    static async Task<int> Main(string[] args)
    {
        var fileOption = new Option<FileInfo?>(
            name: "--file",
            description: "The file to read and display on the console.");

        var day1Command = new Command("day1") { fileOption };
        day1Command.SetHandler((file) => Day1.Run(file!), fileOption);

        var day2Command = new Command("day2") { fileOption };
        day2Command.SetHandler((file) => Day2.Run(file!), fileOption);

        var rootCommand = new RootCommand("Sample app for System.CommandLine");
        rootCommand.AddCommand(day1Command);
        rootCommand.AddCommand(day2Command);

        return await rootCommand.InvokeAsync(args);

    }
}