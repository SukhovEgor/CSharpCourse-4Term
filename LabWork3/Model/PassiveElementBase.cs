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

        // TODO: Это должен быть метод (+)

        /// <summary>
        /// Gets calculate complex resistance.
        /// </summary>
        /// <returns>Complex resistance.</returns>
        public abstract Complex GetImpedance();

        // TODO: Это должен быть метод (+)

        /// <summary>
        /// Gets output of information about the element.
        /// </summary>
        /// <returns>Info.</returns>
        public abstract string GetInfo();

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

            return value;
        }

    }
}
