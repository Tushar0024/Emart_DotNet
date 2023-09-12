using Emart_final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emart_final.Models.Repository.Orderfolder
{
    public interface IOrderRepository
    {
        Task<Order> SaveOrder(Order order);
        Task<Order> GetOrderById(int id);
        Task<IEnumerable<Order>> GetAllOrders();
        Task DeleteOrder(int id);
        Task<Order> UpdateOrder(Order order, int id);
    }
}
