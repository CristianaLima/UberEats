using DTO;
using System.Collections.Generic;

namespace DAL
{
    public interface IDeliveryOrderListDB
    {
        DeliveryOrderList AddDeliveryOrderList(DeliveryOrderList deliveryOrderList);
        DeliveryOrderList GetDeliveryOrderList(int IdDeliveryMan);
        List<DeliveryOrderList> GetDeliveryOrderLists();
        DeliveryOrderList ModifyStatut(DeliveryOrderList deliveryOrderList);
    }
}