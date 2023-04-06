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
                            elemetList.Add(ShowImpedance(EnterValues(1)));
                            break;
                        }

                    case 2:
                        {
                            elemetList.Add(ShowImpedance(EnterValues(2)));
                            break;
                        }

                    case 3:
                        {
                            elemetList.Add(ShowImpedance(EnterValues(3)));
                            break;
                        }

                    case 4:
                        {
                            foreach (var tmpElement in elemetList)
                            {
                                Console.WriteLine(tmpElement.Info);
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

            double realResistance = Math.Round
                (passiveElementBase.Impedance.Real, 4);
            double imaginaryResistance = Math.Round
                (passiveElementBase.Impedance.Imaginary, 4);

            Console.WriteLine($"Impedance = {realResistance} + ({imaginaryResistance})j Ohm");
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
        /// fg.
        /// </summary>
        /// <param name="elementType">k.</param>
        /// <returns>k.</returns>
        /// <exception cref="ArgumentException">k.</exception>
        public static PassiveElementBase EnterValues(int elementType)
        {
            PassiveElementBase elementObject = new Resistor();
            switch (elementType)
            {
                case 1:
                    {
                        elementObject = new Resistor();
                        break;
                    }

                case 2:
                    {
                        elementObject = new InductorCoil();
                        break;
                    }

                case 3:
                    {
                        elementObject = new Capacitor();
                        break;
                    }

                default:
                    {
                        throw new ArgumentException
                            ("Please, enter only designated digits.");
                    }
            }

            var actionResistor = new List<(Action Action, string)>
            {
                (
                    () =>
                    {
                        Resistor resistor =
                            (Resistor)elementObject;
                        resistor.Resistance = Convert.ToDouble(Console.ReadLine());
                    },
                    "\nEnter resistence of resistor:"
                )
            };

            var actionInductorCoil = new List<(Action Action, string)>
            {
                (
                    () =>
                    {
                        InductorCoil inductorCoil =
                            (InductorCoil)elementObject;
                        inductorCoil.Inductance = Convert.ToDouble(Console.ReadLine());
                    },
                    "\nEnter inductance of inductor coil:"
                ),
                (
                    () =>
                    {
                        InductorCoil inductorCoil =
                            (InductorCoil)elementObject;
                        inductorCoil.Frequency = Convert.ToDouble(Console.ReadLine());
                    },
                    "\nEnter frequency of inductor coil:"
                )
            };

            var actionCapacitor = new List<(Action Action, string)>
            {
                (
                    () =>
                    {
                        Capacitor capacitor =
                            (Capacitor)elementObject;
                        capacitor.Capacity = Convert.ToDouble(Console.ReadLine());
                    },
                    "\nEnter capacity of capacitor:"
                ),
                (
                    () =>
                    {
                        Capacitor capacitor =
                            (Capacitor)elementObject;
                        capacitor.Frequency = Convert.ToDouble(Console.ReadLine());
                    },
                    "\nEnter frequency of capacitor:"
                )
            };

            var actionDictionary = new Dictionary<Type, List<(Action Action, string)>>
            {
                {typeof(Resistor), actionResistor },
                {typeof(InductorCoil), actionInductorCoil },
                {typeof(Capacitor), actionCapacitor },
            };

            var tmpActionsCollection = actionDictionary[elementObject.GetType()];
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
