using System.Numerics;

namespace Model
{
    /// <summary>
    /// Class Capacitor.
    /// </summary>
    public class Capacitor : PassiveElementBase
    {
        /// <summary>
        /// Capacity.
        /// </summary>
        private double _сapacity;

        /// <summary>
        /// Frequency.
        /// </summary>
        private double _frequency;

        /// <summary>
        /// Gets or sets capacity.
        /// </summary>
        public double Capacity
        {
            get => _сapacity;
            set => _сapacity = CheckValue(value);
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
        /// Capacitor's constructor.
        /// </summary>
        /// <param name="сapacity">Capacity.</param>
        /// <param name="frequency">Frequency.</param>
        public Capacitor(double сapacity, double frequency)
        {
            Capacity = сapacity;
            Frequency = frequency;
        }

        /// <summary>
        /// Capacitor's empty constructor.
        /// </summary>
        public Capacitor() { }

        /// <summary>
        /// Gets calculate complex resistance.
        /// </summary>
        public override Complex Impedance =>
            new Complex(0, -1 / (2 * Math.PI * Frequency * Capacity));

        /// <summary>
        /// Gets output of information about the element.
        /// </summary>
        public override string Info =>
            $"\nСharacteristics of the capacitor:\n" +
            $"Capacity = {Capacity} F\n" +
            $"Frequency = {Frequency} Hz";
    }
}
