using Microsoft.EntityFrameworkCore;
using WebApi.Data.Interfaces;
using WebApi.Entities.Models;

namespace WebApi.Data.Repositories
{
    public class OrderRepository(AppDbContext context) : GenericRepository<OrderInformation>(context), IOrderRepository
    {

        public async Task Add(OrderInformation orderInformation)
        {
            _context.OrderInformation.Add(orderInformation);

            await _context.SaveChangesAsync();

        }

        public async Task<OrderInformation> FindById(int id)
        {
            OrderInformation order = await _context.OrderInformation.Where(o => o.OrderId == id).Include(d => d.OrderDetails).FirstAsync();

            return order;
        }
    }
}
