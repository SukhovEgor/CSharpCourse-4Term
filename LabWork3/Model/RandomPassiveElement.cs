namespace Model
{
    /// <summary>
    /// Class RandomPassiveElement.
    /// </summary>
    public class RandomPassiveElement
    {
        /// <summary>
        /// Get Random Number.
        /// </summary>
        /// <param name="minimum">minimum.</param>
        /// <param name="maximum">maximum.</param>
        /// <returns>rounded value.</returns>
        public static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            double roundedValue = Math.Round
                (random.NextDouble() * (maximum - minimum) + minimum, 3);
            return roundedValue;
        }

        /// <summary>
        /// dfdf.
        /// </summary>
        /// <param name="passiveElementType">fdfdf.</param>
        /// <returns>fdfdf.</returns>
        public PassiveElementBase GetRandomParameters
            (PassiveElementType passiveElementType)
        {
            const double minResistance = 0.1;

            const double maxResistance = 1000.0;

            const double minCapacity = 0.001;

            const double maxCapacity = 1.0;

            const double minInductance = 0.001;

            const double maxInductance = 1.0;

            const double minFrequency = 1.0;

            const double maxFrequency = 500.0;

            switch (passiveElementType)
            {
                case PassiveElementType.Resistor:
                    {
                        double resistance = GetRandomNumber
                            (minResistance, maxResistance);
                        return new Resistor(resistance);
                    }

                case PassiveElementType.Capacitor:
                    {
                        double capacity = GetRandomNumber
                            (minCapacity, maxCapacity);
                        double frequency = GetRandomNumber
                            (minFrequency, maxFrequency);
                        return new Capacitor(capacity, frequency);
                    }

                case PassiveElementType.InductorCoil:
                    {
                        double capacity = GetRandomNumber
                            (minCapacity, maxCapacity);
                        double inductance = GetRandomNumber
                            (minInductance, maxInductance);
                        return new InductorCoil(capacity, inductance);
                    }

                default:
                    throw new ArgumentException
                        ("Enter the given passive elements");
            }
        }
    }
}
