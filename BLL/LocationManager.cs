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
    public class LocationManager : ILocationManager
    {
        private ILocationDB LocationDb { get; }
        private IRestaurantDB RestaurantDB { get; }

        public LocationManager(IConfiguration conf)
        {
            LocationDb = new LocationDB(conf);
            RestaurantDB = new RestaurantDB(conf);
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
            return LocationDb.GetLocationNPACity(NPA, City);
        }

        public List<Location> GetLocationCanton(string Canton)
        {
            return LocationDb.GetLocationCanton(Canton);
        }

        public List<Restaurant> GetRestaurantsFromLocation(string Canton)
        {
            var locations = LocationDb.GetLocationCanton(Canton);

            var restaurants = new List<Restaurant>();

            foreach (var m in locations)
            {
                var restaurantss = RestaurantDB.GetRestaurantIDLocation(m.ID_location);
                if (restaurantss != null)
                {
                    restaurants.AddRange(restaurantss);
                }
            }

            return restaurants;
        }
    }
}
