namespace Model
{
    public abstract class PassiveElementBase
    {
        protected const int MinValue = 0;

        public abstract double CalculateComplexResistance();
    }
}