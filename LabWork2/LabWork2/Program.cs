using Model;

namespace LabWork2
{
    /// <summary>
    /// Class programm.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main.
        /// </summary>
        public static void Main()
        {
            var inputPerson = InputPersonByConsole();
            var personList3 = new PersonList();
            personList3.AddPerson(inputPerson);
            Console.WriteLine("\nNew pirate is");
            Info(personList3);
            _ = Console.ReadKey();
            Console.WriteLine("");

            var personList1 = new PersonList();
            var personList2 = new PersonList();

            PersonBase[] personArr1 = new PersonBase[]
            {
                new PersonBase("Jack", "Sparrow", 35, Gender.Male),
                new PersonBase("Elizabeth", "Swann", 17, Gender.Female),
                new PersonBase("William", "Turner", 25, Gender.Male)
            };

            PersonBase[] personArr2 = new PersonBase[]
            {
                new PersonBase("Joshamee", "Gibbs", 55, Gender.Male),
                new PersonBase("Hector", "Barbossa", 65, Gender.Male),
                new PersonBase("Davy", "Jones", 100, Gender.Male)
            };

            personList1.AddPersons(personArr1);
            personList2.AddPersons(personArr2);
            Console.WriteLine("Adding two pirates' crew:");
            PrintList(personList1, personList2);

            personList1.AddPerson(
                new PersonBase("James", "Norrington", 33, Gender.Male));
            Console.WriteLine("Adding a new pirate to the Crew 1");
            PrintList(personList1, personList2);

            personList2.AddPerson(personList1.SearchPersonByIndex(1));
            Console.WriteLine("Adding a new pirate to Crew2 from the Crew1");
            PrintList(personList1, personList2);

            personList1.RemovePersonByIndex(1);
            Console.WriteLine("Delete the second pirate from the Crew 1");
            PrintList(personList1, personList2);

            personList2.ClearPersonList();
            Console.WriteLine("The second Сrew sank (Clearing the Crew 2)");
            PrintList(personList1, personList2);

            personList2.AddPerson(PersonBase.GetRandomPerson());
            Console.WriteLine("Adding a new random pirate to the Crew 2");
            PrintList(personList1, personList2);

        }

        /// <summary>
        /// Output array of persons.
        /// </summary>
        /// <param name="personList">PersonList.</param>
        public static void Info(PersonList personList)
        {
            for (int i = 0; i < personList.Length; i++)
            {
                Console.WriteLine(personList.SearchPersonByIndex(i).Info);
            }
        }

        /// <summary>
        /// Output personList to the Console.
        /// </summary>
        /// <param name="personList1">PersonList1.</param>
        /// <param name="personList2">PersonList2.</param>
        public static void PrintList(PersonList personList1,
                                     PersonList personList2)
        {
            Console.WriteLine("Crew1");
            Info(personList1);
            Console.WriteLine("\nCrew2");
            Info(personList2);
            _ = Console.ReadKey();
            Console.WriteLine("");
        }

        /// <summary>
        /// Adding person by the console.
        /// </summary>
        /// <returns>New person.</returns>
        /// <exception cref="IndexOutOfRangeException">IndexOut.</exception>
        public static PersonBase InputPersonByConsole()
        {
            var person = new PersonBase();

            var actionList = new List<(Action Action, string)>
            {
                (
                    () =>
                    {
                        person.Name = Console.ReadLine();
                    },
                    "Enter pirates' name:"
                ),
                (
                    () =>
                    {
                        person.Surname = Console.ReadLine();
                    },
                    "Enter pirates' surname:"
                ),
                (
                    () =>
                    {
                        person.Age = Convert.ToInt32(Console.ReadLine());
                    },
                    "Enter pirates' age:"
                ),
                (
                    () =>
                    {
                    if (!int.TryParse(Console.ReadLine(), out int tmpGender))
                    {
                        throw new ArgumentException
                           ("Number must be in range [0; 1].");
                    }

                    if (tmpGender < 0 || tmpGender > 1)
                    {
                        throw new IndexOutOfRangeException
                            ("Number must be in range [0; 1].");
                    }

                    var realGender = tmpGender == 0
                        ? Gender.Male
                        : Gender.Female;
                    person.Gender = realGender;
                    },
                    "Enter pirates' gender (0 - Male or 1 - Female):"
                ),

            };

            foreach (var action in actionList)
            {
                ActionHandler(action.Action, action.Item2);
            }

            return person;
        }

        /// <summary>
        /// Person input handler by the console.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <param name="inputMessage">Message.</param>
        private static void ActionHandler
            (Action action, string inputMessage)
        {
            while (true)
            {
                Console.WriteLine(inputMessage);
                try
                {
                    action.Invoke();
                    break;
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
