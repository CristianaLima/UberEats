﻿using DTO;
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
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

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

                            person.ID_person = (int)dr["ID_person"];

                            person.ID_location = (int)dr["ID_location"];

                            if (dr["Address"] != null)
                                person.Address = (string)dr["Address"];

                            if (dr["Name"] != null)
                                person.Name = (string)dr["Name"];

                            if (dr["Firstname"] != null)
                                person.FirstName = (string)dr["Firstname"];

                            if (dr["MailAddress"] != null)
                                person.MailAddress = (string)dr["MailAddress"];

                            if (dr["BirthDate"] != DBNull.Value)
                                person.BirthDate = (DateTime)dr["BirthDate"];

                            if (dr["PhoneNumber"] != null)
                                person.PhoneNumber = (string)dr["PhoneNumber"];

                            if (dr["isRestaurant"] != null)
                                person.isRestaurant = (int)dr["isRestaurant"];

                            person.UsernameLogin = (string)dr["UsernameLogin"];

                            person.PasswordLogin = (string)dr["PasswordLogin"];

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

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Person where UsernameLogin = @UsernameLogin AND UsernamePassword = @UsernamePassword";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@UsernameLogin", UsernameLogin);
                    cmd.Parameters.AddWithValue("@UsernamePassword", UsernamePassword);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            person = new Person();

                            person.ID_person = (int)dr["ID_person"];

                            person.ID_location = (int)dr["ID_location"];

                            if (dr["Address"] != null)
                                person.Address = (string)dr["Address"];

                            if (dr["Name"] != null)
                                person.Name = (string)dr["Name"];

                            if (dr["Firstname"] != null)
                                person.FirstName = (string)dr["Firstname"];

                            if (dr["MailAddress"] != null)
                                person.MailAddress = (string)dr["MailAddress"];

                            if (dr["BirthDate"] != DBNull.Value)
                                person.BirthDate = (DateTime)dr["BirthDate"];

                            if (dr["PhoneNumber"] != null)
                                person.PhoneNumber = (string)dr["PhoneNumber"];

                            if (dr["isRestaurant"] != null)
                                person.isRestaurant = (int)dr["isRestaurant"];

                            
                            person.UsernameLogin = (string)dr["UsernameLogin"];

                            
                            person.PasswordLogin = (string)dr["PasswordLogin"];
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


        public Person GetPersonID(int ID_person)
        {
            Person person = null;

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Person where ID_person = @ID_person";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_person", ID_person);
                    

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            person = new Person();

                            person.ID_person = (int)dr["ID_person"];

                            person.ID_location = (int)dr["ID_location"];

                            if (dr["Address"] != null)
                                person.Address = (string)dr["Address"];

                            if (dr["Name"] != null)
                                person.Name = (string)dr["Name"];

                            if (dr["Firstname"] != null)
                                person.FirstName = (string)dr["Firstname"];

                            if (dr["MailAddress"] != null)
                                person.MailAddress = (string)dr["MailAddress"];

                            if (dr["BirthDate"] != DBNull.Value)
                                person.BirthDate = (DateTime)dr["BirthDate"];

                            if (dr["PhoneNumber"] != null)
                                person.PhoneNumber = (string)dr["PhoneNumber"];

                            if (dr["isRestaurant"] != null)
                                person.isRestaurant = (int)dr["isRestaurant"];

                            
                            person.UsernameLogin = (string)dr["UsernameLogin"];

                            
                            person.PasswordLogin = (string)dr["PasswordLogin"];
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

        public Person AddPerson(Person person)
        {
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Person( ID_location, Address, Name, FirstName, MailAddress, BirthDate, PhoneNumber, isRestaurant, UsernameLogin, PasswordLogin, PersonImage) values( @ID_location, @Address, @Name, @FirstName, @MailAddress, @BirthDate, @PhoneNumber, @isRestaurant, @UsernameLogin, @PasswordLogin, @PersonImage); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    
                    cmd.Parameters.AddWithValue("@ID_location", person.ID_location);
                    cmd.Parameters.AddWithValue("@Address", person.Address);
                    cmd.Parameters.AddWithValue("@Name", person.Name);
                    cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
                    cmd.Parameters.AddWithValue("@MailAddress", person.MailAddress);
                    cmd.Parameters.AddWithValue("@BirthDate", person.BirthDate);
                    cmd.Parameters.AddWithValue("@PhoneNumber", person.PhoneNumber);
                    cmd.Parameters.AddWithValue("@isRestaurant", person.isRestaurant);
                    cmd.Parameters.AddWithValue("@UsernameLogin", person.UsernameLogin);
                    cmd.Parameters.AddWithValue("@PasswordLogin", person.PasswordLogin);
                    cmd.Parameters.AddWithValue("@PersonImage", person.PersonImage);

                    cn.Open();

                    person.ID_person = Convert.ToInt32(cmd.ExecuteScalar());
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
