using Model;

namespace ConsoleLoader
{
    /// <summary>
    /// Class Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main.
        /// </summary>
        public static void Main()
        {
            var elemetList = new List<PassiveElementBase>();
            while (true)
            {
                switch (SelectElement())
                {
                    //TODO: RSDN
                    case 1:
                    {
                        var resistor = Resistor.EnterValues();
                        elemetList.Add(ShowImpedance(resistor));
                        break;
                    }
                    case 2:
                        var inductorCoil = InductorCoil.EnterValues();
                        elemetList.Add(ShowImpedance(inductorCoil));
                        break;
                    case 3:
                        var capacitor = Capacitor.EnterValues();
                        elemetList.Add(ShowImpedance(capacitor));
                        break;
                    case 4:
                        foreach (var tmpMotion in elemetList)
                        {
                            Console.WriteLine(tmpMotion.Info);
                        }

                        break;
                    case 5:
                        return;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Show impedance by console.
        /// </summary>
        /// <param name="passiveElementBase">Passive Element.</param>
        /// <returns>passiveElementBase.</returns>
        public static PassiveElementBase ShowImpedance(PassiveElementBase passiveElementBase)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(passiveElementBase.Impedance);
            Console.ForegroundColor = ConsoleColor.White;
            return passiveElementBase;
        }

        /// <summary>
        /// Gives a cycle to select.
        /// </summary>
        /// <returns>Number of chosen passive element.</returns>
        /// <exception cref="ArgumentException">Incorrect input.</exception>
        /// <exception cref="IndexOutOfRangeException">
        /// Incorrect input.</exception>
        public static int SelectElement()
        {
            int chosenPassiveElement = 0;

            var actionList = new List<(Action Action, string)>
            {
                (
                    () =>
                    {
                        if (!int.TryParse(Console.ReadLine(), out int tmpChoice))
                        {
                            throw new ArgumentException
                               ("Enter a number.");
                        }

                        if (tmpChoice < 1 || tmpChoice > 5)
                        {
                            throw new IndexOutOfRangeException
                                ("Number must be in range [1; 5].");
                        }

                        chosenPassiveElement = tmpChoice;
                    },

                    "\nPlease, enter a number:\n" +
                    "1 - resistor, 2 - inductor coil, 3 - capacitor," +
                    " 4 - print list, 5 - exit:"
                )
            };

            foreach (var action in actionList)
            {
                ActionHandler(action.Action, action.Item2);
            }

            return chosenPassiveElement;
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
    }
}
