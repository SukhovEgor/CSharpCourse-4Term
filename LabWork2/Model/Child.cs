namespace Model
{
    internal class Child : PersonBase
    {

        private Adult _mother;

        private Adult _father;

        private string _school;

        public Adult Mother
        {
            get
            {
                return _mother;
            }

            set
            {
                _mother = value;
            }
        }

        public Adult Father
        {
            get
            {
                return _father;
            }

            set
            {
                _father = value;
            }
        }

        public string School
        {
            get
            {
                return _school;
            }

            set
            {
                _school = value;
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

    }
}
