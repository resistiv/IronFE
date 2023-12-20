using BenchmarkDotNet.Attributes;
using IronFE.Hash;
using System;
using System.Text;

namespace IronFE.Benchmarks
{
    [Config(typeof(Config))]
    [MemoryDiagnoser]
    public class CrcBenchmarks
    {
        private readonly byte[] bytes;

        public CrcBenchmarks()
        {
            // bytes = Encoding.ASCII.GetBytes("123456789");
            // bytes = new byte[32768];
            // bytes = new byte[1024];
            bytes = new byte[256];
            new Random().NextBytes(bytes);
        }

        [Benchmark]
        public void CalculateUsingTable()
        {
            Crc arc = new(CrcType.Crc16Arc);
            arc.Update(bytes);

            Crc xmodem = new(CrcType.Crc16Xmodem);
            xmodem.Update(bytes);
        }

        [Benchmark]
        public void CalculateManually()
        {
            Crc arc = new(CrcType.Crc16Arc, false);
            arc.Update(bytes);

            Crc xmodem = new(CrcType.Crc16Xmodem, false);
            xmodem.Update(bytes);
        }
    }
}
