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


        public List<RestaurantDishes> GetRestaurant(int ID_Dish)
        {
            List<RestaurantDishes> results = null;
            
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
                            if (results == null)
                                results = new List<RestaurantDishes>();

                            RestaurantDishes restaurantDishes = new RestaurantDishes();

                            restaurantDishes.ID_restaurant = (int)dr["ID_restaurant"];

                            restaurantDishes.ID_Dishes = (int)dr["ID_Dishes"];

                            results.Add(restaurantDishes);
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

        public RestaurantDishes AddRestaurantDishes(RestaurantDishes restaurantDishes)
        {
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into RestaurantDishes(ID_Dishes, ID_restaurant) values(@ID_Dishes, @ID_restaurant); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_Dishes", restaurantDishes.ID_Dishes);
                    cmd.Parameters.AddWithValue("@ID_restaurant", restaurantDishes.ID_restaurant);

                    cn.Open();

                   

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return restaurantDishes;


        }
    }
}
