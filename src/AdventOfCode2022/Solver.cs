namespace AdventOfCode2022
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SolverAttribute : Attribute
    {
        public string Name;
        public int TimingIterations;
        public string Data;
    }
}
