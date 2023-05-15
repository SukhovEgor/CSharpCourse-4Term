using System.Numerics;
using System.ComponentModel;

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
        /// Gets type of passive element for DataGridView.
        /// </summary>
        public abstract string PassiveElement { get; }

        /// <summary>
        /// Gets parameters for DataGridView.
        /// </summary>
        public abstract string Parameters { get; }

        /// <summary>
        /// Gets impedance for DataGridView.
        /// </summary>
        public abstract string Impedance { get; }

        /// <summary>
        /// Gets calculate complex resistance.
        /// </summary>
        [Browsable(false)]
        public abstract Complex GetImpedance { get; }

        /// <summary>
        /// Gets output of information about the element.
        /// </summary>
        [Browsable(false)]
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
