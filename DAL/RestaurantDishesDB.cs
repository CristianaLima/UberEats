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
    public class RestaurantDishesDB : IRestaurantDishesDB
    {
        private IConfiguration Configuration { get; }

        public RestaurantDishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public RestaurantDishes GetRestaurant(int ID_Dish)
        {
            RestaurantDishes restaurantdishes = null;

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from RestaurantDishes where ID_Dishes = @ID_Dishes";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_Dishes", ID_Dish);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            restaurantdishes = new RestaurantDishes();

                            restaurantdishes.ID_restaurant = (int)dr["ID_restaurant"];

                            restaurantdishes.ID_Dishes = (int)dr["ID_Dishes"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurantdishes;
        }

        public RestaurantDishes GetDishes(int ID_restaurant)
        {
            RestaurantDishes restaurantdishes = null;

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from RestaurantDishes where ID_restaurant = @ID_restaurant";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_restaurant", ID_restaurant);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            restaurantdishes = new RestaurantDishes();

                            restaurantdishes.ID_restaurant = (int)dr["ID_restaurant"];

                            restaurantdishes.ID_Dishes = (int)dr["ID_Dishes"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurantdishes;
        }

    }
}
