using espverbs.Domain.Words.Verbs;
using espverbs.Domain;
using espverbs.Server.DataContext;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Server.Services.WordServices
{
    public class VerbService : IVerbService
    {
        private readonly EspverbsContext _context;

        public VerbService(EspverbsContext context)
        {
            _context = context;
        }

        public async Task<ResultObject<Verb>> CreateAsync(Verb verb)
        {
            try
            {
                _context.Verbs.Add(verb);
                await _context.SaveChangesAsync();
                return ResultObject<Verb>.Succeed(verb);
            }
            catch (Exception ex)
            {
                return ResultObject<Verb>.Failure("Не удалось сохранить обьект!", ex);
            }
        }

        public async Task<ResultObject<object>> DeleteAsync(int id)
        { 
            try
            {
                ResultObject<Verb> _res = await GetAsync(id);
                if (_res.Success)
                {
                    Verb _verb = _res.Result;
                    await DeleteAsync(_verb);
                } else
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

        public async Task<ResultObject<object>> DeleteAsync(Verb verb)
        {
            try
            {
                await DeleteAsync(verb);
                return ResultObject<object>.Succeed(null);
            }
            catch (Exception ex)
            {
                return ResultObject<object>.Failure("Не удалось удалить объект!", ex);
            }
        }

        public async Task<ResultObject<List<Verb>>> GetAllAsync()
        {
            try
            {
                List<Verb> _list = await _context.Verbs.ToListAsync();
                return ResultObject<List<Verb>>.Succeed(_list);
            }
            catch (Exception ex)
            {
                return ResultObject<List<Verb>>.Failure("Не удалось получить данные!", ex);
            }
        }

        public async Task<ResultObject<Verb>> GetAsync(int id)
        {
            try
            {
                Verb? _verb = await _context.Verbs
                    //.Include("User")
                    //.Include("Rest")
                    //.FirstOrDefaultAsync(u => u.Id == id);
                    .FirstOrDefaultAsync();

                if (_verb is null)
                {
                    return ResultObject<Verb>.Failure("Объект не найден!", new Exception());
                }

                return ResultObject<Verb>.Succeed(_verb);
            }
            catch (Exception ex)
            {
                return ResultObject<Verb>.Failure("Ошибка при получении объекта!", ex);
            }
        }

        public async Task<ResultObject<object>> UpdateAsync(Verb verb)
        {
            try
            {
                _context.Verbs.Update(verb);
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
