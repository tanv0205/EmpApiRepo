using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiEx2.Models
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person Get(int id);
        Person Add(Person p);
        void Remove(int id);
        bool Update(Person p);
    }
}
