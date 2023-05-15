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
        /// Gets type of passive element for DataGridView.
        /// </summary>
        public override string PassiveElement => "Resistor";

        /// <summary>
        /// Gets parameters for DataGridView.
        /// </summary>
        public override string Parameters => $"R = {Resistance} Ohm";

        /// <summary>
        /// Gets impedance for DataGridView.
        /// </summary>
        public override string Impedance => RoundImpedance(GetImpedance, 3);

        /// <summary>
        /// Gets or sets resistance.
        /// </summary>
        public double Resistance
        {
            get => _resistance;
            set => _resistance = CheckValue(value);
        }

        /// <summary>
        /// Gets calculate complex resistance.
        /// </summary>
        public override Complex GetImpedance =>
            new Complex(Resistance, 0);

        /// <summary>
        /// Gets output of information about the element.
        /// </summary>
        public override string Info =>
            $"\nСharacteristics of the resistor:\n" +
            $"Resistance = {Resistance} Ohm";
    }
}
