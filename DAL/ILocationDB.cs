using DTO;
using System.Collections.Generic;

namespace DAL
{
    public interface ILocationDB
    {
        Location GetLocationCity(string City);
        Location GetLocationID(int IdLocation);
        Location GetLocationNPA(int NPA);
        List<Location> GetLocations();
        int GetLocationNPACity(int NPA, string City);

        List<Location> GetLocationCanton(string Canton);
    }
}