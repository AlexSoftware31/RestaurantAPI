using WebApi.Entities.Models;

namespace WebApi.Services.Interfaces
{
    public interface IOrderServices : IGenericServices<OrderInformation>
    {
        Task Add(OrderInformation orderInformation);

        Task<OrderInformation> FindById(int id);
    }
}
