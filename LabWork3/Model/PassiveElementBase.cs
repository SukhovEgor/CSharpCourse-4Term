using System.Numerics;
namespace Model
{
    public abstract class PassiveElementBase
    {
        protected const int MinValue = 0;

        public abstract Complex CalculationImpedance { get; }

        public abstract string Info { get; }

    }
}