using Domain;
using espverbs.Domain.Words.Verbs.Mutations;
using espverbs.Server.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Server.Services.WordServices
{
    public class RegularVerbsMutationService : IRegularVerbsMutationService
    {
        private readonly EspverbsContext _context;

        public RegularVerbsMutationService(EspverbsContext context)
        {
            _context = context;
        }

        public async Task<ResultObject<RegularVerbsMutation>> CreateAsync(RegularVerbsMutation mutation)
        {
            try
            {
                _context.RegularVerbsMutations.Add(mutation);
                await _context.SaveChangesAsync();
                return ResultObject<RegularVerbsMutation>.Succeed(mutation);
            }
            catch (Exception ex)
            {
                return ResultObject<RegularVerbsMutation>.Failure("Не удалось сохранить обьект!", ex);
            }
        }

        public async Task<ResultObject<object>> DeleteAsync(int id)
        {
            try
            {
                ResultObject<RegularVerbsMutation> _res = await GetAsync(id);
                if (_res.Success)
                {
                    RegularVerbsMutation _mutation = _res.Result;
                    await DeleteAsync(_mutation);
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

        public async Task<ResultObject<object>> DeleteAsync(RegularVerbsMutation mutation)
        {
            try
            {
                await DeleteAsync(mutation);
                return ResultObject<object>.Succeed(null);
            }
            catch (Exception ex)
            {
                return ResultObject<object>.Failure("Не удалось удалить объект!", ex);
            }
        }

        public async Task<ResultObject<List<RegularVerbsMutation>>> GetAllAsync()
        {
            try
            {
                List<RegularVerbsMutation> _list = await _context.RegularVerbsMutations.ToListAsync();
                return ResultObject<List<RegularVerbsMutation>>.Succeed(_list);
            }
            catch (Exception ex)
            {
                return ResultObject<List<RegularVerbsMutation>>.Failure("Не удалось получить данные!", ex);
            }
        }

        public async Task<ResultObject<RegularVerbsMutation>> GetAsync(int id)
        {
            try
            {
                RegularVerbsMutation? _mutation = await _context.RegularVerbsMutations
                    .Include("Tense")
                    //.Include("Rest")
                    //.FirstOrDefaultAsync(u => u.Id == id);
                    .FirstOrDefaultAsync();

                if (_mutation is null)
                {
                    return ResultObject<RegularVerbsMutation>.Failure("Объект не найден!", new Exception());
                }

                return ResultObject<RegularVerbsMutation>.Succeed(_mutation);
            }
            catch (Exception ex)
            {
                return ResultObject<RegularVerbsMutation>.Failure("Ошибка при получении объекта!", ex);
            }
        }

        public async Task<ResultObject<object>> UpdateAsync(RegularVerbsMutation mutation)
        {
            try
            {
                _context.RegularVerbsMutations.Update(mutation);
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
