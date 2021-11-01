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
    public class OrderDishesDB : IOrderDishesDB
    {
        private IConfiguration Configuration { get; }

        public OrderDishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<OrderDishes> GetAllOrderDishes()
        {
            List<OrderDishes> results = null;
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from OrderDishes";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<OrderDishes>();

                            OrderDishes orderDishes = new OrderDishes();

                            orderDishes.ID_Dishes = (int)dr["ID_Dishes"];
                            orderDishes.ID_Order = (int)dr["ID_Order"];
                            orderDishes.Quantity = (int)dr["Quantity"];

                            results.Add(orderDishes);
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

        public List<OrderDishes> GetOrderDishes(int IdOrder)
        {
            List<OrderDishes> results = null;
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from OrderDishes where ID_Order=@idOrder";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idOrder", IdOrder);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<OrderDishes>();

                            OrderDishes orderDishes = new OrderDishes();

                            orderDishes.ID_Dishes = (int)dr["ID_Dishes"];
                            orderDishes.ID_Order = (int)dr["ID_Order"];
                            orderDishes.Quantity = (int)dr["Quantity"];

                            results.Add(orderDishes);
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

        public OrderDishes AddOrderDishes(OrderDishes orderDishes)
        {
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into OrderDishes(ID_Dishes, ID_Order, Quantity) values(@IdDishes, @IdOrder, @Quantity); SELECT SCOPE_IDENTITY()";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdDishes", orderDishes.ID_Dishes);
                    cmd.Parameters.AddWithValue("@IdOrder", orderDishes.ID_Order);
                    cmd.Parameters.AddWithValue("@Quantity", orderDishes.Quantity);

                    cn.Open();

                    orderDishes.ID_Dishes = Convert.ToInt32(cmd.ExecuteScalar());
                    orderDishes.ID_Order = Convert.ToInt32(cmd.ExecuteScalar());
                    orderDishes.Quantity = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return orderDishes;
        }

    }
}
