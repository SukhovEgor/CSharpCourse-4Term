using Model;
using System;

namespace ConsoleLoader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var elemetList = new List<PassiveElementBase>();
            bool cicle = true;
            while (cicle)
            {
                switch (EnterByConsole())
                {
                    case 1:
                        var resistor = Resistor.InputValuesByConsole();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(resistor.Impedance);
                        Console.ForegroundColor = ConsoleColor.White;
                        elemetList.Add(resistor);
                        break;
                    case 2:
                        var inductorCoil = InductorCoil.InputValuesByConsole();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(inductorCoil.Impedance);
                        Console.ForegroundColor = ConsoleColor.White;
                        elemetList.Add(inductorCoil);
                        break;
                    case 3:
                        var capacitor = Capacitor.InputValuesByConsole();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(capacitor.Impedance);
                        Console.ForegroundColor = ConsoleColor.White; 
                        elemetList.Add(capacitor);
                        break;
                    case 4:
                        foreach (var tmpMotion in elemetList)
                        {
                            Console.WriteLine(tmpMotion.Info);
                        }

                        break;
                    case 5:
                        cicle = false;
                        break;
                }
            }
        }
        public static int EnterByConsole()
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
