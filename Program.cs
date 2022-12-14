
namespace aoc;
using System;
using System.CommandLine;
using days;

class Aoc
{
    static async Task<int> Main(string[] args)
    {
        var fileOption = new Option<FileInfo?>(name: "--file",description: "input file");
        var rootCommand = new RootCommand("aoc");
        var commands = new HashSet<Func<FileInfo?, Task>> {
            (file) => Day1.Run(file!),
            (file) => Day2.Run(file!),
            (file) => Day3.Run(file!),
        }.Select((run, idx) =>
        {
            var cmd = new Command($"day{idx + 1}") { fileOption };
            cmd.SetHandler(run, fileOption);
            return cmd;
        });

        foreach (var cmd in commands)
        {
            rootCommand.AddCommand(cmd);
        }

        return await rootCommand.InvokeAsync(args);
    }
}