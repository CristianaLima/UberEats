
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
        WorkLocation GetWorkLocationID(int ID_workLocation);

    }
}
