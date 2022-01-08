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
    public class OrderDishesDB : IOrderDishesDB
    {
        private IConfiguration Configuration { get; }

        public OrderDishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //To get all the orderDishes
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

        //To get a list of orderDishes with its idOrder
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

        //To add a orderDishes
        public OrderDishes AddOrderDishes(OrderDishes orderDishes)
        {
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    
                    string query = "Insert into OrderDishes(ID_Dishes, ID_Order, Quantity) values(@IdDishes, @IdOrder, @Quantity)";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdDishes", orderDishes.ID_Dishes);
                    cmd.Parameters.AddWithValue("@IdOrder", orderDishes.ID_Order);
                    cmd.Parameters.AddWithValue("@Quantity", orderDishes.Quantity);

                    cn.Open();
                    cmd.ExecuteNonQuery();


                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return orderDishes;
        }

        //To remove a orderDishes with its idOrder and its idDish
        public void Remove(int idOrder, int idDish)
        {
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Delete OrderDishes set ID_Order = @ID_Order and ID_Dishes =@IdDishes";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_Order", idOrder);
                    cmd.Parameters.AddWithValue("@IdDishes", idDish);

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
