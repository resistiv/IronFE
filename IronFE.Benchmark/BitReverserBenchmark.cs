using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;
using IronFE.Tool;

namespace IronFE.Test
{
    public class Config : ManualConfig
    {
        public Config()
        {
            AddJob(Job.MediumRun.WithToolchain(InProcessNoEmitToolchain.Instance));
        }
    }

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
