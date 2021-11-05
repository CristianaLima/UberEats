using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IOrderDishesManager
    {
        OrderDishes AddOrderDishes(OrderDishes orderDishes);
        List<OrderDishes> GetAllOrderDishes();
        List<OrderDishes> GetOrderDishes(int IdOrder);
    }
}