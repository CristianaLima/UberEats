using DTO;
using System.Collections.Generic;

namespace DAL
{
    public interface IOrderDishesDB
    {
        OrderDishes AddOrderDishes(OrderDishes orderDishes);
        List<OrderDishes> GetAllOrderDishes();
        List<OrderDishes> GetOrderDishes(int IdOrder);
        void Remove(int idOrder, int idDish);
    }
}