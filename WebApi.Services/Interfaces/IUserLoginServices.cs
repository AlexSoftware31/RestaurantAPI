using WebApi.Entities.Models;

namespace WebApi.Services.Interfaces
{
    public interface IUserLoginServices: IGenericServices<UserLogin>
    {
        Task<bool> IsAuthorized(UserLogin userLogin);
    }
}
