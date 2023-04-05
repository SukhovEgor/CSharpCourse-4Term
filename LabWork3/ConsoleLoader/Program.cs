using Model;
using System;

namespace ConsoleLoader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var elemetList = new List<PassiveElementBase>();
            Console.WriteLine("1 - резистор, 2 - катушка индуутивности, 3 - конденсатор");
            int chosenPassiveElement = Convert.ToInt32(Console.ReadLine());

            switch (chosenPassiveElement)
            {
                case 1:
                    Resistor resistor = new Resistor();
                    Console.WriteLine("Введите активное сопротивление");
                    resistor.Resistance = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine(resistor.Info); 
                    break;
                case 2:
                    InductorCoil inductorCoil = new InductorCoil();
                    Console.WriteLine("Введите индуктивность");
                    inductorCoil.Inductance = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите частоту");
                    inductorCoil.Frequency = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine(inductorCoil.Info);
                    break;
                case 3:
                    Capacitor capacitor = new Capacitor();
                    Console.WriteLine("Введите емкость");
                    capacitor.Capacity = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите частоту");
                    capacitor.Frequency = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine(capacitor.Info);
                    break;
            }
        }
    }
}
