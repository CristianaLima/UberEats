using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IDeliveryOrderListManager
    {
        DeliveryOrderList AddDeliveryOrderList(DeliveryOrderList deliveryOrderList);
        DeliveryOrderList GetDeliveryFromOrder(int OrderID);
        List<DeliveryOrderList> GetDeliveryOrderList(int IdDeliveryMan);
        List<DeliveryOrderList> GetDeliveryOrderLists();
        DeliveryOrderList ModifyStatut(DeliveryOrderList deliveryOrderList);
    }
}