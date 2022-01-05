using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IPersonManager
    {
        Person AddPerson(Person person);
        List<Order> GetListOrder(string login, string password);
        Location GetLocation(string login, string password);
        List<Person> GetPeople();
        Person GetPerson(string UsernameLogin, string UsernamePassword);
        Person GetPersonID(int ID_person);
        List<Person> GetPersonIDLocation(int IdLocation);
        Person ModifyAllPerson(Person person);
        object GetPersonID(int? idPerson);
    }
}