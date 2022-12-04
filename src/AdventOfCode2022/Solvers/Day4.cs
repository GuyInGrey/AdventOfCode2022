namespace AdventOfCode2022.Solvers
{
    public class Day4
    {
        [Solver(Name = "4.1", TimingIterations = 100000, Data = "4.txt")]
        public static object Part1(string input)
        {
            var count = 0;

            var num1 = -1;
            var num2 = -1;
            var num3 = -1;
            var numCur = 0;

            for (var i = 0; i < input.Length; i++)
            {
                var c = input[i];

                if (c == '\n')
                {
                    if ((num1 >= num3 && num2 <= numCur) || (num3 >= num1 && numCur <= num2))
                    {
                        count++;
                    }

                    num1 = -1;
                    num2 = -1;
                    num3 = -1;
                    numCur = 0;
                }
                else if (c >= 48 && c <= 57)
                {
                    numCur = numCur * 10 + (c - '0');
                }
                else
                {
                    if (num1 == -1) { num1 = numCur; }
                    else if (num2 == -1) { num2 = numCur; }
                    else if (num3 == -1) { num3 = numCur; }
                    numCur = 0;
                }
            }

            return count;
        }

        [Solver(Name = "4.2", TimingIterations = 100000, Data = "4.txt")]
        public static object Part2(string input)
        {
            var count = 0;

            var num1 = -1;
            var num2 = -1;
            var num3 = -1;
            var numCur = 0;

            for (var i = 0; i < input.Length; i++)
            {
                var c = input[i];

                if (c == '\n')
                {
                    if ( (num1 <= numCur && num3 <= num2) )
                    {
                        count++;
                    }

                    num1 = -1;
                    num2 = -1;
                    num3 = -1;
                    numCur = 0;
                }
                else if (c >= 48 && c <= 57)
                {
                    numCur = numCur * 10 + (c - '0');
                }
                else
                {
                    if (num1 == -1) { num1 = numCur; }
                    else if (num2 == -1) { num2 = numCur; }
                    else if (num3 == -1) { num3 = numCur; }
                    numCur = 0;
                }
            }

            return count;
        }
    }
}
