using BenchmarkDotNet.Attributes;
using IronFE.Tool;

namespace IronFE.Benchmarks
{
    [Config(typeof(Config))]
    [MemoryDiagnoser]
    public class BitReverserBenchmark
    {
        private int reverseCount = 5000000;

        [Benchmark]
        public void ReverseUsingVariableLength()
        {
            for (int i = 0; i < reverseCount; i++)
            {
                BitReverser.ReverseValue((ulong)i, 64);
            }
        }

        [Benchmark]
        public void ReverseUsingTable()
        {
            for (int i = 0; i < reverseCount; i++)
            {
                BitReverser.ReverseUInt64((ulong)i);
            }
        }
    }
}
