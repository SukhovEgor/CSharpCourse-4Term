using System.Diagnostics.Metrics;

namespace Model
{
    public class Adult : PersonBase
    {


        private int _passportID;

        private string _company;

        private Adult _partner;

        public int PassportID
        {
            get
            {
                return _passportID;
            }

            set
            {
                _passportID = value;
            }
        }

        public string Company
        {
            get
            {
                return _company;
            }

            set
            {
                _company = value;
            }
        }

        public Adult Partner
        {
            get
            {
                return _partner;
            }

            set
            {
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
    }
}
