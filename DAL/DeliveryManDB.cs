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
    public class DeliveryManDB : IDeliveryManDB
    {
        private IConfiguration Configuration { get; }

        public DeliveryManDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //To get all DeliveryMan
        public List<DeliveryMan> GetDeliveryMen()
        {
            List<DeliveryMan> results = null;
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from DeliveryMan";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<DeliveryMan>();

                            DeliveryMan deliveryMan = new DeliveryMan();

                            deliveryMan.Id_Delivery = (int)dr["Id_Delivery"];
                            deliveryMan.ID_Location = (int)dr["ID_Location"];
                            deliveryMan.ID_workLocation = (int)dr["ID_workLocation"];
                            deliveryMan.NameDelivery = (string)dr["NameDelivery"];
                            deliveryMan.FirstNameDelivery = (string)dr["FirstNameDelivery"];
                            deliveryMan.AddressDelivery = (string)dr["AddressDelivery"];
                            deliveryMan.BirthDateDelivery = (DateTime)dr["BirthDateDelivery"];
                            deliveryMan.PhoneNumberDelivery = (string)dr["PhoneNumberDelivery"];
                            deliveryMan.EmailDelivery = (string)dr["EmailDelivery"];
                            deliveryMan.PasswordDelivery = (string)dr["PasswordDelivery"];
                            if (dr["ImageDelivery"] != null)
                                deliveryMan.ImageDelivery = (string)dr["ImageDelivery"];
                            deliveryMan.IsWorking = (int)dr["IsWorking"];
                            deliveryMan.nbDeliveries = (int)dr["nbDeliveries"];

                            results.Add(deliveryMan);
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

        //To get a deliveryman with his/her email and his/her password
        public DeliveryMan GetDeliveryMan(string EmailDelivery, string password)
        {
            DeliveryMan deliveryMan = null;

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = " Select * from DeliveryMan where EmailDelivery = @EmailDelivery AND PasswordDelivery = @UsernamePassword";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@EmailDelivery", EmailDelivery);
                    cmd.Parameters.AddWithValue("@UsernamePassword", password);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            deliveryMan = new DeliveryMan();

                            deliveryMan.Id_Delivery = (int)dr["Id_Delivery"];
                            deliveryMan.ID_Location = (int)dr["ID_Location"];
                            deliveryMan.ID_workLocation = (int)dr["ID_workLocation"];
                            deliveryMan.NameDelivery = (string)dr["NameDelivery"];
                            deliveryMan.FirstNameDelivery = (string)dr["FirstNameDelivery"];
                            deliveryMan.AddressDelivery = (string)dr["AddressDelivery"];
                            deliveryMan.BirthDateDelivery = (DateTime)dr["BirthDateDelivery"];
                            deliveryMan.PhoneNumberDelivery = (string)dr["PhoneNumberDelivery"];
                            deliveryMan.EmailDelivery = (string)dr["EmailDelivery"];
                            deliveryMan.PasswordDelivery = (string)dr["PasswordDelivery"];
                            if (dr["ImageDelivery"] != null)
                                deliveryMan.ImageDelivery = (string)dr["ImageDelivery"];
                            deliveryMan.IsWorking = (int)dr["IsWorking"];
                            deliveryMan.nbDeliveries = (int)dr["nbDeliveries"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                //throw e;
            }
            return deliveryMan;
        }

        //To get a deliveryman with his/her id
        public DeliveryMan GetDeliveryManID(int deliveryMamId)
        {
            DeliveryMan deliveryMan = null;

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = " Select * from DeliveryMan where Id_Delivery=@DeliveryId";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@DeliveryId", deliveryMamId);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            deliveryMan = new DeliveryMan();

                            deliveryMan.Id_Delivery = (int)dr["Id_Delivery"];
                            deliveryMan.ID_Location = (int)dr["ID_Location"];
                            deliveryMan.ID_workLocation = (int)dr["ID_workLocation"];
                            deliveryMan.NameDelivery = (string)dr["NameDelivery"];
                            deliveryMan.FirstNameDelivery = (string)dr["FirstNameDelivery"];
                            deliveryMan.AddressDelivery = (string)dr["AddressDelivery"];
                            deliveryMan.BirthDateDelivery = (DateTime)dr["BirthDateDelivery"];
                            deliveryMan.PhoneNumberDelivery = (string)dr["PhoneNumberDelivery"];
                            deliveryMan.EmailDelivery = (string)dr["EmailDelivery"];
                            deliveryMan.PasswordDelivery = (string)dr["PasswordDelivery"];
                            if (dr["ImageDelivery"] != null)
                                deliveryMan.ImageDelivery = (string)dr["ImageDelivery"];
                            deliveryMan.IsWorking = (int)dr["IsWorking"];
                            deliveryMan.nbDeliveries = (int)dr["nbDeliveries"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return deliveryMan;
        }

        //To add a deliveryman to the database
        public DeliveryMan AddDeliveryMan(DeliveryMan delivery)
        {
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into DeliveryMan( ID_Location, ID_workLocation, NameDelivery,FirstNameDelivery, AddressDelivery, " +
                        "BirthDateDelivery,PhoneNumberDelivery,EmailDelivery, PasswordDelivery, ImageDelivery, IsWorking, nbDeliveries) values( @locationId," +
                        " @workLocationId, @lastName, @firstName, @address, @birthDate, @phoneNumber, @email, @password, @image, @isWorking, @nbDeliveries); SELECT SCOPE_IDENTITY()";
                    
                    SqlCommand cmd = new SqlCommand(query, cn);
                    
                    cmd.Parameters.AddWithValue("@locationId", delivery.ID_Location);
                    cmd.Parameters.AddWithValue("@workLocationId", delivery.ID_workLocation);
                    cmd.Parameters.AddWithValue("@lastName", delivery.NameDelivery);
                    cmd.Parameters.AddWithValue("@firstName", delivery.FirstNameDelivery);
                    cmd.Parameters.AddWithValue("@address", delivery.AddressDelivery);
                    cmd.Parameters.AddWithValue("@birthDate", delivery.BirthDateDelivery);
                    cmd.Parameters.AddWithValue("@phoneNumber", delivery.PhoneNumberDelivery);
                    cmd.Parameters.AddWithValue("@email", delivery.EmailDelivery);
                    cmd.Parameters.AddWithValue("@password", delivery.PasswordDelivery);
                    cmd.Parameters.AddWithValue("@image", delivery.ImageDelivery);
                    cmd.Parameters.AddWithValue("@isWorking", delivery.IsWorking);  
                    cmd.Parameters.AddWithValue("@nbDeliveries", delivery.nbDeliveries);  

                    cn.Open();

                    delivery.Id_Delivery = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return delivery;


        }

        //To modify the working status of a deliveryman with his/her id and the new number of the working status
        //If the working status is 0, he/she is not work
        //If the working status is 1, he/she is work
        public DeliveryMan ChangeIsWorking(int IdDelivery, int IsWorking)
        {
            DeliveryMan deliveryMan = null;

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    deliveryMan = new DeliveryMan();
                    string query = "UPDATE DeliveryMan SET IsWorking = @IsWorking Where Id_Delivery = @Id_Delivery; ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Id_Delivery", IdDelivery);
                    cmd.Parameters.AddWithValue("@IsWorking", IsWorking);

                    cn.Open();
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return deliveryMan;
        }

        //To modify a deliveryman
        public DeliveryMan ModifyAllDeliveryMan(DeliveryMan delivery)
        {
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    
                    string query = "UPDATE DeliveryMan SET IsWorking=@IsWorking, ID_Location=@ID_Location, ID_workLocation=@ID_workLocation, NameDelivery=@NameDelivery, FirstNameDelivery=@FirstNameDelivery, AddressDelivery=@AddressDelivery, BirthDateDelivery=@BirthDateDelivery, PhoneNumberDelivery=@PhoneNumberDelivery, EmailDelivery=@EmailDelivery, PasswordDelivery=@PasswordDelivery, ImageDelivery=@ImageDelivery, nbDeliveries=@nbDeliveries WHERE Id_Delivery=@Id_Delivery";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Id_Delivery", delivery.Id_Delivery);
                    cmd.Parameters.AddWithValue("@ID_Location", delivery.ID_Location);
                    cmd.Parameters.AddWithValue("@ID_workLocation", delivery.ID_workLocation);
                    cmd.Parameters.AddWithValue("@NameDelivery", delivery.NameDelivery);
                    cmd.Parameters.AddWithValue("@FirstNameDelivery", delivery.FirstNameDelivery);
                    cmd.Parameters.AddWithValue("@AddressDelivery", delivery.AddressDelivery);
                    cmd.Parameters.AddWithValue("@BirthDateDelivery", delivery.BirthDateDelivery);
                    cmd.Parameters.AddWithValue("@PhoneNumberDelivery", delivery.PhoneNumberDelivery);
                    cmd.Parameters.AddWithValue("@EmailDelivery", delivery.EmailDelivery);
                    cmd.Parameters.AddWithValue("@PasswordDelivery", delivery.PasswordDelivery);
                    cmd.Parameters.AddWithValue("@ImageDelivery", delivery.ImageDelivery);
                    cmd.Parameters.AddWithValue("@IsWorking", delivery.IsWorking);
                    cmd.Parameters.AddWithValue("@nbDeliveries", delivery.nbDeliveries);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return delivery;
        }

        //To get a list of deliveryman with the idWorkLocation
        public List<DeliveryMan> GetDeliveryManIDLocation(int ID_workLocation)
        {
            List<DeliveryMan> results = null;

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = " Select * from DeliveryMan where ID_workLocation=@ID_workLocation";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_workLocation", ID_workLocation);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<DeliveryMan>();

                            DeliveryMan deliveryMan = new DeliveryMan();

                            deliveryMan.Id_Delivery = (int)dr["Id_Delivery"];
                            deliveryMan.ID_Location = (int)dr["ID_Location"];
                            deliveryMan.ID_workLocation = (int)dr["ID_workLocation"];
                            deliveryMan.NameDelivery = (string)dr["NameDelivery"];
                            deliveryMan.FirstNameDelivery = (string)dr["FirstNameDelivery"];
                            deliveryMan.AddressDelivery = (string)dr["AddressDelivery"];
                            deliveryMan.BirthDateDelivery = (DateTime)dr["BirthDateDelivery"];
                            deliveryMan.PhoneNumberDelivery = (string)dr["PhoneNumberDelivery"];
                            deliveryMan.EmailDelivery = (string)dr["EmailDelivery"];
                            deliveryMan.PasswordDelivery = (string)dr["PasswordDelivery"];
                            if (dr["ImageDelivery"] != null)
                                deliveryMan.ImageDelivery = (string)dr["ImageDelivery"];
                            deliveryMan.IsWorking = (int)dr["IsWorking"];
                            deliveryMan.nbDeliveries = (int)dr["nbDeliveries"];
                            results.Add(deliveryMan);
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

        //To modify the number of deliveries
        public void ChangeNbDeliveries(int n, int ID_DeliveryMan)
        {
            

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    
                    string query = "UPDATE DeliveryMan SET nbDeliveries = @nbDeliveries Where Id_Delivery = @ID_DeliveryMan; ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_DeliveryMan", ID_DeliveryMan);
                    cmd.Parameters.AddWithValue("@nbDeliveries", n);

                    cn.Open();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

    }
}
