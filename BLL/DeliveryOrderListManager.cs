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
    public class DeliveryOrderListManager
    {
        private IDeliveryOrderListDB DeliveryOrderListBd { get; }

        public DeliveryOrderListManager(IConfiguration conf)
        {
            DeliveryOrderListBd = new DeliveryOrderListDB(conf);
        }
        public DeliveryOrderList AddDeliveryOrderList(DeliveryOrderList deliveryOrderList)
        {
            return DeliveryOrderListBd.AddDeliveryOrderList(deliveryOrderList);
        }
        public DeliveryOrderList GetDeliveryOrderList(int IdDeliveryMan)
        {
            return DeliveryOrderListBd.GetDeliveryOrderList(IdDeliveryMan);
        }
        public List<DeliveryOrderList> GetDeliveryOrderLists()
        {
            return DeliveryOrderListBd.GetDeliveryOrderLists();
        }

        public DeliveryOrderList ModifyStatut(DeliveryOrderList deliveryOrderList)
        {
            return DeliveryOrderListBd.ModifyStatut(deliveryOrderList);
        }
    }
}
