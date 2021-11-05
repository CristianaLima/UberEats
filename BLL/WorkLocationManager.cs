using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WorkLocationManager : IWorkLocationManager
    {
        private IWorkLocationDB WorkLocationDB { get; }

        public WorkLocationManager(IConfiguration conf)
        {
            WorkLocationDB = new WorkLocationDB(conf);
        }

        public List<WorkLocation> GetWorkLocations()
        {
            return WorkLocationDB.GetWorkLocations();
        }

        public int GetWorkLocationNPACity(int NPA_Work, string CityWork)
        {
            return WorkLocationDB.GetWorkLocationNPACity(NPA_Work, CityWork);
        }

        public List<WorkLocation> GetWorkLocationCanton(string Canton)
        {
            return WorkLocationDB.GetWorkLocationCanton(Canton);
        }

        public WorkLocation GetWorkLocationCity(string City)
        {
            return WorkLocationDB.GetWorkLocationCity(City);
        }

        public WorkLocation GetWorkLocationID(int IdWorkLocation)
        {
            return WorkLocationDB.GetWorkLocationID(IdWorkLocation);
        }
    }
}
