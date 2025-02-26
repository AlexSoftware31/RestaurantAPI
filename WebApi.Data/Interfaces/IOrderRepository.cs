using WebApi.Entities.Models;

namespace WebApi.Data.Interfaces
{
    public interface IOrderRepository : IGenericRepository<OrderInformation>
    {
        Task Add (OrderInformation orderInformation);
        Task<OrderInformation> FindById (int id);
    }
}
