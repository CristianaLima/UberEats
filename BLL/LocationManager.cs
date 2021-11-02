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
    public class LocationManager
    {
        private ILocationDB LocationDb { get; }

        public LocationManager(IConfiguration conf)
        {
            LocationDb = new LocationDB(conf);
        }

        public Location GetLocationCity(string City)
        {
            return LocationDb.GetLocationCity(City);
        }

        public Location GetLocationID(int IdLocation)
        {
            return LocationDb.GetLocationID(IdLocation);
        }

        public Location GetLocationNPA(string NPA)
        {
            return LocationDb.GetLocationNPA(NPA);
        }
         public List<Location> GetLocations()
        {
            return LocationDb.GetLocations();
        }

        public int GetLocationNPACity(string NPA, string City)
        {
            return LocationDb.GetLocationNPACity(NPA,City);
        }

        public List<Location> GetLocationCanton(string Canton)
        {
            return LocationDb.GetLocationCanton(Canton);
        }
    }
}
