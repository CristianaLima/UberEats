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
    public class PersonManager : IPersonManager
    {

        private IPersonDB PersonDB { get; }
        private IOrderDB OrderDb { get; }
        private ILocationDB LocationDb { get; }

        public PersonManager(IPersonDB personDB, IOrderDB orderDb, ILocationDB locationDb)
        {
            PersonDB = personDB;
            OrderDb = orderDb;
            LocationDb = locationDb;
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

        public Person ModifyAllPerson(Person person)
        {
            return PersonDB.ModifyAllPerson(person);
        }

        public List<Order> GetListOrder(string login, string password)
        {
            Person person = PersonDB.GetPerson(login, password);
            List<Order> orders = OrderDb.GetOrderIDPerson(person.ID_person);

            return orders;
        }
        public Location GetLocation(string login, string password)
        {
            Person person = PersonDB.GetPerson(login, password);
            Location location = LocationDb.GetLocationID(person.ID_location);

            return location;
        }
        public List<Person> GetPersonIDLocation(int IdLocation)
        {
            return PersonDB.GetPersonIDLocation(IdLocation);
        }
    }
}
