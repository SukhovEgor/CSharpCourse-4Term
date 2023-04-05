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
        /// Entering capacitor's values.
        /// </summary>
        /// <returns>Capacitor.</returns>
        public static Capacitor EnterValues()
        {
            var capacitor = new Capacitor();

            var actionList = new List<(Action Action, string)>
            {
                (
                    () =>
                    {
                        capacitor.Capacity = Convert.ToDouble(Console.ReadLine());
                    },
                    "\nEnter capacity of capacitor:"
                ),
                (
                    () =>
                    {
                        capacitor.Frequency = Convert.ToDouble(Console.ReadLine());
                    },
                    "\nEnter frequency of capacitor:"
                )
            };

            foreach (var action in actionList)
            {
                ActionHandler(action.Action, action.Item2);
            }

            return capacitor;
        }

        /// <summary>
        /// Correction exception.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <param name="inputMessage">Input message.</param>
        private static void ActionHandler
            (Action action, string inputMessage)
        {
            while (true)
            {
                Console.WriteLine(inputMessage);
                try
                {
                    action.Invoke();
                    return;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Repeat the input");
                }
            }
        }

        /// <summary>
        /// Gets calculate complex resistance.
        /// </summary>
        public override Complex CalculationImpedance =>
            new Complex(0, Math.Round(-1 / (2 * Math.PI * Frequency * Capacity * Math.Pow(10, -6)), 3));

        /// <summary>
        /// Gets output of information about the impedance.
        /// </summary>
        public override string Impedance =>
            $"Impedance = {CalculationImpedance.Imaginary}j Ohm";

        /// <summary>
        /// Gets output of information about the element.
        /// </summary>
        public override string Info =>
            $"\nСharacteristics of the capacitor:\n" +
            $"Capacity = {Capacity} microF\n" +
            $"Frequency = {Frequency} Hz\n" +
            $"Impedance = {CalculationImpedance.Imaginary}j Ohm";
    }
}
