namespace Model
{
    /// <summary>
    /// Class for list of persons.
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Creating an array of persons.
        /// </summary>
        private Person[] _personList = new Person[0];

        /// <summary>
        /// Adding person to the end of the list.
        /// </summary>
        /// <param name="person">Person.</param>
        public void AddPerson(Person person)
        {
            Array.Resize(ref _personList, _personList.Length + 1);
            _personList[_personList.Length - 1] = person;
        }

        /// <summary>
        /// Adding a few of persons.
        /// </summary>
        /// <param name="persons">Array of persons.</param>
        public void AddPersons(Person[] persons)
        {
            foreach (Person person in persons)
            {
                AddPerson(person);
            }
        }

        /// <summary>
        /// Get index of the persons.
        /// </summary>
        /// <param name="person">Person.</param>
        /// <returns>Index of the person.</returns>
        /// <exception cref="Exception">Person does not exist.</exception>
        public int GetIndexPerson(Person person)
        {
            for (int index = 0; index < _personList.Length; index++)
            {
                if (person == _personList[index])
                {
                    return index;
                }
            }

            throw new Exception("This person does not exist.");
        }

        /// <summary>
        /// Check index in the array.
        /// </summary>
        /// <param name="index">Person's index.</param>
        /// <exception cref="IndexOutOfRangeException">
        /// Index does not exist.</exception>
        public void IsIndexExist(int index)
        {
            if (index < 0 || index >= _personList.Length)
            {
                throw new IndexOutOfRangeException
                    ("This index does not exist.");
            }
        }

        /// <summary>
        /// Removing person from the array by index.
        /// </summary>
        /// <param name="index">Person's index.</param>
        public void RemovePersonByIndex(int index)
        {
            IsIndexExist(index);

            // TODO: formatting (+)
            _personList = _personList.
                Where((person, i) => i != index).ToArray();
        }

        /// <summary>
        /// Removing a certain person.
        /// </summary>
        /// <param name="person">Person.</param>
        public void DeletePersonByName(Person person)
        {
            RemovePersonByIndex(GetIndexPerson(person));
        }

        /// <summary>
        /// Search person by index.
        /// </summary>
        /// <param name="index">Person's index.</param>
        /// <returns>Person.</returns>
        public Person SearchPersonByIndex(int index)
        {
            IsIndexExist(index);
            return _personList[index];
        }

        /// <summary>
        /// Gets return the number of persons in the array.
        /// </summary>
        public int Length => _personList.Length;

        /// <summary>
        /// Clearing all persons.
        /// </summary>
        public void ClearPersonList()
        {
            Array.Resize(ref _personList, 0);
        }
    }
}
