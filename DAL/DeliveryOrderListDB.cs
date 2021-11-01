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
                            deliveryOrderList.Statut = (string)dr["Statut"];

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

        public DeliveryOrderList GetDeliveryOrderList(int IdDeliveryMan)
        {
            DeliveryOrderList deliveryOrderList = null;
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
                            deliveryOrderList = new DeliveryOrderList();

                            deliveryOrderList.Id_Delivery = (int)dr["Id_Delivery"];
                            deliveryOrderList.ID_Order = (int)dr["ID_Order"];
                            deliveryOrderList.Statut = (string)dr["Statut"];
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

        public DeliveryOrderList AddDeliveryOrderList(DeliveryOrderList deliveryOrderList)
        {
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into DeliveryOrderList(Id_Delivery, ID_Order, Statut) values(@IdDelivery, @IdOrder, @Satut); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdDelivery", deliveryOrderList.Id_Delivery);
                    cmd.Parameters.AddWithValue("@IdOrder", deliveryOrderList.ID_Order);
                    cmd.Parameters.AddWithValue("@Satut", deliveryOrderList.Statut);

                    cn.Open();

                    deliveryOrderList.Id_Delivery = Convert.ToInt32(cmd.ExecuteScalar());
                    deliveryOrderList.ID_Order = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return deliveryOrderList;


        }

        public DeliveryOrderList ModifyStatut(DeliveryOrderList deliveryOrderList)
        {
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update DeliveryOrderList set Statut = @newStatut where Id_Delivery=@IdDelivery and ID_Order=@IdOrder ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdDelivery", deliveryOrderList.Id_Delivery);
                    cmd.Parameters.AddWithValue("@IdOrder", deliveryOrderList.ID_Order);
                    cmd.Parameters.AddWithValue("@newStatut", deliveryOrderList.Statut);

                    cn.Open();

                    deliveryOrderList.Id_Delivery = Convert.ToInt32(cmd.ExecuteScalar());
                    deliveryOrderList.ID_Order = Convert.ToInt32(cmd.ExecuteScalar());

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
