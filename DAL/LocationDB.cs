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
    public class LocationDB : ILocationDB
    {
        private IConfiguration Configuration { get; }

        public LocationDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Location> GetLocations()
        {
            List<Location> results = null;
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Location";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Location>();

                            Location location = new Location();

                            location.ID_location = (int)dr["ID_location"];
                            location.NPA = (int)dr["NPA"];
                            location.City = (string)dr["City"];
                            location.Canton = (string)dr["Canton"];

                            results.Add(location);
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
        public Location GetLocationNPA(string NPA)
        {
            Location location = null;
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Location where NPA=@NPA";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@NPA", NPA);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            location = new Location();

                            location.ID_location = (int)dr["ID_location"];
                            location.NPA = (int)dr["NPA"];
                            location.City = (string)dr["City"];
                            location.Canton = (string)dr["Canton"];

                        }

                    }

                }


            }
            catch (Exception e)
            {
                throw e;
            }
            return location;

        }

        public Location GetLocationID(int IdLocation)
        {
            Location location = null;
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Location where ID_location=@IdLocation";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdLocation", IdLocation);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            location = new Location();

                            location.ID_location = (int)dr["ID_location"];
                            location.NPA = (int)dr["NPA"];
                            location.City = (string)dr["City"];
                            location.Canton = (string)dr["Canton"];

                        }

                    }

                }


            }
            catch (Exception e)
            {
                throw e;
            }
            return location;

        }

        public Location GetLocationCity(string City)
        {
            Location location = null;
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Location where City=@City";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@City", City);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            location = new Location();

                            location.ID_location = (int)dr["ID_location"];
                            location.NPA = (int)dr["NPA"];
                            location.City = (string)dr["City"];
                            location.Canton = (string)dr["Canton"];

                        }

                    }

                }


            }
            catch (Exception e)
            {
                throw e;
            }
            return location;

        }

        public int GetLocationNPACity(string NPA, string City)
        {
            Location location = null;
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Location where NPA=@NPA and City=@city";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@NPA", NPA);
                    cmd.Parameters.AddWithValue("@city", City);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            location = new Location();

                            location.ID_location = (int)dr["ID_location"];
                            location.NPA = (int)dr["NPA"];
                            location.City = (string)dr["City"];
                            location.Canton = (string)dr["Canton"];

                        }

                    }

                }


            }
            catch (Exception e)
            {
                throw e;
            }
            return location.ID_location;

        }
        public List<Location> GetLocationCanton(string Canton)
        {
            List<Location> results = null;
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Location where Canton=@canton";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@canton", Canton);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Location>();

                            Location location = new Location();

                            location.ID_location = (int)dr["ID_location"];
                            location.NPA = (int)dr["NPA"];
                            location.City = (string)dr["City"];
                            location.Canton = (string)dr["Canton"];

                            results.Add(location);
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


    }
}
