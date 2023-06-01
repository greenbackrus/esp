using Domain;
using espverbs.Domain.Users;

namespace Server.Services.UserServices
{
    public interface IUserService
    {
        Task<ResultObject<User>> CreateAsync(User user);
        Task<ResultObject<object>> DeleteAsync(int id);
        Task<ResultObject<object>> DeleteAsync(User user);
        Task<ResultObject<List<User>>> GetAllAsync();
        Task<ResultObject<User>> GetAsync(int id);
        Task<ResultObject<object>> UpdateAsync(User user);
    }
}