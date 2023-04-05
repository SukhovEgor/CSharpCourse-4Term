using System.Numerics;
namespace Model
{
    public abstract class PassiveElementBase
    {
        private const int MinValue = 0;

        public abstract Complex CalculationImpedance { get; }

        public abstract string Info { get; }

        public abstract string Impedance { get; }

        protected static double CheckValue(double value)
        {
            if (value <= MinValue)
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
