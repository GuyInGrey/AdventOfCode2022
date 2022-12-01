using AdventOfCode2022.Solvers;

namespace AdventOfCode2022
{
    internal class Program
    {
        static void Main()
        {
            var d = new Day1();
            var input = File.ReadAllText(@"..\..\..\Data\1.txt");

            var start = DateTime.Now;
            var iter = 1000000;
            for (var i = 0; i < iter; i++)
            {
                d.Part1(input);
            }
            var end = DateTime.Now;
            Console.WriteLine(Math.Round((end - start).TotalMilliseconds / iter * 1000, 2) + "µs - Part 1 (" + d.Part1(input) + ")");

            //start = DateTime.Now;
            //iter = 100000;
            //for (var i = 0; i < iter; i++)
            //{
            //    d.Part2(input);
            //}
            //end = DateTime.Now;
            //Console.WriteLine(Math.Round((end - start).TotalMilliseconds / iter * 1000, 2) + "µs - Part 2");
        }
    }
}