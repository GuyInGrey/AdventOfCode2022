using AdventOfCode2022.Solvers;

using System.Reflection;

namespace AdventOfCode2022
{
    internal class Program
    {
        static void Main()
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            var methods = Assembly.GetExecutingAssembly()
                .GetTypes().SelectMany(type => type.GetMethods())
                .Select(method => (method, method.GetCustomAttribute<SolverAttribute>()))
                .Where(method => method.Item2 is not null)
                .Select(method => (method.Item2, method.method));

            Console.Write("What to run? (All or name): ");
            var input = Console.ReadLine().ToLower().Trim();

            var toRun = input == "all" ? methods : methods.Where(m => m.Item1.Name.ToLower().Trim() == input);

            Console.Write("Timings? (Y/N): ");
            var timings = Console.ReadKey().Key == ConsoleKey.Y;
            Console.WriteLine();

            var readme = "# Grey's 2022 Advent Of Code\n\n#### Timings\n\nName | Iterations Ran | Time Per Iteration (+- ~10%)\n-- | -- | --\n";

            if (timings)
            {
                Console.WriteLine("Warming up...");

                foreach (var (attr, method) in toRun)
                {
                    var data = File.ReadAllText(@"..\..\..\Data\" + attr.Data);
                    var iterations = 10000;

                    for (var i = 0; i < iterations; i++)
                    {
                        method.Invoke(null, new object[] { data });
                    }
                }
            }

            Console.WriteLine("Processing...");

            foreach (var (attr, method) in toRun)
            {
                var data = File.ReadAllText(@"..\..\..\Data\" + attr.Data);
                var iterations = timings ? attr.TimingIterations : 1;

                var result = method.Invoke(null, new object[] { data });

                var start = HighResolutionDateTime.UtcNow;
                for (var i = 0; i < iterations; i++)
                {
                    method.Invoke(null, new object[] { data });
                }
                var end = HighResolutionDateTime.UtcNow;

                var durationText = "";

                var ms = (end - start).TotalMilliseconds / iterations;
                if (ms > 10)
                {
                    durationText = $"{Math.Round(ms, 4)} ms";
                }
                else
                {
                    durationText = $"{Math.Round(ms * 1000, 2)} µs";
                }

                Console.WriteLine($"{attr.Name} - Completed {iterations} iterations at {durationText}/iteration. Result: {result}");
                readme += attr.Name + " | " + iterations + " | " + durationText + "\n";
            }

            if (timings && input == "all")
            {
                File.WriteAllText(@"..\..\..\..\..\README.md", readme);
            }
        }
    }
}