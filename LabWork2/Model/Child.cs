namespace Model
{
    internal class Child : PersonBase
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
        /// 
        /// </summary>
        private Adult _mother;

        private Adult _father;

        private string _school;

        public Adult Mother
        {
            get => _mother;

            set
            {
                CheckParentGender(value, Gender.Female);
                _mother = value;
            }
        }

        public Adult Father
        {
            get => _father;

            set
            {
                CheckParentGender(value, Gender.Male);
                _father = value;
            }
        }

        public string School
        {
            get => _school;

            set
            {
                _school = value;
            }
        }

        private void CheckParentGender(Adult parent, Gender gender)
        {
            if (parent != null && parent.Gender != gender)
            {
                throw new ArgumentException("Change parent's gender!");
            }
        }

        public override string Info()
        {
            string motherStatus = "No mother";
            string fatherStatus = "No father";

            if (Mother != null)
            {
                motherStatus = $"Mother is {Mother.GetNameSurname}";
            }

            if (Father != null)
            {
                fatherStatus = $"Father is {Father.GetNameSurname}";
            }

            string schoolStatus = "not studing";
            if (!string.IsNullOrEmpty(School))
            {
                schoolStatus = $"study in {School}";
            }

            if (Mother == null && Father == null)
            {
                return Gender == Gender.Female ?
                ($"{Name} {Surname} {schoolStatus}" +
                    $"\nUnfortunately, she is an orphan")
                    :
                ($"{Name} {Surname} {schoolStatus}" +
                    $"\nUnfortunately, he is an orphan");
            }
            else
            {
                return $"{GetPersonInfo()}" +
                    $"\n{fatherStatus},\n{motherStatus},\n{schoolStatus}";
            }
        }

        public Child(string name, string surname, int age, Gender gender,
            Adult mother, Adult father, string school)
            : base(name, surname, age, gender)
        {
            Mother = mother;
            Father = father;
            School = school;
        }

        /// <summary>
        /// Entering a random person.
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
            }

            string surname = allSurnames[random.Next(allSurnames.Length)];
            int age = random.Next(_minAge, _maxAge);

            string school = schoolNames[random.Next(schoolNames.Length)];

            Adult mother = GetRandomParent(1);
            Adult father = GetRandomParent(0);

            return new Child(name, surname, age, gender,
                            mother, father, school);
        }

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
                            ("You should input only 1 or 2");
                }
            }
        }

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

        public Child()
        {
        }
    }
}
