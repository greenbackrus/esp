using espverbs.Domain;
using espverbs.Server.DataContext;
using Microsoft.EntityFrameworkCore;
using Domain;
using Server.Services.WordServices;
using espverbs.Domain.Users;

namespace Server.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly EspverbsContext _context;

        public UserService(EspverbsContext context)
        {
            _context = context;
        }

        public async Task<ResultObject<User>> CreateAsync(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return ResultObject<User>.Succeed(user);
            }
            catch (Exception ex)
            {
                return ResultObject<User>.Failure("Не удалось сохранить объект!", ex);
            }
        }

        public async Task<ResultObject<object>> DeleteAsync(int id)
        {
            try
            {
                ResultObject<User> _res = await GetAsync(id);
                if (_res.Success)
                {
                    User _user = _res.Result;
                    await DeleteAsync(_user);
                }
                else
                {
                    return ResultObject<object>.Failure("Не удалось найти объект с таким id!", new Exception());
                }
                return ResultObject<object>.Succeed(null);
            }
            catch (Exception ex)
            {
                return ResultObject<object>.Failure("Не удалось удалить объект!", ex);
            }
        }

        public async Task<ResultObject<object>> DeleteAsync(User user)
        {
            try
            {
                await DeleteAsync(user);
                return ResultObject<object>.Succeed(null);
            }
            catch (Exception ex)
            {
                return ResultObject<object>.Failure("Не удалось удалить объект!", ex);
            }
        }

        public async Task<ResultObject<List<User>>> GetAllAsync()
        {
            try
            {
                List<User> _list = await _context.Users.ToListAsync();
                return ResultObject<List<User>>.Succeed(_list);
            }
            catch (Exception ex)
            {
                return ResultObject<List<User>>.Failure("Не удалось получить данные!", ex);
            }
        }

        public async Task<ResultObject<User>> GetAsync(int id)
        {
            try
            {
                User? _user = await _context.Users
                    //.Include("User")
                    //.Include("Rest")
                    //.FirstOrDefaultAsync(u => u.Id == id);
                    .FirstOrDefaultAsync();

                if (_user is null)
                {
                    return ResultObject<User>.Failure("Объект не найден!", new Exception());
                }

                return ResultObject<User>.Succeed(_user);
            }
            catch (Exception ex)
            {
                return ResultObject<User>.Failure("Ошибка при получении объекта!", ex);
            }
        }

        public async Task<ResultObject<object>> UpdateAsync(User user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return ResultObject<object>.Succeed(null);
            }
            catch (Exception ex)
            {
                return ResultObject<object>.Failure("Не удалось обносить данные!", ex);
            }
        }
    }
}
