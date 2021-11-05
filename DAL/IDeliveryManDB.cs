using DTO;
using System.Collections.Generic;

namespace DAL
{
    public interface IDeliveryManDB
    {
        DeliveryMan AddDeliveryMan(DeliveryMan delivery);
        DeliveryMan GetDeliveryMan(string username, string password);
        DeliveryMan GetDeliveryManID(int deliveryMamId);
        List<DeliveryMan> GetDeliveryMen();
        DeliveryMan ChangeIsWorking(int IdDelivery, int IsWorking);
        DeliveryMan ModifyAllDeliveryMan(DeliveryMan delivery);
        void ChangeNbDeliveries(int n, int ID_DeliveryMan);
        List<DeliveryMan> GetDeliveryManIDLocation(int ID_Location);
    }
}