namespace CollectionOfPeople
{
    using System.Collections.Generic;

    public class PeopleCollectionSlow : IPeopleCollection
    {
        public int Count => throw new System.NotImplementedException();

        public bool Add(string email, string name, int age, string town)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(string email)
        {
            throw new System.NotImplementedException();
        }

        public Person Find(string email)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Person> FindPeople(string emailDomain)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Person> FindPeople(string name, string town)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Person> FindPeople(int startAge, int endAge)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Person> FindPeople(int startAge, int endAge, string town)
        {
            throw new System.NotImplementedException();
        }
    }
}
