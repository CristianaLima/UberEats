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
    public class RestaurantDB : IRestaurantDB
    {
        private IConfiguration Configuration { get; }

        public RestaurantDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //To have all the restaurants
        public List<Restaurant> GetRestaurants()
        {
            List<Restaurant> results = null;
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Restaurant";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Restaurant>();

                            Restaurant restaurant = new Restaurant();

                            restaurant.ID_restaurant = (int)dr["ID_Restaurant"];

                            restaurant.ID_location = (int)dr["ID_location"];

                            restaurant.RestaurantName = (string)dr["RestaurantName"];         

                            restaurant.RestaurantAddress = (string)dr["RestaurantAddress"];

                            restaurant.RestaurantImage = (string)dr["RestaurantImage"];

                            restaurant.IsRestaurantAvailable = (int)dr["IsRestaurantAvailable"];

                            results.Add(restaurant);
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

        //To get the restaurant with its name
        public Restaurant GetRestaurant(string RestaurantName)
        {
            Restaurant restaurant = null;

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Restaurant where RestaurantName = @RestaurantName";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@RestaurantName", RestaurantName);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            restaurant = new Restaurant();

                            restaurant.ID_restaurant = (int)dr["ID_Restaurant"];

                            restaurant.ID_location = (int)dr["ID_location"];

                            restaurant.RestaurantName = (string)dr["RestaurantName"];

                            restaurant.RestaurantAddress = (string)dr["RestaurantAddress"];

                            restaurant.RestaurantImage = (string)dr["RestaurantImage"];
                            
                            restaurant.IsRestaurantAvailable = (int)dr["IsRestaurantAvailable"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurant;
        }

        //To get the restaurant with its id
        public Restaurant GetRestaurantID(int ID_Restaurant)
        {
            Restaurant restaurant = null;

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Restaurant where ID_Restaurant = @ID_Restaurant";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_Restaurant", ID_Restaurant);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            restaurant = new Restaurant();

                            restaurant.ID_restaurant = (int)dr["ID_Restaurant"];

                            restaurant.ID_location = (int)dr["ID_location"];

                            restaurant.RestaurantName = (string)dr["RestaurantName"];
                         
                            restaurant.RestaurantAddress = (string)dr["RestaurantAddress"];

                            restaurant.RestaurantImage = (string)dr["RestaurantImage"];
                            
                            restaurant.IsRestaurantAvailable = (int)dr["IsRestaurantAvailable"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurant;
        }

        //To add a restaurant to the database
        public Restaurant AddRestaurant(Restaurant restaurant)
        {

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "Insert into Restaurant( ID_location, RestaurantName, RestaurantAddress, RestaurantImage, IsRestaurantAvailable) values( @ID_location, @RestaurantName, @RestaurantAddress, @RestaurantImage, @IsRestaurantAvailable); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    
                    cmd.Parameters.AddWithValue("@ID_location", restaurant.ID_location);
                    cmd.Parameters.AddWithValue("@RestaurantName", restaurant.RestaurantName);
                    cmd.Parameters.AddWithValue("@RestaurantAddress", restaurant.RestaurantAddress);
                    cmd.Parameters.AddWithValue("@RestaurantImage", restaurant.RestaurantImage);
                    cmd.Parameters.AddWithValue("@IsRestaurantAvailable", restaurant.IsRestaurantAvailable);
                 


                    cn.Open();

                    
                    restaurant.ID_restaurant= Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurant;
        }

        //To change the availability of the restaurant
        //If the availability is 0, it's closed
        // If the availability is 1, it's open
        public Restaurant ChangeAvailabilityRestaurant(int ID_restaurant, int IsRestaurantAvailable)
        {

            Restaurant restaurant = null;

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    restaurant = new Restaurant();
                    string query = "UPDATE Restaurant SET IsRestaurantAvailable = @IsRestaurantAvailable Where ID_restaurant = @ID_restaurant; ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_restaurant", ID_restaurant);
                    cmd.Parameters.AddWithValue("@IsRestaurantAvailable", IsRestaurantAvailable);

                    cn.Open();

                   
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurant;
        }

        //To get a list of restaurant with a id of the location
        public List<Restaurant> GetRestaurantIDLocation( int IdLocation)
        {
            List<Restaurant> results = null;
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Restaurant where ID_location = @IdLocation";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdLocation", IdLocation);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Restaurant>();

                            Restaurant restaurant = new Restaurant();

                            restaurant.ID_restaurant = (int)dr["ID_Restaurant"];

                            restaurant.ID_location = (int)dr["ID_location"];

                            restaurant.RestaurantName = (string)dr["RestaurantName"];

                            restaurant.RestaurantAddress = (string)dr["RestaurantAddress"];

                            restaurant.RestaurantImage = (string)dr["RestaurantImage"];

                            restaurant.IsRestaurantAvailable = (int)dr["IsRestaurantAvailable"];

                            results.Add(restaurant);
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

        //To modify a restaurant
        public Restaurant ModifyAllRestaurant(Restaurant restaurant)
        {
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update Restaurant set ID_location = @ID_location and RestaurantName = @RestaurantName and RestaurantAddress=@RestaurantAddress and RestaurantImage=@RestaurantImage and IsRestaurantAvailable=@IsRestaurantAvailable where ID_Restaurant=@ID_Restaurant ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_Restaurant", restaurant.ID_restaurant);
                    cmd.Parameters.AddWithValue("@ID_location", restaurant.ID_location);
                    cmd.Parameters.AddWithValue("@RestaurantName", restaurant.RestaurantName);
                    cmd.Parameters.AddWithValue("@RestaurantAddress", restaurant.RestaurantAddress);
                    cmd.Parameters.AddWithValue("@RestaurantImage", restaurant.RestaurantImage);
                    cmd.Parameters.AddWithValue("@IsRestaurantAvailable", restaurant.IsRestaurantAvailable);

                    cn.Open();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return restaurant;
        }
    }
}
