using System.Numerics;

namespace Model
{
    /// <summary>
    /// Class Resistors.
    /// </summary>
    public class Resistor : PassiveElementBase
    {
        /// <summary>
        /// Resistor's resistance.
        /// </summary>
        private double _resistance;

        /// <summary>
        /// Gets or sets resistance.
        /// </summary>
        public double Resistance
        {
            get => _resistance;
            set => _resistance = CheckValue(value);
        }

        // TODO: добавить конструктор (+)

        /// <summary>
        /// Resistor's constructor.
        /// </summary>
        /// <param name="resistance">Resistance.</param>
        public Resistor(double resistance)
        {
            Resistance = resistance;
        }

        /// <summary>
        /// Resistor's empty constructor.
        /// </summary>
        public Resistor() { }

        /// <summary>
        /// Gets calculate complex resistance.
        /// </summary>
        /// <returns>Impedance.</returns>
        public override Complex GetImpedance() =>
            new Complex(Resistance, 0);

        /// <summary>
        /// Gets output of information about the element.
        /// </summary>
        /// <returns>Info.</returns>
        public override string GetInfo() =>
            $"\nСharacteristics of the resistor:\n" +
            $"Resistance = {Resistance} Ohm";
    }
}
