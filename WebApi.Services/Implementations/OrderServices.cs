using WebApi.Data.Interfaces;
using WebApi.Entities.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Implementations
{
    public class OrderServices : GenericServices<OrderInformation, IOrderRepository>, IOrderServices
    {
        public OrderServices(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(OrderInformation orderInformation)
        {
           await _repository.Add(orderInformation);
        }

        public async Task<OrderInformation> FindById(int id)
        {

            return await _repository.FindById(id);
        }


    }
}
