using Microsoft.EntityFrameworkCore;
using WebApi.Data.Interfaces;
using WebApi.Entities.Models;

namespace WebApi.Data.Repositories
{
    public class UserLoginRepository(AppDbContext context) : GenericRepository<UserLogin>(context), IUserLoginRepository
    {
        public async Task<bool> IsAuthorized(UserLogin userLogin)
        {  
            UserLogin? user = await _context.UserLogin.Where(u => u.Username == userLogin.Username && u.Password == userLogin.Password).FirstOrDefaultAsync();
            
            return user != null;
        }
    }
}
