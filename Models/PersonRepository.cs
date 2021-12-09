using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiEx2.Models
{
    public class PersonRepository : IPersonRepository
    {
        private static List<Person> person = new List<Person>();
        private int nxtId = 1;

        public PersonRepository()
        {
            Add(new Person { Name = "Tanveer", Address = "Chennai" });
            Add(new Person { Name = "Naaz", Address = "Mumbai" });
        }
        public Person Add(Person p)
        {
            if (p == null)
            {
                throw new ArgumentNullException();
            }
            p.Id = nxtId++;
            person.Add(p);
            return p;
        }

        public Person Get(int id)
        {
            return person.Find(p => p.Id == id);
        }

        public IEnumerable<Person> GetAll()
        {
            return person;
        }

        public void Remove(int id)
        {
            person.RemoveAll(p => p.Id == id);
        }

        public bool Update(Person pn)
        {
            if (pn == null)
            {
                throw new ArgumentNullException();
            }
            int index = person.FindIndex(p => p.Id == pn.Id);
            if (index == -1)
            {
                return false;
            }
            person.RemoveAt(index);
            person.Add(pn);
            return true;
        }
    }
}
