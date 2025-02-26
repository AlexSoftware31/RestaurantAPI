using WebApi.Entities.Models;

namespace WebApi.Data.Interfaces
{
    public interface IUserLoginRepository: IGenericRepository<UserLogin>
    {
        Task<bool> IsAuthorized(UserLogin userLogin);
    }
}
