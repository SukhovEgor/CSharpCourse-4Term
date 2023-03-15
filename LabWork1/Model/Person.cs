using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Class Person.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Person's name.
        /// </summary>
        private string _name;

        /// <summary>
        /// Person's surname.
        /// </summary>
        private string _surname;

        /// <summary>
        /// Persons's age.
        /// </summary>
        private int _age;

        /// <summary>
        /// Person's gender.
        /// </summary>
        private Gender _gender;

        /// <summary>
        /// Minimum age.
        /// </summary>
        private const int _minAge = 6;

        /// <summary>
        /// Maximum age.
        /// </summary>
        private const int _maxAge = 150;

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name
        {
            get => _name;

            set
            {
                _name = ConvertToRightRegister(value);
                if (_surname != null)
                {
                    CheckNameSurname();
                }
            }
        }

        /// <summary>
        /// Gets or sets surname.
        /// </summary>
        public string Surname
        {
            get => _surname;

            set
            {
                _surname = ConvertToRightRegister(value);
                if (_name != null)
                {
                    CheckNameSurname();
                }
            }
        }

        /// <summary>
        /// Gets or sets age.
        /// </summary>
        public int Age
        {
            get => _age;

            set
            {
                _age = CheckAge(value);
            }
        }

        /// <summary>
        /// Gets or sets gender.
        /// </summary>
        public Gender Gender
        {
            get => _gender;
            set => _gender = value;
        }

        /// <summary>
        /// Person's constructor.
        /// </summary>
        /// <param name="name">Person's name.</param>
        /// <param name="surname">Person's surname.</param>
        /// <param name="age">Person's age.</param>
        /// <param name="gender">Person's gender.</param>
        public Person(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Default person.
        /// </summary>
        public Person() { }

        // TODO: не используется (+)

        /*
        /// <summary>
        /// Check correct gender.
        /// </summary>
        /// <param name="number">Genser's number.</param>
        /// <returns>Genser's number.</returns>
        /// <exception cref="Exception">Incorrect gender's number.</exception>
        public static int CheckGender(int number)
        {
            if (number < 0 || number > 1)
            {
                throw new ArgumentException
                    ("Enter 0 or 1, where 0 - Мale, 1 - Female");
            }
            else
            {
                return number;
            }
        }*/

        /// <summary>
        /// Check correct age.
        /// </summary>
        /// <param name="age">Age.</param>
        /// <returns>Age.</returns>
        /// <exception cref="Exception">Incorrect age.</exception>
        private int CheckAge(int age)
        {
            if (age < _minAge || age > _maxAge)
            {
                throw new IndexOutOfRangeException
                    ($"The age should be in the " +
                    $"range from {_minAge} to {_maxAge}");
            }
            else
            {
                return age;
            }
        }

        /// <summary>
        /// Check string's language.
        /// </summary>
        /// <param name="value">Name or surname.</param>
        /// <returns>Name or surname.</returns>
        /// <exception cref="Exception">Input string is wrong.</exception>
        private static Language CheckLanguage(string value)
        {
            var regexRus = new Regex("^([А-Яа-я])+(((-| )?([А-Яа-я])+))?$");
            var regexEng = new Regex("^([A-Za-z])+(((-| )?([A-Za-z])+))?$");
            if (!string.IsNullOrEmpty(value))
            {
                if (regexRus.IsMatch(value))
                {
                    return Language.Russian;
                }
                else if (regexEng.IsMatch(value))
                {
                    return Language.English;
                }
                else
                {
                    throw new ArgumentException("Incorrect input.");
                }
            }

            return Language.Default;
        }

        // TODO: XML(+)

        /// <summary>
        /// Check correct input of name or surname.
        /// </summary>
        /// <exception cref="FormatException">Incorrect input.</exception>
        private void CheckNameSurname()
        {
            if ((!string.IsNullOrEmpty(Name))
                && (!string.IsNullOrEmpty(Surname)))
            {
                var nameLanguage = CheckLanguage(Name);
                var surnameLanguage = CheckLanguage(Surname);

                if (nameLanguage != surnameLanguage)
                {
                    throw new FormatException
                        ("There should be only Russian" +
                           " or only English characters");
                }
            }
        }

        /// <summary>
        /// String is converted to the correct register.
        /// </summary>
        /// <param name="value">Name or surname.</param>
        /// <returns>Correct string.</returns>
        private string ConvertToRightRegister(string value)
        {
            var symbols = new[] { "-", " " };
            foreach (var symbol in symbols)
            {
                if (value.Contains(symbol))
                {
                    int indexOfSymbol = value.IndexOf(symbol);
                    return value.Substring(0, 1).ToUpper()
                        + value.Substring(1, indexOfSymbol - 1).ToLower()
                        + symbol
                        + value.Substring(indexOfSymbol + 1, 1).ToUpper()
                        + value.Substring(indexOfSymbol + 2).ToLower();
                }
            }

            return value.Substring(0, 1).ToUpper() +
                    value.Substring(1, value.Length - 1).ToLower();
        }

        /// <summary>
        /// Entering a random person.
        /// </summary>
        /// <returns>Random person.</returns>
        public static Person GetRandomPerson()
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

            var random = new Random();
            string name;
            var gender = (Gender)random.Next(0, 2);
            switch (gender)
            {
                case Gender.Male:
                    name = maleNames[random.Next(maleNames.Length)];
                    break;
                case Gender.Female:
                    name = femaleNames[random.Next(femaleNames.Length)];
                    break;
                default:
                    return new Person("Default", "Person", 0, Gender.Male);
            }

            string surname = allSurnames[random.Next(allSurnames.Length)];

            // TODO: range(+)
            int age = random.Next(6, 150);

            return new Person(name, surname, age, gender);
        }

        /// <summary>
        /// Gets output of iformation about the person.
        /// </summary>
        public string Info => $"{Name} {Surname}," +
            $" Age: {Age}, Gender: {Gender}";
    }
}
