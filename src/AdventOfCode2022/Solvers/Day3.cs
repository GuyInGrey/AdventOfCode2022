using System.Runtime.CompilerServices;

namespace AdventOfCode2022.Solvers
{
    public class Day3
    {
        [Solver(Name = "3.1", TimingIterations = 100000, Data = "3.txt")]
        public static object Part1(string input)
        {
            var sumPriorities = 0;
            var currentLine = 0;
            var lineEnding = 0;

            while (currentLine < input.Length)
            {
                for (var i = currentLine; i < input.Length; i += 2)
                {
                    if (input[i] == '\n') { lineEnding = i; break; }
                }

                for (var i = currentLine; i < currentLine + (lineEnding - currentLine) / 2; i++)
                {
                    for (var j = currentLine + ((lineEnding - currentLine) / 2); j < lineEnding; j++)
                    {
                        if (input[i] == input[j])
                        {
                            sumPriorities += (input[i] >= 65 && input[i] <= 90) ? input[i] - 38 : input[i] - 'a' + 1;
                            goto checkOver;
                        }
                    }
                }

                checkOver:;
                currentLine = lineEnding + 1;
            }


            return sumPriorities;
        }

        [Solver(Name = "3.2", TimingIterations = 100000, Data = "3.txt")]
        public static object Part2(string input)
        {
            var sumPriorities = 0;
            var currentLine = 0;
            var lineStart2 = 0;
            var lineStart3 = 0;
            var lineStart4 = 0;

            while (currentLine < input.Length)
            {
                for (var i = currentLine; i < input.Length; i += 2)
                {
                    if (input[i] == '\n') 
                    { 
                        if (lineStart2 == 0) { lineStart2 = ++i; } 
                        else if (lineStart3 == 0) { lineStart3 = ++i; } 
                        else { lineStart4 = ++i; break; }
                    }
                }

                for (var i = currentLine; i < lineStart2 - 1; i++)
                {
                    for (var j = lineStart2; j < lineStart3 - 1; j++)
                    {
                        if (input[i] == input[j])
                        {
                            for (var k = lineStart3; k < lineStart4 - 1; k++)
                            {
                                if (input[i] == input[k])
                                {
                                    sumPriorities += (input[i] >= 65 && input[i] <= 90) ? input[i] - 38 : input[i] - 'a' + 1;
                                    goto checkOver;
                                }
                            }
                        }
                    }
                }

                checkOver:;

                currentLine = lineStart4;

                lineStart2 = 0;
                lineStart3 = 0;
                lineStart4 = 0;
            }

            return sumPriorities;
        }
    }
}
