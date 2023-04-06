using Model;

namespace LabWork2
{
    /// <summary>
    /// Class programm.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("The crew has been created.");

            var personList = new PersonList();
            var random = new Random();

            for (var i = 0; i < 7; i++)
            {
                PersonBase randomPerson = random.Next(0, 2) == 0
                    ? Adult.GetRandomPerson()
                    : Child.GetRandomPerson();
                personList.AddPerson(randomPerson);
            }

            _ = Console.ReadKey();

            Console.WriteLine("\nBelow are the crew members:");
            PrintList(personList);

            _ = Console.ReadKey();

            var person = personList.SearchPersonByIndex(3);
            switch (person)
            {
                case Adult adult:
                    Console.WriteLine($"\n{adult.GetNameSurname()} " +
                        $"({adult.Age} age) prefers {adult.GetFavoriteDrink()}");
                    break;
                case Child child:
                    Console.WriteLine($"\n{child.GetNameSurname()}" +
                        $"({child.Age} age) has a model of {child.GetShipCollection()}");
                    break;
                default:
                    break;
            }

            _ = Console.ReadKey();
        }

        /// <summary>
        /// Print personList.
        /// </summary>
        /// <param name="personList">PersonList.</param>
        /// <exception cref="NullReferenceException">
        /// Incorrect input.</exception>
        public static void PrintList(PersonList personList)
        {
            if (personList.Length == 0)
            {
                throw new NullReferenceException("List is empty.");
            }
            else
            {
                for (int i = 0; i < personList.Length; i++)
                {
                    var tmpPerson = personList.SearchPersonByIndex(i);
                    Console.WriteLine($"\n{tmpPerson.GetInfo()}");
                }
            }
        }
    }
}
