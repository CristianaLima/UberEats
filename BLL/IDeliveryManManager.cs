using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IDeliveryManManager
    {
        DeliveryMan AddDeliveryMan(DeliveryMan delivery);
        DeliveryMan ChangeIsWorking(int IdDelivery, int IsWorking);
        void ChangeNbDeliveries(int n, int ID_DeliveryMan);
        
        DeliveryMan GetDeliveryMan(string username, string password);
        DeliveryMan GetDeliveryManID(int deliveryMamId);
        List<DeliveryMan> GetDeliveryManIDLocation(int ID_Location);
        List<DeliveryMan> GetDeliveryMen();
        
        Location GetLocation(string login, string password);
        List<Order> GetOrders(string login, string password);
        List<Person> GetPersonWorkCity(string City);
        List<Restaurant> GetRestaurantsWorkCanton(string Canton);
        List<Restaurant> GetRestaurantsWorkCity(string City);
        WorkLocation GetWorkLocation(string login, string password);
        DeliveryMan ModifyAllDeliveryMan(DeliveryMan delivery);
    }
}