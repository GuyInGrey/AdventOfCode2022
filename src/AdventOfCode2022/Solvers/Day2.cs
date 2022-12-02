using System.Runtime.CompilerServices;

namespace AdventOfCode2022.Solvers
{
    public class Day2
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int Calculate(Dictionary<int, int> plays, string input)
        {
            var finalScore = 0;

            var play = 0;
            for (var i = 0; i < input.Length; i += 2)
            {
                switch (input[i])
                {
                    case 'B': play += 3; break;
                    case 'C': play += 6; break;
                    case 'Y': play += 1; break;
                    case 'Z': play += 2; break;
                }

                if (i % 4 == 2)
                {
                    finalScore += plays[play];
                    play = 0;
                }
            }

            return finalScore;
        }

        [Solver(Name = "2.1", TimingIterations = 100000, Data = "2.txt")]
        public static object Part1(string input)
        {
            var plays = new Dictionary<int, int>()
            {
                { 0, 4 }, // A X
                { 1, 8 }, // A Y
                { 2, 3 }, // A Z
                { 3, 1 }, // B X
                { 4, 5 }, // B Y
                { 5, 9 }, // B Z
                { 6, 7 }, // C X
                { 7, 2 }, // C Y
                { 8, 6 }  // C Z
            };

            return Calculate(plays, input);
        }

        [Solver(Name = "2.2", TimingIterations = 100000, Data = "2.txt")]
        public static object Part2(string input)
        {
            var plays = new Dictionary<int, int>()
            {
                { 0, 3 }, // A X
                { 1, 4 }, // A Y
                { 2, 8 }, // A Z
                { 3, 1 }, // B X
                { 4, 5 }, // B Y
                { 5, 9 }, // B Z
                { 6, 2 }, // C X
                { 7, 6 }, // C Y
                { 8, 7 }  // C Z
            };

            return Calculate(plays, input);
        }
    }
}
