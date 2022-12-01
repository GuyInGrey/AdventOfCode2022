using System;
using System.Text;

namespace AdventOfCode2022.Solvers
{
    [Solver(Day = 1)]
    public class Day1
    {
        public object Part1(string input)
        {
            var currentElfTotal = 0;
            var maxElfTotal_result = 0;
            int currentFoodItem = 0;

            for (var i = 0; i < input.Length; i++)
            {
                var c = input[i];
                if (c >= 48 && c <= 57) // If the character is a number
                {
                    currentFoodItem = currentFoodItem * 10 + (c - '0');
                }
                else if (currentFoodItem > 0) // If the previous character was a number
                {
                    currentElfTotal += currentFoodItem;
                    currentFoodItem = 0;
                }
                else // Double new-line, meaning new elf
                {
                    if (currentElfTotal > maxElfTotal_result) { maxElfTotal_result = currentElfTotal; }
                    currentElfTotal = 0;
                }
            }

            return maxElfTotal_result;
        }

        public object Part2(string input)
        {
            var elves = input.Trim().Split("\n\n");
            var groupedElfCalories = elves.Select(e =>
            {
                return e.Split('\n').Select(c => int.Parse(c.Trim())).Sum();
            });
            var top3 = groupedElfCalories.OrderByDescending(t => t).Take(3);
            return top3.Sum();
        }
    }
}
