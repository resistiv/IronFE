using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronFE.Tests.EncodingTests
{
    /// <summary>
    /// Provides a basis for tests on encodings.
    /// </summary>
    [DeploymentItem("TestData/Encoding/InputData.bin", "TestData")]
    public abstract class EncodingTests
    {
        /// <summary>
        /// Contains a basic set of un-encoded data to test decoded output against.
        /// </summary>
        protected static readonly byte[] InputData = Array.Empty<byte>();

        static EncodingTests()
        {
            InputData = File.ReadAllBytes("TestData/InputData.bin");

            // InputData.bin generation routine
            /*List<byte> input = new();

            for (int i = 1; i <= 300; i++)
            {
                for (ushort b = byte.MinValue; b <= byte.MaxValue; b++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        input.Add((byte)b);
                    }
                }
            }

            InputData = input.ToArray();
            File.WriteAllBytes("InputData.bin", InputData);*/
        }
    }
}
