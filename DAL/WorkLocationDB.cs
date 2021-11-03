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
    public class WorkLocationDB : IWorkLocationDB
    {
        private IConfiguration Configuration { get; }

        public WorkLocationDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<WorkLocation> GetWorkLocations()
        {
            List<WorkLocation> results = null;
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from WorkLocation";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<WorkLocation>();

                            WorkLocation workLocation = new WorkLocation();

                            workLocation.ID_workLocation = (int)dr["ID_WorkLocation"];

                            workLocation.NPA_Work = (int)dr["NPA_Work"];

                            workLocation.CityWork = (string)dr["CityWork"];
                            
                            workLocation.Canton = (string)dr["Canton"];

                            results.Add(workLocation);
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


        public int GetWorkLocationNPACity(int NPA_Work, string CityWork)
        {
            WorkLocation workLocation = null;

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from WorkLocation where NPA_Work = @NPA_Work AND CityWork = @CityWork";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@NPA_Work", NPA_Work);
                    cmd.Parameters.AddWithValue("@CityWork", CityWork);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            workLocation = new WorkLocation();

                            workLocation.ID_workLocation = (int)dr["ID_workLocation"];
                            workLocation.Canton = (string)dr["Canton"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return workLocation.ID_workLocation;
        }

        public WorkLocation GetWorkLocationID(int IdWorkLocation)
        {
            WorkLocation workLocation = null;
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from WorkLocation where ID_workLocation=@IdWorkLocation";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdWorkLocation", IdWorkLocation);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            workLocation = new WorkLocation();

                            workLocation.ID_workLocation = (int)dr["ID_workLocation"];
                            workLocation.NPA_Work = (int)dr["NPA_Work"];
                            workLocation.CityWork = (string)dr["CityWork"];
                            workLocation.Canton = (string)dr["Canton"];

                        }

                    }

                }


            }
            catch (Exception e)
            {
                throw e;
            }
            return workLocation;

        }

        public WorkLocation GetWorkLocationCity(string City)
        {
            WorkLocation workLocation = null;
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from WorkLocation where CityWork=@City";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@City", City);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            workLocation = new WorkLocation();

                            workLocation.ID_workLocation = (int)dr["ID_workLocation"];
                            workLocation.NPA_Work = (int)dr["NPA_Work"];
                            workLocation.CityWork = (string)dr["CityWork"];
                            workLocation.Canton = (string)dr["Canton"];

                        }

                    }

                }


            }
            catch (Exception e)
            {
                throw e;
            }
            return workLocation;

        }

        public List<WorkLocation> GetWorkLocationCanton(string Canton)
        {
            List<WorkLocation> results = null;
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = UberEat_Theo_Cristiana; Integrated Security = False; User Id = 6231db; Password = Pwd46231.; MultipleActiveResultSets = True";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from WorkLocation where Canton=@canton";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@canton", Canton);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<WorkLocation>();

                            WorkLocation workLocation = new WorkLocation();

                            workLocation.ID_workLocation = (int)dr["ID_WorkLocation"];

                            workLocation.NPA_Work = (int)dr["NPA_Work"];

                            workLocation.CityWork = (string)dr["CityWork"];

                            workLocation.Canton = (string)dr["Canton"];

                            results.Add(workLocation);
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
