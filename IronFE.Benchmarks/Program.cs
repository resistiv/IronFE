using BenchmarkDotNet.Running;

namespace IronFE.Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<BitReverserBenchmark>();
        }
    }
}
