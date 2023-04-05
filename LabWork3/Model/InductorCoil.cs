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
        /// Entering Inductor Coil's values.
        /// </summary>
        /// <returns>InductorCoil.</returns>
        public static InductorCoil EnterValues()
        {
            var inductorCoil = new InductorCoil();

            var actionList = new List<(Action Action, string)>
            {
                (
                    () =>
                    {
                        inductorCoil.Inductance = Convert.ToDouble(Console.ReadLine());
                    },
                    "\nEnter inductance of inductor coil:"
                ),
                (
                    () =>
                    {
                        inductorCoil.Frequency = Convert.ToDouble(Console.ReadLine());
                    },
                    "\nEnter frequency of inductor coil:"
                )
            };

            foreach (var action in actionList)
            {
                ActionHandler(action.Action, action.Item2);
            }

            return inductorCoil;
        }

        /// <summary>
        /// Correction exception.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <param name="inputMessage">inputMessage.</param>
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
            new Complex(0, Math.Round(2 * Math.PI * Frequency
                * Inductance * Math.Pow(10, -3), 3));

        /// <summary>
        /// Gets output of information about the impedance.
        /// </summary>
        public override string Impedance =>
            $"Impedance = {CalculationImpedance.Imaginary}j mOhm";

        /// <summary>
        /// Gets output of information about the element.
        /// </summary>
        public override string Info =>
            $"\nСharacteristics of the inductor coil:\n" +
            $"Inductance = {Inductance} microH\n" +
            $"Frequency = {Frequency} Hz\n" +
            $"Impedance = {CalculationImpedance.Imaginary}j mOhm";
    }
}
