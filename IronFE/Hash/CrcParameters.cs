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
        public string Name { get; } =
            !string.IsNullOrEmpty(name) ?
            name :
            throw new ArgumentNullException(nameof(name), Properties.Strings.CrcParametersNameNull);

        /// <summary>
        /// Gets the width, in bits, of this CRC.
        /// </summary>
        public int Width { get; } =
            width >= 8 && width <= 64 ?
            width :
            throw new ArgumentOutOfRangeException(nameof(width), Properties.Strings.CrcParametersWidthOutOfRange);

        /// <summary>
        /// Gets the generator polynomial of this CRC.
        /// </summary>
        public ulong Polynomial { get; } =
            polynomial <= ((((1UL << (width - 1)) - 1) << 1) | 1) ?
            polynomial :
            throw new ArgumentOutOfRangeException(nameof(polynomial), string.Format(Properties.Strings.CrcParametersPolynomialOutOfRange, width));

        /// <summary>
        /// Gets the initial value of the division register of this CRC.
        /// </summary>
        public ulong InitialValue { get; } =
            initialValue <= ((((1UL << (width - 1)) - 1) << 1) | 1) ?
            initialValue :
            throw new ArgumentOutOfRangeException(nameof(initialValue), string.Format(Properties.Strings.CrcParametersInitialValueOutOfRange, width));

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
        public ulong OutputXor { get; } =
            outputXor <= ((((1UL << (width - 1)) - 1) << 1) | 1) ?
            outputXor :
            throw new ArgumentOutOfRangeException(nameof(outputXor), string.Format(Properties.Strings.CrcParametersOutputXorOutOfRange, width));

        /// <summary>
        /// Compares equality of two <see cref="CrcParameters"/> objects.
        /// </summary>
        /// <param name="left">A <see cref="CrcParameters"/> object.</param>
        /// <param name="right">Another <see cref="CrcParameters"/> object.</param>
        /// <returns><c>true</c> if the objects are equivalent, <c>false</c> otherwise.</returns>
        public static bool operator ==(CrcParameters left, CrcParameters right) => left.Equals(right);

        /// <summary>
        /// Compares inequality of two <see cref="CrcParameters"/> objects.
        /// </summary>
        /// <param name="left">A <see cref="CrcParameters"/> object.</param>
        /// <param name="right">Another <see cref="CrcParameters"/> object.</param>
        /// <returns><c>false</c> if the objects are equivalent, <c>true</c> otherwise.</returns>
        public static bool operator !=(CrcParameters left, CrcParameters right) => !(left == right);

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

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Width, Polynomial, InitialValue, ReflectInput, ReflectOutput, OutputXor);
        }
    }
}
