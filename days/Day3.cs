
namespace aoc.days;

public class Day3
{
    const int LOWERCASE_A_OFFSET = 96; // ASCII value
    const int UPPERCASE_A_OFFSET = 65 - 27; // ASCII value - priority offset

    public static Task Run(FileInfo file)
    {
        using (var sr = new StreamReader(file.FullName))
        {
            var score = 0;
            while (sr.Peek() >= 0)
            {
                var line = sr.ReadLine();
                var halfPoint = (int)Math.Round((decimal)line?.Length / 2, 0, MidpointRounding.ToZero);

                var inRuckSack = line[..halfPoint].ToHashSet<char>();

                score += line[halfPoint..]
                    .Distinct<char>()
                    .Where(c => inRuckSack.Contains(c))
                    .Sum(c => ((int)c) - (Char.IsUpper(c) ? UPPERCASE_A_OFFSET : LOWERCASE_A_OFFSET));
            }
            Console.WriteLine($"{score}");

        }

        using (var sr = new StreamReader(file.FullName))
        {
            var score = 0;
            while (sr.Peek() >= 0)
            {
                var line1 = sr.ReadLine();
                var line2 = sr.ReadLine();
                var line3 = sr.ReadLine();

                if (null == line1 || null == line2 || null == line3) continue;
                score += line1
                    .Intersect(line2)
                    .Intersect(line3)
                    .Sum(c => ((int)c) - (Char.IsUpper(c) ? UPPERCASE_A_OFFSET : LOWERCASE_A_OFFSET));
            }
            Console.WriteLine(score);
        }


        return Task.CompletedTask;
    }
}