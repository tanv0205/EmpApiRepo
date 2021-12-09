using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiEx2.Models;

namespace CoreApiEx2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        static readonly IPersonRepository repo = new PersonRepository();
        [HttpGet]
        public IEnumerable<Person> GetAllPersons()
        {
            return repo.GetAll();
        }
        [HttpGet("{id}")]
        public Person GetPerson(int id)
        {
            Person item = repo.Get(id);
            if (item == null)
            {
                throw new System.Web.Http.HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
            return item;
        }
        [HttpPost]
        public string PostPerson(Person item)
        {
            item = repo.Add(item);
            return "added successfully";
        }
        [HttpPut("{id}")]
        public void PutPerson(int id, Person p)
        {
            p.Id = id;
            if (!repo.Update(p))
            {
                throw new System.Web.Http.HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
        }
        [HttpDelete("{id}")]
        public void DeletePerson(int id, Person p)
        {
            Person item = repo.Get(id);
            if (item == null)
            {
                throw new System.Web.Http.HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
            repo.Remove(id);
        }
    }
}
