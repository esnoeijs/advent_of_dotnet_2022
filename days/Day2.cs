
namespace aoc.days;

public class Day2 {
    
    enum Shape
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    };

    public static Task Run(FileInfo file)
    {
        Func<string, Shape> convertChallenge = shape => shape switch
        {
            "A" => Shape.Rock,
            "B" => Shape.Paper,
            "C" => Shape.Scissors,
            _ => throw new ArgumentOutOfRangeException()
        };

        Func<string, Shape> convertResponseByShape = shape => shape switch
        {
            "X" => Shape.Rock,
            "Y" => Shape.Paper,
            "Z" => Shape.Scissors,
            _ => throw new ArgumentOutOfRangeException()
        };

        Func<Shape, string, Shape> convertResponseByOutcome = (shape, outcome) => (shape, outcome) switch
        {
            (Shape.Rock, "X") => Shape.Scissors,
            (Shape.Rock, "Y") => Shape.Rock,
            (Shape.Rock, "Z") => Shape.Paper,
            (Shape.Paper, "X") => Shape.Rock,
            (Shape.Paper, "Y") => Shape.Paper,
            (Shape.Paper, "Z") => Shape.Scissors,
            (Shape.Scissors, "X") => Shape.Paper,
            (Shape.Scissors, "Y") => Shape.Scissors,
            (Shape.Scissors, "Z") => Shape.Rock,
            _ => throw new ArgumentOutOfRangeException()
        };

        Func<Shape, int> Win = shape => (int)shape + 6;
        Func<Shape, int> Draw = shape => (int)shape + 3;
        Func<Shape, int> Loss = shape => (int)shape;
        Func<Shape, Shape, int> Score = (challenge, response) => (challenge, response) switch
        {
            (Shape.Rock, Shape.Rock) => Draw(response),
            (Shape.Rock, Shape.Paper) => Win(response),
            (Shape.Rock, Shape.Scissors) => Loss(response),

            (Shape.Paper, Shape.Rock) => Loss(response),
            (Shape.Paper, Shape.Paper) => Draw(response),
            (Shape.Paper, Shape.Scissors) => Win(response),

            (Shape.Scissors, Shape.Rock) => Win(response),
            (Shape.Scissors, Shape.Paper) => Loss(response),
            (Shape.Scissors, Shape.Scissors) => Draw(response),
            _ => throw new ArgumentOutOfRangeException()
        };

        using (var sr = new StreamReader(file.FullName))
        {
            var score = 0;
            while (sr.Peek() >= 0)
            {
                var parts = sr.ReadLine()?.Split(' ');
                if (parts is null || parts.Length < 2) continue;
                var challenge = convertChallenge(parts[0]);
                var response = convertResponseByShape(parts[1]);

                score += Score(challenge, response);
            }
            Console.WriteLine($"part1 {score}");

        }

        using (var sr = new StreamReader(file.FullName))
        {
            var score = 0;
            while (sr.Peek() >= 0)
            {
                var parts = sr.ReadLine()?.Split(' ');
                if (parts is null || parts.Length < 2) continue;
                var challenge = convertChallenge(parts[0]);
                var response = convertResponseByOutcome(challenge, parts[1]);

                score += Score(challenge, response);
            }
            Console.WriteLine($"part2 {score}");

        }

        return Task.CompletedTask;
    }
}