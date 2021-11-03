
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IWorkLocationDB
    {

        List<WorkLocation> GetWorkLocations();
        int GetWorkLocationNPACity(int NPA_Work, string CityWork);
        WorkLocation GetWorkLocationID(int IdWorkLocation);
        WorkLocation GetWorkLocationCity(string City);
        List<WorkLocation> GetWorkLocationCanton(string Canton);
    }
}
