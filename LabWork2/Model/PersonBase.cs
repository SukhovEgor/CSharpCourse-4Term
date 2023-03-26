using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Class Person.
    /// </summary>
    public abstract class PersonBase
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
        protected abstract int MinAge { get; }

        /// <summary>
        /// Maximum age.
        /// </summary>
        protected abstract int MaxAge { get; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name
        {
            get => _name;

            set
            {
                _ = CheckLanguage(value);
                _name = ConvertToRightRegister(value);

                if (_name != null)
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
                _ = CheckLanguage(value);
                _surname = ConvertToRightRegister(value);

                if (_surname != null)
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
        public PersonBase(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Default person.
        /// </summary>
        public PersonBase() { }

        public string GetPersonInfo() => 
            $"{Name} {Surname}; Age: {Age}; Gender: {Gender}";
        
        public string GetNameSurname() => $"{Name} {Surname}";

        /// <summary>
        /// Check correct age.
        /// </summary>
        /// <param name="age">Age.</param>
        /// <returns>Age.</returns>
        /// <exception cref="Exception">Incorrect age.</exception>
        protected virtual int CheckAge(int age)
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
                    throw new FormatException
                        ("\nThere should be only Russian" +
                            " or only English characters");
                }
            }
            else
            {
                throw new ArgumentException
                    ("\nInput must not be empty.");
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
                        ("\nName and surname must be in the same language");
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
        /// Gets output of iformation about the person.
        /// </summary>
        public abstract string Info();
    }
}
