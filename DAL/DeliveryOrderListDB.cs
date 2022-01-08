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
    public class DeliveryOrderListDB : IDeliveryOrderListDB
    {
        private IConfiguration Configuration { get; }

        public DeliveryOrderListDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //To get all the deliveryOrderList
        public List<DeliveryOrderList> GetDeliveryOrderLists()
        {
            List<DeliveryOrderList> results = null;
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from DeliveryOrderList";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<DeliveryOrderList>();

                            DeliveryOrderList deliveryOrderList = new DeliveryOrderList();

                            deliveryOrderList.Id_Delivery = (int)dr["Id_Delivery"];
                            deliveryOrderList.ID_Order = (int)dr["ID_Order"];
                            deliveryOrderList.NumStatut = (int)dr["NumStatut"];

                            results.Add(deliveryOrderList);
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

        //To get a list of deliveryOrderList with the idDeliveryman
        public List<DeliveryOrderList> GetDeliveryOrderList(int IdDeliveryMan)
        {
            List<DeliveryOrderList> results = null;
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from DeliveryOrderList where Id_Delivery=@IdDelivery";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdDelivery", IdDeliveryMan);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<DeliveryOrderList>();

                            DeliveryOrderList deliveryOrderList = new DeliveryOrderList();

                            deliveryOrderList.Id_Delivery = (int)dr["Id_Delivery"];
                            deliveryOrderList.ID_Order = (int)dr["ID_Order"];
                            deliveryOrderList.NumStatut = (int)dr["NumStatut"];

                            results.Add(deliveryOrderList);
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

        //To add a deliveryOrderList to the database
        public DeliveryOrderList AddDeliveryOrderList(DeliveryOrderList deliveryOrderList)
        {
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into DeliveryOrderList(Id_Delivery, ID_Order, NumStatut) values(@IdDelivery, @IdOrder, @NumSatut); SELECT SCOPE_IDENTITY()";
                    
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdDelivery", deliveryOrderList.Id_Delivery);
                    cmd.Parameters.AddWithValue("@IdOrder", deliveryOrderList.ID_Order);
                    cmd.Parameters.AddWithValue("@NumSatut", deliveryOrderList.NumStatut);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return deliveryOrderList;


        }

        //To modify the deliveryOrderList
        //If the number of the statut is 0, the order is cancel
        //If the number of the statut is 1, the order is being processed
        //If the number of the statut is 2, the order is being delivered
        //If the number of the statut is 3, the order is delivered
        public DeliveryOrderList ModifyStatut(DeliveryOrderList deliveryOrderList)
        {
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update DeliveryOrderList set NumStatut = @newStatut where Id_Delivery=@IdDelivery and ID_Order=@IdOrder ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdDelivery", deliveryOrderList.Id_Delivery);
                    cmd.Parameters.AddWithValue("@IdOrder", deliveryOrderList.ID_Order);
                    cmd.Parameters.AddWithValue("@newStatut", deliveryOrderList.NumStatut);

                    cn.Open();
                    cmd.ExecuteNonQuery();


                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return deliveryOrderList;

        }

        //To get a deliveryOrderList with its idOrder
        public DeliveryOrderList GetDeliveryManFromOrderID(int OrderID)
        {
            DeliveryOrderList deliveryOrderList = null;
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from DeliveryOrderList where ID_Order=@ID_Order";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_Order", OrderID);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            deliveryOrderList = new DeliveryOrderList();
                            deliveryOrderList.Id_Delivery = (int)dr["Id_Delivery"];
                            deliveryOrderList.ID_Order = (int)dr["ID_Order"];
                            deliveryOrderList.NumStatut = (int)dr["NumStatut"];  
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return deliveryOrderList;
        }
    }
}
