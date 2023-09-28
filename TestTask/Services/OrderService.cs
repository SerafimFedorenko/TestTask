using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class OrderService : IOrderService
    {
        private ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrder()
        {
            var order = _context.Orders.OrderByDescending(order => order.Price * order.Quantity).FirstOrDefault();
            return order;
        }

        public async Task<List<Order>> GetOrders()
        {
            var orders = _context.Orders.Where(order => order.Quantity > 10).ToList();
            return orders;
        }
    }
}
