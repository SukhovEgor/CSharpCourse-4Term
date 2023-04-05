using System.Numerics;

namespace Model
{
    public class Capacitor : PassiveElementBase
    {
        private double _сapacity;

        private double _frequency;
        public double Capacity
        {
            get => _сapacity;
            set => _сapacity = CheckValue(value);
        }
        public double Frequency
        {
            get => _frequency;
            set => _frequency = CheckValue(value);
        }

        public Capacitor(double сapacity, double frequency)
        {
            Capacity = сapacity;
            Frequency = frequency;
        }

        public Capacitor() { }

        public static Capacitor InputValuesByConsole()
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
            new Complex(0, Math.Round(-1 / (2 * Math.PI * Frequency * Capacity * Math.Pow(10, -6)), 3));

        public override string Impedance =>
            $"Impedance = {CalculationImpedance.Imaginary}j Ohm";
        public override string Info =>
            $"\nСharacteristics of the capacitor:\n" +
            $"Capacity = {Capacity} microF\n" +
            $"Frequency = {Frequency} Hz\n" +
            $"Impedance = {CalculationImpedance.Imaginary}j Ohm";
    }
}
