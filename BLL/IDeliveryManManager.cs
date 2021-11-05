using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IDeliveryManManager
    {
        DeliveryMan AddDeliveryMan(DeliveryMan delivery);
        DeliveryMan ChangeIsWorking(int IdDelivery, int IsWorking);
        List<Dishes> GetAllDishes(string login, string password);
        DeliveryMan GetDeliveryMan(string username, string password);
        DeliveryMan GetDeliveryManID(int deliveryMamId);
        List<DeliveryMan> GetDeliveryMen();
        List<Dishes> GetDishes(int IdOrder);
        Location GetLocation(string login, string password);
        List<Order> GetOrders(string login, string password);
        List<Person> GetPersonWorkCity(string City);
        List<Restaurant> GetRestaurantsWorkCanton(string Canton);
        List<Restaurant> GetRestaurantsWorkCity(string City);
        WorkLocation GetWorkLocation(string login, string password);
    }
}