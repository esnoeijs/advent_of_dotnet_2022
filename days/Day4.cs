
namespace aoc.days;

public class Day4
{
    public record struct Range(int idx, int min, int max)
    {
        public static Range FromString(int idx, string r)
        {
            var range = r.Split("-").Select(x => Int32.Parse(x));
            return new Range(idx, range.ElementAt(0), range.ElementAt(1));
        }
    }

    public static Task Run(FileInfo file)
    {
        using (var sr = new StreamReader(file.FullName))
        {
            var score = 0;
            while (sr.Peek() >= 0)
            {
                var line = sr.ReadLine();

                var pairs = line.Split(",").Select((x, idx) => Range.FromString(idx, x));

                for (var i = 0; i < pairs.Count(); i++)
                {
                    for (var j = i + 1; j < pairs.Count(); j++)
                    {
                        var pair = pairs.ElementAt(i);
                        var pair2 = pairs.ElementAt(j);

                        if (pair.min <= pair2.min && pair.max >= pair2.max)
                        {
                            // Console.WriteLine($"pair {pair} contains {pair2}");
                            score += 1;
                        }
                        else if (pair.min >= pair2.min && pair.max <= pair2.max)
                        {
                            // Console.WriteLine($"pair {pair} contains {pair2}");
                            score += 1;
                        }
                        else
                        {
                            // Console.WriteLine($"pair {pair} doesnt contains {pair2}");
                        }
                    }
                }
            }
            Console.WriteLine($"Score: {score}");
        }


        using (var sr = new StreamReader(file.FullName))
        {
            var score = 0;
            while (sr.Peek() >= 0)
            {
                var line = sr.ReadLine();
                var pairs = line.Split(",").Select((x, idx) => Range.FromString(idx, x));

                if (pairs.Any(range =>
                {
                    foreach (var range2 in pairs)
                    {
                        if (range.idx == range2.idx) continue;
                        if (range.min >= range2.min && range.min <= range2.max)
                        {
                            return true;
                        }
                        else if (range.max <= range2.max && range.max >= range2.min)
                        {
                            return true;
                        }
                    }
                    return false;
                }))
                {
                    score += 1;
                }
            }
            Console.WriteLine($"Score: {score}");
        }

        return Task.CompletedTask;
    }
}