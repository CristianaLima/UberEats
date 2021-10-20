using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class PersonDB : IPersonDB
    {
        private IConfiguration Configuration { get; }

        public PersonDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Person> GetPeople()
        {
            List<Person> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Person";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Person>();

                            Person person = new Person();

                            person.ID_person = (int)dr["idPerson"];

                            person.ID_location = (int)dr["idLocation"];

                            if (dr["Address"] != null)
                                person.Address = (string)dr["Address"];

                            if (dr["Lastname"] != null)
                                person.Name = (string)dr["Lastname"];

                            if (dr["Firstname"] != null)
                                person.FirstName = (string)dr["Firstname"];

                            if (dr["MailAddress"] != null)
                                person.MailAddress = (string)dr["MailAddress"];

                            if (dr["BirthDate"] != DBNull.Value)
                                person.BirthDate = (DateTime)dr["BirthDate"];

                            if (dr["PhoneNumber"] != null)
                                person.PhoneNumber = (string)dr["PhoneNumber"];

                            if (dr["isRestaurant"] != null)
                                person.isRestaurant = (bool)dr["isRestaurant"];

                            person.UsernameLogin = (string)dr["Login"];

                            person.PasswordLogin = (string)dr["Password"];

                            results.Add(person);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }


        public Person GetPerson(string UsernameLogin, string UsernamePassword)
        {
            Person person = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Persons where UsernameLogin = @UsernameLogin AND UsernamePassword = @UsernamePassword";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@UsernameLogin", UsernameLogin);
                    cmd.Parameters.AddWithValue("@UsernamePassword", UsernamePassword);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            person = new Person();

                            person.ID_person = (int)dr["idPerson"];

                            person.ID_location = (int)dr["idLocation"];

                            if (dr["Address"] != null)
                                person.Address = (string)dr["Address"];

                            if (dr["Lastname"] != null)
                                person.Name = (string)dr["Lastname"];

                            if (dr["Firstname"] != null)
                                person.FirstName = (string)dr["Firstname"];

                            if (dr["MailAddress"] != null)
                                person.MailAddress = (string)dr["MailAddress"];

                            if (dr["BirthDate"] != DBNull.Value)
                                person.BirthDate = (DateTime)dr["BirthDate"];

                            if (dr["PhoneNumber"] != null)
                                person.PhoneNumber = (string)dr["PhoneNumber"];

                            if (dr["isRestaurant"] != null)
                                person.isRestaurant = (bool)dr["isRestaurant"];

                            if (dr["UsernameLogin"] != null)
                                person.UsernameLogin = (string)dr["UsernameLogin"];

                            if (dr["UsernamePassword"] != null)
                                person.PasswordLogin = (string)dr["UsernamePassword"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return person;
        }

    }
}
