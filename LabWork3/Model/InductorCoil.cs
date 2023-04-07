using System.Numerics;

namespace Model
{
    /// <summary>
    /// Class InductorCoil.
    /// </summary>
    public class InductorCoil : PassiveElementBase
    {
        /// <summary>
        /// Inductance.
        /// </summary>
        private double _inductance;

        /// <summary>
        /// Frequency.
        /// </summary>
        private double _frequency;

        /// <summary>
        /// Gets or sets inductance.
        /// </summary>
        public double Inductance
        {
            get => _inductance;
            set => _inductance = CheckValue(value);
        }

        /// <summary>
        /// Gets or sets frequency.
        /// </summary>
        public double Frequency
        {
            get => _frequency;
            set => _frequency = CheckValue(value);
        }

        /// <summary>
        /// InductorCoil's constructor.
        /// </summary>
        /// <param name="inductance">Inductance.</param>
        /// <param name="frequency">Frequency.</param>
        public InductorCoil(double inductance, double frequency)
        {
            Inductance = inductance;
            Frequency = frequency;
        }

        /// <summary>
        /// InductorCoil's empty constructor.
        /// </summary>
        public InductorCoil() { }

        /// <summary>
        /// Gets calculate complex resistance.
        /// </summary>
        public override Complex Impedance =>
            new Complex(0, 2 * Math.PI * Frequency
                * Inductance);

        /// <summary>
        /// Gets output of information about the element.
        /// </summary>
        public override string Info =>
            $"\nСharacteristics of the inductor coil:\n" +
            $"Inductance = {Inductance} H\n" +
            $"Frequency = {Frequency} Hz";
    }
}
