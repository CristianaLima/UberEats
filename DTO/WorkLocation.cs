using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class WorkLocation
    {
        public int ID_workLocation { get; set; }
        public int NPA_Work { get; set; }
        public string CityWork { get; set; }
        public string Canton { get; set; }


        public override string ToString()
        {
            return " ID_workLocation " + ID_workLocation +
                    " NPA_Work " + NPA_Work +
                    " City of work " + CityWork +
                    " Canton " + Canton;
        }
    }

    
}
