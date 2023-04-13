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
                    case 1:
                        {
                            elemetList.Add(ShowImpedance(
                                EnterValues(PassiveElementType.Resistor)));
                            break;
                        }

                    case 2:
                        {
                            elemetList.Add(ShowImpedance(
                                EnterValues(PassiveElementType.InductorCoil)));
                            break;
                        }

                    case 3:
                        {
                            elemetList.Add(ShowImpedance(
                                EnterValues(PassiveElementType.Capacitor)));
                            break;
                        }

                    case 4:
                        {
                            foreach (var tmpElement in elemetList)
                            {
                                Console.WriteLine(tmpElement.Info);
                                RoundImpedance(tmpElement, 4);
                            }

                            break;
                        }

                    case 5:
                        {
                            return;
                        }

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
        public static PassiveElementBase ShowImpedance
            (PassiveElementBase passiveElementBase)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            RoundImpedance(passiveElementBase, 4);
            Console.ForegroundColor = ConsoleColor.White;
            return passiveElementBase;
        }

        /// <summary>
        /// Get round value of Impedance.
        /// </summary>
        /// <param name="passiveElementBase">Passive Element.</param>
        /// <param name="digits">Digits.</param>
        public static void RoundImpedance
            (PassiveElementBase passiveElementBase, int digits)
        {

            double realResistance = Math.Round
                (passiveElementBase.Impedance.Real, digits);
            double imaginaryResistance = Math.Round
                (passiveElementBase.Impedance.Imaginary, digits);

            Console.WriteLine($"Impedance = {realResistance}" +
                $" + ({imaginaryResistance})j Ohm");
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
        /// Enter element's parameters.
        /// </summary>
        /// <param name="passiveElementType">Type of passive Element.</param>
        /// <returns>Passive Element.</returns>
        public static PassiveElementBase EnterValues
            (PassiveElementType passiveElementType)
        {
            PassiveElementBase elementObject = new Resistor();
            switch (passiveElementType)
            {
                case PassiveElementType.Resistor:
                    {
                        elementObject = new Resistor();
                        break;
                    }

                case PassiveElementType.InductorCoil:
                    {
                        elementObject = new InductorCoil();
                        break;
                    }

                case PassiveElementType.Capacitor:
                    {
                        elementObject = new Capacitor();
                        break;
                    }

                default:
                    {
                        break;
                    }
            }

            var actionResistor = new List<(Action Action, string)>
            {
                (
                    () =>
                    {
                        var resistor = (Resistor)elementObject;
                        resistor.Resistance =
                            Convert.ToDouble(Console.ReadLine());
                    },
                    "\nEnter resistence of resistor:"
                )
            };

            var actionInductorCoil = new List<(Action Action, string)>
            {
                (
                    () =>
                    {
                        var inductorCoil = (InductorCoil)elementObject;
                        inductorCoil.Inductance =
                            Convert.ToDouble(Console.ReadLine());
                    },
                    "\nEnter inductance of inductor coil:"
                ),
                (
                    () =>
                    {
                        var inductorCoil = (InductorCoil)elementObject;
                        inductorCoil.Frequency =
                            Convert.ToDouble(Console.ReadLine());
                    },
                    "\nEnter frequency of inductor coil:"
                )
            };

            var actionCapacitor = new List<(Action Action, string)>
            {
                (
                    () =>
                    {
                        var capacitor = (Capacitor)elementObject;
                        capacitor.Capacity =
                            Convert.ToDouble(Console.ReadLine());
                    },
                    "\nEnter capacity of capacitor:"
                ),
                (
                    () =>
                    {
                        var capacitor = (Capacitor)elementObject;
                        capacitor.Frequency =
                            Convert.ToDouble(Console.ReadLine());
                    },
                    "\nEnter frequency of capacitor:"
                )
            };

            var actionDictionary =
                new Dictionary<Type, List<(Action Action, string)>>
            {
                {typeof(Resistor), actionResistor },
                {typeof(InductorCoil), actionInductorCoil },
                {typeof(Capacitor), actionCapacitor },
            };

            var tmpActionsCollection = actionDictionary
                [elementObject.GetType()];
            foreach (var action in tmpActionsCollection)
            {
                ActionHandler(action.Action, action.Item2);
            }

            return elementObject;
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
