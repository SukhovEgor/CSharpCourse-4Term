using System.Numerics;

namespace Model
{
    public class InductorCoil : PassiveElementBase
    {
        private double _inductance;

        private double _frequency;
        public double Inductance
        {
            get => _inductance;
            set => _inductance = value;
        }
        public double Frequency
        {
            get => _frequency;
            set => _frequency = value;
        }

        public InductorCoil(double inductance, double frequency)
        {
            Inductance = inductance;
            Frequency = frequency;
        }

        public InductorCoil() { }

        public override Complex CalculationImpedance => 
            new Complex(0, Math.Round(2 * Math.PI * Frequency * Inductance * Math.Pow(10, -3), 3));

        public override string Info =>
            $"\nСharacteristics of the inductor coil:\n" +
            $"Inductance = {Inductance} microH\n" +
            $"Frequency = {Frequency} Hz\n" +
            $"Impedance = {CalculationImpedance.Imaginary}j mOhm";
    }
}
