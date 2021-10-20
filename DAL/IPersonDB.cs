using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IPersonDB
    {

        List<Person> GetPeople();
        Person GetPerson(string UsernameLogin, string UsernamePassword);
    }
}
