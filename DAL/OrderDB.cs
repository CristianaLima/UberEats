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
    public class OrderDB : IOrderDB
    {
        private IConfiguration Configuration { get; }

        public OrderDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Order> GetOrders()
        {
            List<Order> results = null;
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from [Order]";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order order = new Order();

                            order.ID_Order = (int)dr["ID_Order"];

                            order.ID_person = (int)dr["ID_person"];

                            order.DelaiLivraison = (DateTime)dr["DelaiLivraison"];

                            order.OrderDate = (DateTime)dr["OrderDate"];

                            results.Add(order);
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



        public int GetOrderID(int ID_person, DateTime OrderDate)
        {
            Order order = null;

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from [Order] where ID_person = @ID_person AND Orderdate = @OrderDate";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_Restaurant", ID_person);
                    cmd.Parameters.AddWithValue("@OrderDate", OrderDate);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            order = new Order();

                            order.ID_Order = (int)dr["ID_Order"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order.ID_Order;
        }

        public Order AddOrder(Order order)
        {

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "Insert into [Order]( ID_person, OrderDate, DelaiLivraison) values( @ID_person, @OrderDate, @DelaiLivraison); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    DateTime currentTime = DateTime.Now;
                    // Orderid person a faire dans le BLL ?
                    cmd.Parameters.AddWithValue("@ID_person", order.ID_person);
                    // Livraison délai 15min de base + délai livraison désirée par le client + délai livreur 
                    cmd.Parameters.AddWithValue("@OrderDate", currentTime);
                    cmd.Parameters.AddWithValue("@DelaiLivraison", order.DelaiLivraison);



                    cn.Open();

                    order.ID_Order= Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order;
        }

        public List<Order> GetOrderIDPerson(int idPerson)
        {
            List<Order> results = null;

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from [Order] where ID_person = @ID_person";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_person", idPerson);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order order = new Order();

                            order.ID_Order = (int)dr["ID_Order"];

                            order.ID_person = (int)dr["ID_person"];

                            order.OrderDate = (DateTime)dr["OrderDate"];
                            
                            order.DelaiLivraison = (DateTime)dr["DelaiLivraison"];

                            results.Add(order);
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

        public Order GetOrderIDOrder(int ID_Order)
        {
            Order order = null;

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from [Order] where ID_Order = @ID_Order";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_Order", ID_Order);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            order = new Order();

                            order.ID_Order = (int)dr["ID_Order"];

                            order.ID_person = (int)dr["ID_person"];

                            order.OrderDate = (DateTime)dr["OrderDate"];

                            order.DelaiLivraison = (DateTime)dr["DelaiLivraison"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order;
        }

        public Order ModifyAllOrder(Order order)
        {
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update [Order] set ID_person = @ID_person and OrderName=@OrderName and OrderDate=@OrderDate and DelaiLivraison=@DelaiLivraison where ID_Order=@ID_Order";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_person", order.ID_person);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@ID_Order", order.ID_Order);
                    cmd.Parameters.AddWithValue("@DelaiLivraison", order.DelaiLivraison);

                    cn.Open();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return order;
        }
    }
}
