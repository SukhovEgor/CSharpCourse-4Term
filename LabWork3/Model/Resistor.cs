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
            set => _resistance = CheckValue(value);
        }

        public static Resistor InputValuesByConsole()
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

        public override Complex CalculationImpedance =>
            new Complex(Resistance, 0);

        public override string Impedance =>
            $"Impedance = {CalculationImpedance.Real} Ohm";
        public override string Info =>
            $"\nСharacteristics of the resistor:\n" +
            $"Resistance = {Resistance} Ohm\n" +
            $"Impedance = {CalculationImpedance.Real} Ohm";
    }
}
