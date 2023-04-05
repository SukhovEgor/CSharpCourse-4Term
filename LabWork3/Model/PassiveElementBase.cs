using System.Numerics;
namespace Model
{
    public abstract class PassiveElementBase
    {
        /// <summary>
        /// Minimum value.
        /// </summary>
        private const int MinValue = 0;

        /// <summary>
        /// Calculate complex resistance.
        /// </summary>
        public abstract Complex CalculationImpedance { get; }

        /// <summary>
        /// Gets output of information about the element.
        /// </summary>
        public abstract string Info { get; }

        /// <summary>
        /// Gets output of information about the impedance.
        /// </summary>
        public abstract string Impedance { get; }

        /// <summary>
        /// Check correct value.
        /// </summary>
        /// <param name="value">Input parameter.</param>
        /// <returns>Input parameter.</returns>
        /// <exception cref="ArgumentException">Incorrect value.</exception>
        protected static double CheckValue(double value)
        {
            if (value <= MinValue)
            {
                throw new ArgumentException
                    ("The value should not be negative");
            }
            else
            {
                return value;
            }
        }

    }
}
