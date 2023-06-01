using Domain;
using espverbs.Domain.Words.Verbs;

namespace Server.Services.WordServices
{
    public interface IVerbService
    {
        Task<ResultObject<Verb>> CreateAsync(Verb verb);
        Task<ResultObject<object>> DeleteAsync(int id);
        Task<ResultObject<object>> DeleteAsync(Verb verb);
        Task<ResultObject<List<Verb>>> GetAllAsync();
        Task<ResultObject<Verb>> GetAsync(int id);
        Task<ResultObject<object>> UpdateAsync(Verb verb);
    }
}