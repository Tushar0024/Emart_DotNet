using Emart_final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emart_final.Models.Repository.Orderfolder
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> SaveOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                throw new Exception("Order not found");

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<Order> UpdateOrder(Order order, int id)
        {
            if (id != order.OrderID)
                throw new Exception("Invalid Order ID");

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return order;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                    throw new Exception("Order not found");
                else
                    throw;
            }
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(o => o.OrderID == id);
        }
    }
}
