using BenchmarkDotNet.Running;
using IronFE.Test;

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
