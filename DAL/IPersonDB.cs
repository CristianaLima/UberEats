﻿using DTO;
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
        Person GetPersonID(int ID_person);
        Person AddPerson(Person person);
        Person ModifyAllPerson(Person person);
        List<Person> GetPersonIDLocation(int IdLocation);
    }
}
