using WebApi.Data.Interfaces;
using WebApi.Entities.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Implementations
{
    public class MealServices : GenericServices<Meal, IMealRepository>, IMealServices
    {
        public MealServices(IMealRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<Meal>> GetAllMeals()
        {
            return await _repository.GetAllMeals();
        }

       public async Task<Meal> FindById(string id)
        {
            return await _repository.FindById(id);
        }
    }
}
