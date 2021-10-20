﻿using DAL;
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

        public List<Person> GetPeople()
        {
            return PersonDB.GetPeople();
        }
    }
}
