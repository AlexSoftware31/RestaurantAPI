using Microsoft.EntityFrameworkCore;
using WebApi.Data.Interfaces;
using WebApi.Entities.Models;

namespace WebApi.Data.Repositories
{
    public class MealRepository(AppDbContext context) : GenericRepository<Meal>(context), IMealRepository
    {
        public async Task<ICollection<Meal>> GetAllMeals()
        {
            return await _context.Meals.ToListAsync();
        }

        public async Task<Meal> FindById(string id)
        {
            Meal meal = await _context.Meals.Where(o => o.Id == id).FirstAsync();

            return meal;
        }
    }
}
