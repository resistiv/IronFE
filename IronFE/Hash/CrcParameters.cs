﻿using System;

namespace IronFE.Hash
{
    /// <summary>
    /// Stores the parameters for a particular CRC.
    /// </summary>
    public readonly struct CrcParameters(string name, int width, ulong polynomial, ulong initialValue, bool reflectInput, bool reflectOutput, ulong outputXor)
    {
        /// <summary>
        /// Gets the formal or expanded name of this CRC.
        /// </summary>
        public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name), "CRC name must be defined.");

        /// <summary>
        /// Gets the width, in bits, of this CRC.
        /// </summary>
        public int Width { get; } = width >= 8 && width <= 64 ? width : throw new ArgumentOutOfRangeException(nameof(width), "Width must be between 8 and 64, inclusive.");

        /// <summary>
        /// Gets the generator polynomial of this CRC.
        /// </summary>
        public ulong Polynomial { get; } = polynomial;

        /// <summary>
        /// Gets the initial value of the division register of this CRC.
        /// </summary>
        public ulong InitialValue { get; } = initialValue;

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
        public ulong OutputXor { get; } = outputXor;
    }
}
