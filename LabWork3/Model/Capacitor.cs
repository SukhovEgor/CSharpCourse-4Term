using System.Numerics;

namespace Model
{
    public class Capacitor : PassiveElementBase
    {
        private double _сapacity;

        private double _frequency;
        public double Capacity
        {
            get => _сapacity;
            set => _сapacity = value;
        }
        public double Frequency
        {
            get => _frequency;
            set => _frequency = value;
        }

        public Capacitor(double сapacity, double frequency)
        {
            Capacity = сapacity;
            Frequency = frequency;
        }

        public Capacitor() { }

        public override Complex CalculationImpedance =>
            new Complex(0, Math.Round(-1 / (2 * Math.PI * Frequency * Capacity * Math.Pow(10, -6)), 3));

        public override string Info =>
            $"Сharacteristics of the capacitor:\n" +
            $"Capacity = {Capacity} microF\n" +
            $"Frequency = {Frequency} Hz\n" +
            $"Impedance = {CalculationImpedance.Imaginary}j Ohm";
    }
}
