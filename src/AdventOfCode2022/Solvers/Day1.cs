namespace AdventOfCode2022.Solvers
{
    public class Day1
    {
        [Solver(Name = "1.1", TimingIterations = 100000, Data = "1.txt")]
        public static object Part1(string input)
        {
            var currentElfTotal = 0;
            var maxElfTotal_result = 0;
            var currentFoodItem = 0;

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
            if (currentFoodItem > 0)
            {
                currentElfTotal += currentFoodItem;
                if (currentElfTotal > maxElfTotal_result) { maxElfTotal_result = currentElfTotal; }
            }

            return maxElfTotal_result;
        }

        [Solver(Name = "1.2", TimingIterations = 100000, Data = "1.txt")]
        public static object Part2(string input)
        {
            var currentFoodItem = 0;
            var currentElfTotal = 0;
            var elves = new List<int>(512);

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
                    elves.Add(currentElfTotal);
                    currentElfTotal = 0;
                }
            }
            currentElfTotal += currentFoodItem;
            elves.Add(currentElfTotal);

            var top3 = elves.OrderByDescending(o => o).Take(3);
            return top3.Sum();
        }
    }
}
