using DTO;
using System.Collections.Generic;

namespace DAL
{
    public interface ILocationDB
    {
        Location GetLocationCity(string City);
        Location GetLocationID(int IdLocation);
        Location GetLocationNPA(string NPA);
        List<Location> GetLocations();
    }
}