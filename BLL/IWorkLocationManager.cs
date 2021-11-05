using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IWorkLocationManager
    {
        List<WorkLocation> GetWorkLocationCanton(string Canton);
        WorkLocation GetWorkLocationCity(string City);
        WorkLocation GetWorkLocationID(int IdWorkLocation);
        int GetWorkLocationNPACity(int NPA_Work, string CityWork);
        List<WorkLocation> GetWorkLocations();
    }
}