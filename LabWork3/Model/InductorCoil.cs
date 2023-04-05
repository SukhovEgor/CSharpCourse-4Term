using System.Numerics;

namespace Model
{
    public class InductorCoil : PassiveElementBase
    {
        private double _inductance;

        private double _frequency;
        public double Inductance
        {
            get => _inductance;
            set => _inductance = CheckValue(value);
        }
        public double Frequency
        {
            get => _frequency;
            set => _frequency = CheckValue(value);
        }

        public InductorCoil(double inductance, double frequency)
        {
            Inductance = inductance;
            Frequency = frequency;
        }

        public InductorCoil() { }

        public static InductorCoil InputValuesByConsole()
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
            new Complex(0, Math.Round(2 * Math.PI * Frequency * Inductance * Math.Pow(10, -3), 3));


        public override string Impedance =>
            $"Impedance = {CalculationImpedance.Imaginary}j mOhm";
        public override string Info =>
            $"\nСharacteristics of the inductor coil:\n" +
            $"Inductance = {Inductance} microH\n" +
            $"Frequency = {Frequency} Hz\n" +
            $"Impedance = {CalculationImpedance.Imaginary}j mOhm";
    }
}
