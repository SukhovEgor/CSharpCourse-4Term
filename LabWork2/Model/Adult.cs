using System.Diagnostics.Metrics;

namespace Model
{
    public class Adult : PersonBase
    {
        private int _passportID;

        private string _company;

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

        private const int MinPassportID = 1000;

        private const int MaxPassportID = 9999;
        public int PassportID
        {
            get => _passportID;

            set
            {
                _passportID = CheckPassportID(value);
            }
        }

        public string Company
        {
            get => _company;

            set
            {
                _company = value;
            }
        }

        public Adult Partner
        {
            get => _partner;

            set
            {
                CheckPartnerGender(value);
                _partner = value;
            }
        }

        public override string Info()
        {
            string marriegeStatus = "Single";

            if (Partner != null)
            {
                marriegeStatus = $"Married to {Partner.GetNameSurname}";
            }

            string companyStatus = "An unemployed pirate";

            if (!string.IsNullOrEmpty(Company))
            {
                companyStatus = $"Employed in {Company}";
            }

            return $"{GetPersonInfo()}" +
                    $"\n{marriegeStatus},\n{companyStatus}";
        }

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
            }

            string surname = allSurnames[random.Next(allSurnames.Length)];
            int age = random.Next(_minAge, _maxAge);
            int passportID = random.Next(MinPassportID, MaxPassportID);
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

        private int CheckPassportID(int passportID)
        {
            if (passportID < MinPassportID || passportID > MaxPassportID)
            {
                throw new IndexOutOfRangeException
                    ($"\nThe passport should be in the " +
                    $"range from {MinPassportID} to {MaxPassportID}");
            }
            else
            {
                return passportID;
            }
        }

        private void CheckPartnerGender(Adult partner)
        {
            if (partner != null && partner.Gender != Gender)
            {
                throw new ArgumentException
                    ("Pirates do not approve of same-sex marriage");
            }
        }

        public Adult()
        {
        }
    }
}
