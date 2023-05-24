using System.Numerics;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// Types for XmlSerializer.
    /// </summary>
    [XmlInclude(typeof(Resistor))]
    [XmlInclude(typeof(Capacitor))]
    [XmlInclude(typeof(InductorCoil))]

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
        /// Gets impedance for DataGridView.
        /// </summary>
        [Browsable(false)]
        public Complex FilterImpedance => FilteredImpedance(GetImpedance, 3);

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

        /// <summary>
        /// Get round value of Impedance.
        /// </summary>
        /// <param name="complex">Passive Element.</param>
        /// <param name="digits">Digits.</param>
        /// <returns>impedance.</returns>
        public static string RoundImpedance
            (Complex complex, int digits)
        {

            double realResistance = Math.Round
                (complex.Real, digits);
            double imaginaryResistance = Math.Round
                (complex.Imaginary, digits);

            return ($"{realResistance}" +
                $" + ({imaginaryResistance})j Ohm");
        }

        /// <summary>
        /// Gets fdf.
        /// </summary>
        /// <param name="complex">dfsf.</param>
        /// <returns>fsdfs.</returns>
        public static Complex FilteredImpedance(Complex complex, int digits)
        {
            double realResistance = Math.Round
                (complex.Real, digits);
            double imaginaryResistance = Math.Round
                (complex.Imaginary, digits);
            var newComplex = new Complex(realResistance, imaginaryResistance);
            return newComplex;
        }

    }
}
