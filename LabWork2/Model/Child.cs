namespace Model
{
    /// <summary>
    /// Class Child.
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// Minimum age.
        /// </summary>
        private const int _minAge = 0;

        /// <summary>
        /// Maximum age.
        /// </summary>
        private const int _maxAge = 17;

        /// <summary>
        /// Minimum age.
        /// </summary>
        protected override int MinAge { get; } = _minAge;

        /// <summary>
        /// Maximum age.
        /// </summary>
        protected override int MaxAge { get; } = _maxAge;

        /// <summary>
        /// Child's mother.
        /// </summary>
        private Adult _mother;

        /// <summary>
        /// Child's father.
        /// </summary>
        private Adult _father;

        /// <summary>
        /// Child's school.
        /// </summary>
        private string _school;

        /// <summary>
        /// Gets or sets child's mother.
        /// </summary>
        public Adult Mother
        {
            get => _mother;

            set
            {
                CheckParentGender(value, Gender.Female);
                _mother = value;
            }
        }

        /// <summary>
        /// Gets or sets child's father.
        /// </summary>
        public Adult Father
        {
            get => _father;

            set
            {
                CheckParentGender(value, Gender.Male);
                _father = value;
            }
        }

        //TODO: autoproperty
        /// <summary>
        /// Gets or sets child's school.
        /// </summary>
        public string School
        {
            get => _school;

            set => _school = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent">Mother or Father.</param>
        /// <param name="gender">Male or Female.</param>
        /// <exception cref="ArgumentException">Incorrent input.</exception>
        private void CheckParentGender(Adult parent, Gender gender)
        {
            if (parent != null && parent.Gender != gender)
            {
                throw new ArgumentException("Change parent's gender!");
            }
        }

        /// <summary>
        /// Info about child.
        /// </summary>
        /// <returns>Info.</returns>
        public override string GetInfo()
        {
            string motherStatus = "No mother";
            string fatherStatus = "No father";

            if (Mother != null)
            {
                motherStatus = $"Mother is {Mother.GetNameSurname()}";
            }

            if (Father != null)
            {
                fatherStatus = $"Father is {Father.GetNameSurname()}";
            }

            string schoolStatus = "not studing";
            if (!string.IsNullOrEmpty(School))
            {
                schoolStatus = $"Study in {School}";
            }

            if (Mother == null && Father == null)
            {
                return Gender == Gender.Female
                    ? $"{GetPersonInfo()} \n{schoolStatus}" +
                        $"\nUnfortunately, she is an orphan"
                    : $"{GetPersonInfo()} \n{schoolStatus}" +
                        $"\nUnfortunately, he is an orphan";
            }
            else
            {
                return $"{GetPersonInfo()}\n" +
                    $"{fatherStatus},\n" +
                    $"{motherStatus},\n" +
                    $"{schoolStatus}";
            }
        }

        /// <summary>
        /// Child's constructor.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="surname">Surname.</param>
        /// <param name="age">Age.</param>
        /// <param name="gender">Gender.</param>
        /// <param name="mother">Mother.</param>
        /// <param name="father">Father.</param>
        /// <param name="school">School.</param>
        public Child(string name, string surname, int age, Gender gender,
            Adult mother, Adult father, string school)
            : base(name, surname, age, gender)
        {
            Mother = mother;
            Father = father;
            School = school;
        }

        /// <summary>
        /// Entering a random child.
        /// </summary>
        /// <returns>Random person.</returns>
        public static Child GetRandomPerson()
        {
            string[] maleNames = new string[]
            {
                "Jack", "William", "Davy",
                "Joshamee", "Hector", "Theodore",
                "James", "Sao", "Edward"
            };

            string[] femaleNames = new string[]
            {
                "Elizabeth", "Tia", "Keira",
                "Carina", "Kaya", "Angelica",
                "Penelope", "Naomie", "Anamaria"
            };

            string[] allSurnames = new string[]
            {
                "Sparrow", "Turner", "Jones",
                "Gibbs", "Barbossa", "Groves",
                "Norrington", "Feng", "Teague",
                "Swann", "Dalma", "Smyth"
            };

            string[] schoolNames = new string[]
            {
                "Imagination", "Flying Spagetti Monster", "Queen of Bubbles",
                "Scuba-Dubin-Doo", "Cthulhu", "The Kraken", "Unsinkable",
                "Carpe Diem", "Fantasea", "Aquaholic", "Titanic II",
                "Little Black Pearl", "Monkeebutt"
            };

            var random = new Random();
            string name = string.Empty;
            var gender = (Gender)random.Next(0, 2);
            switch (gender)
            {
                case Gender.Male:
                    name = maleNames[random.Next(maleNames.Length)];
                    break;
                case Gender.Female:
                    name = femaleNames[random.Next(femaleNames.Length)];
                    break;
                case Gender.Default:
                    break;
                default:
                    break;
            }

            string surname = allSurnames[random.Next(allSurnames.Length)];
            int age = random.Next(_minAge, _maxAge);

            string school = schoolNames[random.Next(schoolNames.Length)];

            Adult mother = GetRandomParent(1);
            Adult father = GetRandomParent(0);

            return new Child(name, surname, age, gender,
                            mother, father, school);
        }

        /// <summary>
        /// Create random parent for random child.
        /// </summary>
        /// <param name="numberParent"> 0 is Male, 1 is Female.</param>
        /// <returns>Random Parent.</returns>
        /// <exception cref="ArgumentException">Incorrect input.</exception>
        private static Adult GetRandomParent(int numberParent)
        {
            var random = new Random();
            var parentStatus = random.Next(0, 2);

            if (parentStatus == 0)
            {
                return null;
            }
            else
            {
                switch (numberParent)
                {
                    case 0:
                        return Adult.GetRandomPerson(Gender.Male);
                    case 1:
                        return Adult.GetRandomPerson(Gender.Female);
                    default:
                        throw new ArgumentException
                            ("Number must be in range [0; 1].");
                }
            }
        }

        /// <summary>
        /// Check correct age.
        /// </summary>
        /// <param name="age">Age.</param>
        /// <returns>Correct age.</returns>
        /// <exception cref="IndexOutOfRangeException">
        /// Incorrect input.</exception>
        protected override int CheckAge(int age)
        {
            if (age < MinAge || age > MaxAge)
            {
                throw new IndexOutOfRangeException
                    ($"\nThe age should be in the " +
                    $"range from {MinAge} to {MaxAge}");
            }
            else
            {
                return age;
            }
        }

        /// <summary>
        /// Special method for class child.
        /// </summary>
        /// <returns>Name of ship model.</returns>
        public string GetShipCollection()
        {
            string[] shipModels = new string[]
            {
                "Black Pearl", "Flying Dutchman", "Queen Anne's Revenge",
                "HMS Interceptor", "Empress", "Hai Peng", "Jolly Mon",
                "Dying Gull", "Wicked Wench", "Misty Lady"
            };
            var random = new Random();
            string model = shipModels[random.Next(shipModels.Length)];
            return model;
        }

        /// <summary>
        /// Child without parameters.
        /// </summary>
        public Child()
        {
        }
    }
}
