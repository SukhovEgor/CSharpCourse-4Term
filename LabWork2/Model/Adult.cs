namespace Model
{
    /// <summary>
    /// Class Adult.
    /// </summary>
    public class Adult : PersonBase
    {
        /// <summary>
        /// Passport ID.
        /// </summary>
        private int _passportID;

        /// <summary>
        /// Name of company.
        /// </summary>
        private string _company;

        /// <summary>
        /// Partner.
        /// </summary>
        private Adult _partner;

        /// <summary>
        /// Minimum age.
        /// </summary>
        private const int _minAge = 18;

        /// <summary>
        /// Maximum age.
        /// </summary>
        private const int _maxAge = 150;

        /// <summary>
        /// Minimum age.
        /// </summary>
        protected override int MinAge { get; } = _minAge;

        /// <summary>
        /// Maximum age.
        /// </summary>
        protected override int MaxAge { get; } = _maxAge;

        /// <summary>
        /// Minimum value of passport ID.
        /// </summary>
        private const int _minPassportID = 1000;

        /// <summary>
        /// Maximum value of passport ID.
        /// </summary>
        private const int _maxPassportID = 9999;

        /// <summary>
        /// passport ID.
        /// </summary>
        public int PassportID
        {
            get => _passportID;

            set => _passportID = CheckPassportID(value);
        }

        //TODO: autoproperty (+)
        /// <summary>
        /// Company.
        /// </summary>
        public string Company
        {
            get => _company;

            set => _company = CheckValue(value);
        }

        /// <summary>
        /// Partner.
        /// </summary>
        public Adult Partner
        {
            get => _partner;

            set
            {
                CheckPartnerGender(value);
                _partner = value;
            }
        }

        /// <summary>
        /// Information about adult.
        /// </summary>
        /// <returns>Information.</returns>
        public override string GetInfo()
        {
            string marriegeStatus = "Single";

            if (Partner != null)
            {
                marriegeStatus = $"Married to {Partner.GetNameSurname()}";
            }

            string companyStatus = "An unemployed pirate";

            if (!string.IsNullOrEmpty(Company))
            {
                companyStatus = $"Employed in {Company}";
            }

            return $"{GetPersonInfo()}" +
                    $"\n{marriegeStatus},\n{companyStatus}";
        }

        /// <summary>
        /// Adult's constructor.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="surname">Surname.</param>
        /// <param name="age">Age.</param>
        /// <param name="gender">Gender.</param>
        /// <param name="passportID">PAssport ID.</param>
        /// <param name="company">Company.</param>
        /// <param name="partner">Partner.</param>
        public Adult(string name, string surname, int age, Gender gender,
            int passportID, string company, Adult partner)
            : base(name, surname, age, gender)
        {
            PassportID = passportID;
            Company = company;
            Partner = partner;
        }

        /// <summary>
        /// Entering a random person.
        /// </summary>
        /// <returns>Random person.</returns>
        public static Adult GetRandomPerson(Gender gender = Gender.Default)
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

            string[] companyNames = new string[]
            {
                "Black Pearl", "Flying Dutchman", "Queen Anne's Revenge",
                "HMS Interceptor", "Empress", "Hai Peng", "Jolly Mon",
                "Dying Gull", "Wicked Wench", "Misty Lady"
            };

            var random = new Random();
            string name = string.Empty;

            if (gender == Gender.Default)
            {
                var tmpNumber = random.Next(0, 2);
                gender = tmpNumber == 0
                    ? Gender.Male
                    : Gender.Female;
            }

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
            int passportID = random.Next(_minPassportID, _maxPassportID);
            string company = companyNames[random.Next(companyNames.Length)];

            Adult partner = null;
            int marriegeStatus = random.Next(0, 2);
            if (marriegeStatus == 0)
            {
                partner = new Adult();
                if (gender == Gender.Male)
                {
                    partner.Gender = Gender.Female;
                    partner.Name = femaleNames
                        [random.Next(femaleNames.Length)];

                }
                else
                {
                    partner.Gender = Gender.Male;
                    partner.Name = maleNames
                        [random.Next(maleNames.Length)];
                }

                partner.Surname = allSurnames
                    [random.Next(allSurnames.Length)];
            }

            return new Adult(name, surname, age, gender,
                            passportID, company, partner);
        }

        /// <summary>
        /// Check input age.
        /// </summary>
        /// <param name="age">Age.</param>
        /// <returns>Correct age.</returns>
        /// <exception cref="IndexOutOfRangeException">Incorrect.</exception>
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
        /// Check input passport ID.
        /// </summary>
        /// <param name="passportID">Passport ID.</param>
        /// <returns>Correct passport ID.</returns>
        /// <exception cref="IndexOutOfRangeException">Incorrect.</exception>
        private int CheckPassportID(int passportID)
        {
            if (passportID < _minPassportID || passportID > _maxPassportID)
            {
                throw new IndexOutOfRangeException
                    ($"\nThe passport should be in the " +
                    $"range from {_minPassportID} to {_maxPassportID}");
            }
            else
            {
                return passportID;
            }
        }

        /// <summary>
        /// Check gender of adult's partner.
        /// </summary>
        /// <param name="partner">Partner.</param>
        /// <exception cref="ArgumentException">Incorrect input.</exception>
        private void CheckPartnerGender(Adult partner)
        {
            if (partner != null && partner.Gender == Gender)
            {
                throw new ArgumentException
                    ("Pirates do not approve of same-sex marriage");
            }
        }

        /// <summary>
        /// Special method for adult.
        /// </summary>
        /// <returns>Name of drink.</returns>
        public string GetFavoriteDrink()
        {
            string[] drinkNames = new string[]
            {
                "Beer", "Wine", "Brandy",
                "Gin", "Rum", "Whiskey"
            };
            var random = new Random();
            string drink = drinkNames[random.Next(drinkNames.Length)];
            return drink;
        }

        /// <summary>
        /// Adult without parameters.
        /// </summary>
        public Adult()
        {
        }


    }
}
