using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace Model
{
    public class Resistor : PassiveElementBase
    {
        private double _resistance;
        
        public double Resistance
        {
            get => _resistance;
            set => _resistance = value;
        }

        public Complex GetImpedance(double resistance)
        {
            return CalculationImpedance;
        }
        public override Complex CalculationImpedance =>
            new Complex(Resistance, 0);

        public override string Info =>
            $"Сharacteristics of the resistor:\n" +
            $"Resistance = {Resistance} Ohm\n" +
            $"Impedance = {CalculationImpedance.Real} Ohm";
    }
}
