using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PersonManager
    {

        private IPersonDB PersonDB { get; }

        public PersonManager(IConfiguration conf)
        {
            PersonDB = new PersonDB(conf);
        }

        public Person GetPerson(string UsernameLogin, string UsernamePassword)
        {
            return PersonDB.GetPerson(UsernameLogin, UsernamePassword);
        }
        public Person GetPersonID(int ID_person)
        {
            return PersonDB.GetPersonID(ID_person);
        }

        public Person AddPerson(Person person)
        {
            return PersonDB.AddPerson(person);
        }

        public List<Person> GetPeople()
        {
            return PersonDB.GetPeople();
        }
    }
}
