using WebApi.Entities.Models;

namespace WebApi.Services.Interfaces
{
    public interface IMealServices:IGenericServices<Meal>
    {
        Task<ICollection<Meal>> GetAllMeals();
        Task<Meal> FindById(string id);
    }
}
