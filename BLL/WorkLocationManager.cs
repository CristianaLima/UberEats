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
    public class WorkLocationManager
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

        public int GetWorkLocationID(int NPA_Work, string CityWork)
        {
            return WorkLocationDB.GetWorkLocationID(NPA_Work, CityWork);
        }
    }
}
