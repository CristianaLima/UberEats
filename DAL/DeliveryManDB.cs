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
                            deliveryMan.UsernameLoginDelivery = (string)dr["UsernameLoginDelivery"];
                            deliveryMan.PasswordDelivery = (string)dr["PasswordDelivery"];
                            if (dr["ImageDelivery"] != null)
                                deliveryMan.ImageDelivery = (string)dr["ImageDelivery"];

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

        public DeliveryMan GetDeliveryMan(string username, string password)
        {
            DeliveryMan deliveryMan = null;

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = " Select * from DeliveryMan where UsernameLogin = @UsernameLogin AND UsernamePassword = @UsernamePassword";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@UsernameLogin", username);
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
                            deliveryMan.UsernameLoginDelivery = (string)dr["UsernameLoginDelivery"];
                            deliveryMan.PasswordDelivery = (string)dr["PasswordDelivery"];
                            if (dr["ImageDelivery"] != null)
                                deliveryMan.ImageDelivery = (string)dr["ImageDelivery"];


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
                            deliveryMan.UsernameLoginDelivery = (string)dr["UsernameLoginDelivery"];
                            deliveryMan.PasswordDelivery = (string)dr["PasswordDelivery"];
                            if (dr["ImageDelivery"] != null)
                                deliveryMan.ImageDelivery = (string)dr["ImageDelivery"];


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

        public DeliveryMan AddDeliveryMan(DeliveryMan delivery)
        {
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into DeliveryMan(Id_Delivery, ID_Location, ID_workLocation, NameDelivery,FirstNameDelivery, AddressDelivery, " +
                        "BirthDateDelivery,PhoneNumberDelivery,EmailDelivery, UsernameLoginDelivery, PasswordDelivery, ImageDelivery) values(@id, @locationId," +
                        " @workLocationId, @lastName, @firstName, @address, @birthDate, @phoneNumber, @email, @login, @password, @image); SELECT SCOPE_IDENTITY()";
                    
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", delivery.Id_Delivery);
                    cmd.Parameters.AddWithValue("@locationId", delivery.ID_Location);
                    cmd.Parameters.AddWithValue("@workLocationId", delivery.ID_workLocation);
                    cmd.Parameters.AddWithValue("@lastName", delivery.NameDelivery);
                    cmd.Parameters.AddWithValue("@firstName", delivery.FirstNameDelivery);
                    cmd.Parameters.AddWithValue("@address", delivery.AddressDelivery);
                    cmd.Parameters.AddWithValue("@birthDate", delivery.BirthDateDelivery);
                    cmd.Parameters.AddWithValue("@phoneNumber", delivery.PhoneNumberDelivery);
                    cmd.Parameters.AddWithValue("@email", delivery.EmailDelivery);
                    cmd.Parameters.AddWithValue("@login", delivery.UsernameLoginDelivery);
                    cmd.Parameters.AddWithValue("@password", delivery.PasswordDelivery);
                    cmd.Parameters.AddWithValue("@image", delivery.ImageDelivery);

                    cn.Open();

                    delivery.Id_Delivery = Convert.ToInt32(cmd.ExecuteScalar());
                    delivery.ID_Location = Convert.ToInt32(cmd.ExecuteScalar());
                    delivery.ID_workLocation = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return delivery;


        }
    }
}
