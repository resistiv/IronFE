using BenchmarkDotNet.Running;

namespace IronFE.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<BitReverserBenchmark>();
        }
    }
}
