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
    public class DishesDB : IDishesDB
    {
        private IConfiguration Configuration { get; }

        public DishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Dishes> GetDishes()
        {
            List<Dishes> results = null;
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Dishes";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Dishes>();

                            Dishes dishes = new Dishes();

                            dishes.ID_Dishes = (int)dr["ID_Dishes"];

                            dishes.DishesName = (string)dr["DishesName"];

                            dishes.DishesPrice = (int)dr["DishesPrice"];

                            if (dr["DishesDescription"] != null)
                                dishes.DishesDescription = (string)dr["DishesDescription"];

                            dishes.DishImage = (string)dr["DishImage"];

                            dishes.isDishAvailable = (int)dr["isDishAvailable"];

                            results.Add(dishes);
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


        public Dishes GetDish(string DishName)
        {
            Dishes dish = null;

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Dishes where DishesName = @DishName";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@DishName", DishName);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            dish = new Dishes();

                            dish.ID_Dishes = (int)dr["ID_Dishes"];

                            dish.DishesName = (string)dr["DishesName"];

                            dish.DishesPrice = (int)dr["DishesPrice"];

                            if (dr["DishesDescription"] != null)
                                dish.DishesDescription = (string)dr["DishesDescription"];

                            dish.DishImage = (string)dr["DishImage"];

                            dish.isDishAvailable = (int)dr["isDishAvailable"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dish;
        }

        public Dishes GetDishIP(int ID_Dishes)
        {
            Dishes dish = null;

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Dishes where ID_Dishes = @ID_Dishes";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_Dishes", ID_Dishes);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            dish = new Dishes();

                            dish.ID_Dishes = (int)dr["ID_Dishes"];

                            dish.DishesName = (string)dr["DishesName"];

                            dish.DishesPrice = (int)dr["DishesPrice"];

                            if (dr["DishesDescription"] != null)
                                dish.DishesDescription = (string)dr["DishesDescription"];

                            dish.DishImage = (string)dr["DishImage"];

                            dish.isDishAvailable = (int)dr["isDishAvailable"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dish;
        }

        public Dishes AddDish(Dishes dish)
        {

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "Insert into Dishes( DishesName, DishesDescription, DishesPrice, DishImage, isDishAvailable) values( @DishesName, @DishesDescription, @DishesPrice, @DishImage, @isDishAvailable); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    
                    cmd.Parameters.AddWithValue("@DishesName", dish.DishesName);
                    cmd.Parameters.AddWithValue("@DishesDescription", dish.DishesDescription);
                    cmd.Parameters.AddWithValue("@DishesPrice", dish.DishesPrice);
                    cmd.Parameters.AddWithValue("@DishImage", dish.DishImage);
                    cmd.Parameters.AddWithValue("@isDishAvailable", dish.isDishAvailable);
        

                    cn.Open();

                    dish.ID_Dishes = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dish;
        }

        public Dishes ChangeAvailabilityDish(int ID_Dish, int isDishAvailable)
        {

            Dishes dish = null;

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    dish = new Dishes();
                    string query = "UPDATE Dishes SET isDishAvailable = @isDishAvailable Where ID_Dishes = @ID_Dishes; ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_Dishes", ID_Dish);
                    cmd.Parameters.AddWithValue("@isDishAvailable", isDishAvailable);
                    
                    cn.Open();

                    
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dish;
        }
    }
}
