using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface ILocationManager
    {
        List<Location> GetLocationCanton(string Canton);
        Location GetLocationCity(string City);
        Location GetLocationID(int IdLocation);
        Location GetLocationNPA(string NPA);
        int GetLocationNPACity(string NPA, string City);
        List<Location> GetLocations();
        List<Restaurant> GetRestaurantsFromLocation(string Canton);
    }
}