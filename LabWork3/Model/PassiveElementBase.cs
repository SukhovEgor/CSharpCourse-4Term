using System.Numerics;

namespace Model
{
    /// <summary>
    /// Class PassiveElementBase.
    /// </summary>
    public abstract class PassiveElementBase
    {
        /// <summary>
        /// Minimum value.
        /// </summary>
        private const int _minValue = 0;

        /// <summary>
        /// Gets calculate complex resistance.
        /// </summary>
        public abstract Complex Impedance { get; }

        /// <summary>
        /// Gets output of information about the element.
        /// </summary>
        public abstract string Info { get; }

        /// <summary>
        /// Check correct value.
        /// </summary>
        /// <param name="value">Input parameter.</param>
        /// <returns>Input parameter.</returns>
        /// <exception cref="ArgumentException">Incorrect value.</exception>
        protected static double CheckValue(double value)
        {
            if (value <= _minValue)
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
