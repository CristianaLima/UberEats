using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Order
    {
        public int ID_Order { get; set; }
        public int ID_person { get; set; }
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
