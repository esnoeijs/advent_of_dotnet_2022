
namespace aoc;
using System;
using System.Collections;
using System.Collections.Generic;

readonly record struct elf(int nr, int calories);

class Day1
{
    public static void Main()
    {
        using (var sr = new StreamReader("inputs/day1"))
        {
            var elfNr = 1;
            var elfCalories = 0;

            var topElves = new List<elf>();
            while (sr.Peek() >= 0)
            {
                var line = sr.ReadLine();
                if (line.Length > 1) {
                    elfCalories +=  Int32.Parse(line);
                } else {
                    topElves.Add(new elf(elfNr, elfCalories));
                    elfNr++;
                    elfCalories=0;
                }
            }
            topElves.Sort((elf x, elf y) => y.calories.CompareTo(x.calories));

            Console.WriteLine($"{topElves[0].nr} {topElves[0].calories}");
            Console.WriteLine($"{topElves.Take(3).Sum(x => x.calories)}");
        }
    }
}