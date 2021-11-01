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
    public class DeliveryManManager
    {
        private IDeliveryManDB DeliveryManDB { get; }

        public DeliveryManManager(IConfiguration conf)
        {
            DeliveryManDB = new DeliveryManDB(conf);
        }

        public DeliveryMan AddDeliveryMan(DeliveryMan delivery)
        {
            return DeliveryManDB.AddDeliveryMan(delivery);
        }

        public DeliveryMan GetDeliveryMan(string username, string password)
        {
            return DeliveryManDB.GetDeliveryMan(username, password);
        }

        public DeliveryMan GetDeliveryManID(int deliveryMamId)
        {
            return DeliveryManDB.GetDeliveryManID(deliveryMamId);
        }
        public List<DeliveryMan> GetDeliveryMen()
        {
            return DeliveryManDB.GetDeliveryMen();
        }
    }
}
