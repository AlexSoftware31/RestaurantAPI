using Microsoft.EntityFrameworkCore;
using WebApi.Data.Interfaces;
using WebApi.Entities.Models;

namespace WebApi.Data.Repositories
{
    public class UserLoginRepository(AppDbContext context) : GenericRepository<UserLogin>(context), IUserLoginRepository
    {
        public async Task<bool> IsAuthorized(UserLogin userLogin)
        {  
            var user = await _context.UserLogin.Where(u => u.Username == userLogin.Username).FirstOrDefaultAsync();

            if (user == null)
                return false;

            bool isValid = BCrypt.Net.BCrypt.Verify(userLogin.Password, user.Password);

            return isValid;
        }
    }
}
