
namespace aoc.days;

public class Day1 {

    readonly record struct elf(int nr, int calories);
        
    public static Task Run(FileInfo file)
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
}