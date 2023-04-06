using System.Numerics;

namespace Model
{
    /// <summary>
    /// Class Resistors.
    /// </summary>
    public class Resistor : PassiveElementBase
    {
        /// <summary>
        /// Resistor's resistance.
        /// </summary>
        private double _resistance;

        /// <summary>
        /// Gets or sets resistance.
        /// </summary>
        public double Resistance
        {
            get => _resistance;
            set => _resistance = CheckValue(value);
        }

        //TODO: remove
        /// <summary>
        /// Entering resistance by console.
        /// </summary>
        /// <returns>resistor.</returns>
        public static Resistor EnterValues()
        {
            var resistor = new Resistor();

            var actionList = new List<(Action Action, string)>
            {
                (
                    () =>
                    {
                        resistor.Resistance = Convert.ToDouble(Console.ReadLine());
                    },
                    "\nEnter resistence of resistor:"
                )
            };

            foreach (var action in actionList)
            {
                ActionHandler(action.Action, action.Item2);
            }

            return resistor;
        }
        //TODO: duplication
        /// <summary>
        /// Correction exception.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <param name="inputMessage">Input Message.</param>
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
            new Complex(Resistance, 0);

        /// <summary>
        /// Gets output of information about the impedance.
        /// </summary>
        public override string Impedance =>
            $"Impedance = {CalculationImpedance.Real} Ohm";

        /// <summary>
        /// Gets output of information about the element.
        /// </summary>
        public override string Info =>
            $"\nСharacteristics of the resistor:\n" +
            $"Resistance = {Resistance} Ohm\n" +
            $"Impedance = {CalculationImpedance.Real} Ohm";
    }
}
