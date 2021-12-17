using System.Collections.Generic;
using System.Threading.Tasks;
using WebMvc.Models.OrderModels;

namespace WebMvc.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders();
        Task<Order> GetOrder(string orderId);
        Task<int> CreateOrder(Order order);
    }
}
