
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
        int GetWorkLocationID(int NPA_Work, string CityWork);

    }
}
