using Model;
using System.Numerics;

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
            // TODO: объединить с главным while(true) (+)
            var elementList = new List<PassiveElementBase>();
            while (true)
            {
                try
                {
                    switch (SelectActicity())
                    {
                        case 1:
                            {
                                CalculateImpedance
                                    (PassiveElementType.Resistor, elementList);
                                break;
                            }

                        case 2:
                            {
                                CalculateImpedance
                                    (PassiveElementType.InductorCoil, elementList);
                                break;
                            }

                        case 3:
                            {
                                CalculateImpedance
                                    (PassiveElementType.Capacitor, elementList);
                                break;
                            }

                        case 4:
                            {
                                foreach (var tmpElement in elementList)
                                {
                                    Console.WriteLine(tmpElement.GetInfo());
                                    ShowImpedance(RoundImpedance(tmpElement, 4));
                                }

                                break;
                            }

                        case 5:
                            {
                                return;
                            }

                        default:
                            {
                                break;
                            }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Repeat the input");
                }
            }
        }

        // TODO: ShowImpedance не должен возвращать значение (+)

        /// <summary>
        /// Show impedance by console.
        /// </summary>
        /// <param name="complex">Complex resistance.</param>
        public static void ShowImpedance(Complex complex)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Impedance = {complex.Real}" +
                $" + ({complex.Imaginary})j Ohm");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// fdsf.
        /// </summary>
        /// <param name="passiveElementType">fs.</param>
        /// <param name="elementList">fsdfs.</param>
        public static void CalculateImpedance
            (PassiveElementType passiveElementType,
            List<PassiveElementBase> elementList)
        {
            while (true)
            {
                try
                {
                    var element = EnterValues(passiveElementType);
                    elementList.Add(element);
                    ShowImpedance(RoundImpedance(element, 4));
                    return;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Repeat the input");
                }
            }
        }

        // TODO: const (+)

        // TODO: Вывод перенести в ShowImpedance (+)

        /// <summary>
        /// Get round value of Impedance.
        /// </summary>
        /// <param name="passiveElement">Passive Element.</param>
        /// <param name="digits">Digits.</param>
        /// <returns>Rounding complex resistance.</returns>
        public static Complex RoundImpedance
            (PassiveElementBase passiveElement, int digits)
        {
            var roundComplex = new Complex(
                Math.Round(passiveElement.GetImpedance().Real, digits),
                Math.Round(passiveElement.GetImpedance().Imaginary, digits));

            return roundComplex;
        }

        // TODO: убрать Action (+)

        /// <summary>
        /// Gives a cycle to select.
        /// </summary>
        /// <returns>Number of chosen passive element.</returns>
        /// <exception cref="ArgumentException">Incorrect input.</exception>
        /// <exception cref="IndexOutOfRangeException">
        /// Incorrect input.</exception>
        public static int SelectActicity()
        {
            int chosenPassiveElement;

            Console.WriteLine("\nPlease, enter a number:\n" +
                    "1 - resistor, 2 - inductor coil, 3 - capacitor," +
                    " 4 - print list, 5 - exit:");

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
            return chosenPassiveElement;
        }

        // TODO: другой тип(+)
        // TODO: убрать Actions, объединить с switch-case (+)

        /// <summary>
        /// Enter element's parameters.
        /// </summary>
        /// <param name="passiveElementType">Type of passive Element.</param>
        /// <returns>Passive Element.</returns>
        public static PassiveElementBase EnterValues
            (PassiveElementType passiveElementType)
        {
            switch (passiveElementType)
            {
                case PassiveElementType.Resistor:
                    {
                        var resistor = new Resistor();

                        Console.WriteLine("\nEnter resistence of resistor:");
                        resistor.Resistance
                            = Convert.ToDouble(Console.ReadLine());

                        return resistor;
                    }

                case PassiveElementType.InductorCoil:
                    {
                        var inductorCoil = new InductorCoil();

                        Console.WriteLine
                            ("\nEnter inductance of inductor coil:");
                        inductorCoil.Inductance
                            = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine
                            ("\nEnter frequency of inductor coil:");
                        inductorCoil.Frequency
                            = Convert.ToDouble(Console.ReadLine());

                        return inductorCoil;
                    }

                case PassiveElementType.Capacitor:
                    {
                        var capacitor = new Capacitor();

                        Console.WriteLine("\nEnter capacity of capacitor:");
                        capacitor.Capacity
                            = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("\nEnter frequency of capacitor:");
                        capacitor.Frequency
                            = Convert.ToDouble(Console.ReadLine());

                        return capacitor;
                    }

                default:
                    var defaultElement = new Resistor();
                    return defaultElement;
            }
        }
    }
}
