using WebApi.Entities.Models;

namespace WebApi.Data.Interfaces
{
    public interface IMealRepository : IGenericRepository<Meal>
    {
        Task<ICollection<Meal>> GetAllMeals();
        Task<Meal> FindById(string id);
    }
}
