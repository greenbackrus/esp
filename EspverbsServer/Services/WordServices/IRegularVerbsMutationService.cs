using Domain;
using espverbs.Domain.Words.Verbs.Mutations;

namespace Server.Services.WordServices
{
    public interface IRegularVerbsMutationService
    {
        Task<ResultObject<RegularVerbsMutation>> CreateAsync(RegularVerbsMutation mutation);
        Task<ResultObject<object>> DeleteAsync(int id);
        Task<ResultObject<object>> DeleteAsync(RegularVerbsMutation mutation);
        Task<ResultObject<List<RegularVerbsMutation>>> GetAllAsync();
        Task<ResultObject<RegularVerbsMutation>> GetAsync(int id);
        Task<ResultObject<object>> UpdateAsync(RegularVerbsMutation mutation);
    }
}