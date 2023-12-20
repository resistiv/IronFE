using System;
using System.Diagnostics.CodeAnalysis;

namespace IronFE.Hash
{
    /// <summary>
    /// Stores the parameters for a particular CRC.
    /// </summary>
    /// <remarks>
    /// Adapted from Ross Williams' <i>A Painless Guide to CRC Error Detection Algorithms</i> (1993).
    /// </remarks>
    public readonly struct CrcParameters(string name, int width, ulong polynomial, ulong initialValue, bool reflectInput, bool reflectOutput, ulong outputXor) : IEquatable<CrcParameters>
    {
        /// <summary>
        /// Gets the formal or expanded name of this CRC.
        /// </summary>
        public string Name { get; } = !string.IsNullOrEmpty(name) ? name : throw new ArgumentNullException(nameof(name), "CRC name must be defined.");

        /// <summary>
        /// Gets the width, in bits, of this CRC.
        /// </summary>
        public int Width { get; } = width >= 8 && width <= 64 ? width : throw new ArgumentOutOfRangeException(nameof(width), "Width must be between 8 and 64, inclusive.");

        /// <summary>
        /// Gets the generator polynomial of this CRC.
        /// </summary>
        public ulong Polynomial { get; } = polynomial < (1UL << width) ? polynomial : throw new ArgumentOutOfRangeException(nameof(polynomial), $"Polynomial must fit within the given bit width ({width} bits).");

        /// <summary>
        /// Gets the initial value of the division register of this CRC.
        /// </summary>
        public ulong InitialValue { get; } = initialValue < (1UL << width) ? initialValue : throw new ArgumentOutOfRangeException(nameof(initialValue), $"Initial value must fit within the given bit width ({width} bits).");

        /// <summary>
        /// Gets a value indicating whether input data is reflected before being processed.
        /// </summary>
        public bool ReflectInput { get; } = reflectInput;

        /// <summary>
        /// Gets a value indicating whether the resultant register value is reflected before being output.
        /// </summary>
        public bool ReflectOutput { get; } = reflectOutput;

        /// <summary>
        /// Gets the value that is XOR'd with the resultant register value before being output.
        /// </summary>
        public ulong OutputXor { get; } = outputXor < (1UL << width) ? outputXor : throw new ArgumentOutOfRangeException(nameof(outputXor), $"Output XOR mask must fit within the given bit width ({width} bits).");

        /// <inheritdoc/>
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is CrcParameters parameters)
            {
                return Equals(parameters);
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool Equals(CrcParameters other)
        {
            return Name.Equals(other.Name) &&
                   Width == other.Width &&
                   Polynomial == other.Polynomial &&
                   InitialValue == other.InitialValue &&
                   ReflectInput == other.ReflectInput &&
                   ReflectOutput == other.ReflectOutput &&
                   OutputXor == other.OutputXor;
        }
    }
}
