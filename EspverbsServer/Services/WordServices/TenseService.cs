using Domain;
using espverbs.Domain.Words.Tenses;
using espverbs.Domain.Words.Verbs;
using espverbs.Server.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Server.Services.WordServices
{
    public class TenseService : ITenseService
    {
        private readonly EspverbsContext _context;

        public TenseService(EspverbsContext context)
        {
            _context = context;
        }

        public async Task<ResultObject<Tense>> CreateAsync(Tense tense)
        {
            try
            {
                _context.Tenses.Add(tense);
                await _context.SaveChangesAsync();
                return ResultObject<Tense>.Succeed(tense);
            }
            catch (Exception ex)
            {
                return ResultObject<Tense>.Failure("Не удалось сохранить обьект!", ex);
            }
        }

        public async Task<ResultObject<object>> DeleteAsync(int id)
        {
            try
            {
                ResultObject<Tense> _res = await GetAsync(id);
                if (_res.Success)
                {
                    Tense _tense = _res.Result;
                    await DeleteAsync(_tense);
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

        public async Task<ResultObject<object>> DeleteAsync(Tense tense)
        {
            try
            {
                await DeleteAsync(tense);
                return ResultObject<object>.Succeed(null);
            }
            catch (Exception ex)
            {
                return ResultObject<object>.Failure("Не удалось удалить объект!", ex);
            }
        }

        public async Task<ResultObject<List<Tense>>> GetAllAsync()
        {
            try
            {
                List<Tense> _list = await _context.Tenses.ToListAsync();
                return ResultObject<List<Tense>>.Succeed(_list);
            }
            catch (Exception ex)
            {
                return ResultObject<List<Tense>>.Failure("Не удалось получить данные!", ex);
            }
        }

        public async Task<ResultObject<Tense>> GetAsync(int id)
        {
            try
            {
                Tense? _tense = await _context.Tenses
                    //.Include("User")
                    //.Include("Rest")
                    //.FirstOrDefaultAsync(u => u.Id == id);
                    .FirstOrDefaultAsync();

                if (_tense is null)
                {
                    return ResultObject<Tense>.Failure("Объект не найден!", new Exception());
                }

                return ResultObject<Tense>.Succeed(_tense);
            }
            catch (Exception ex)
            {
                return ResultObject<Tense>.Failure("Ошибка при получении объекта!", ex);
            }
        }

        public async Task<ResultObject<object>> UpdateAsync(Tense tense)
        {
            try
            {
                _context.Tenses.Update(tense);
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
