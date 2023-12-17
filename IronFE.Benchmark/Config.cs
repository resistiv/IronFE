using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;

namespace IronFE.Benchmark
{
    public class Config : ManualConfig
    {
        public Config()
        {
            AddJob(Job.MediumRun.WithToolchain(InProcessNoEmitToolchain.Instance));
        }
    }
}
