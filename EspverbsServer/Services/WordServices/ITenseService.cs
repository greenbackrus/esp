using Domain;
using espverbs.Domain.Words.Verbs;

namespace Server.Services.WordServices
{
    public interface ITenseService
    {
        Task<ResultObject<Tense>> CreateAsync(Tense tense);
        Task<ResultObject<object>> DeleteAsync(int id);
        Task<ResultObject<object>> DeleteAsync(Tense tense);
        Task<ResultObject<List<Tense>>> GetAllAsync();
        Task<ResultObject<Tense>> GetAsync(int id);
        Task<ResultObject<object>> UpdateAsync(Tense tense);
    }
}