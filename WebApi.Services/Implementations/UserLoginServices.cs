using WebApi.Data.Interfaces;
using WebApi.Entities.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Implementations
{
    public class UserLoginServices: GenericServices<UserLogin, IUserLoginRepository>, IUserLoginServices
    {
        public UserLoginServices(IUserLoginRepository repository) {
          _repository = repository;
        }

        public async Task<bool> IsAuthorized(UserLogin userLogin)
        {
            return await _repository.IsAuthorized(userLogin);
        }

    }
}
