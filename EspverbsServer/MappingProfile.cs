using AutoMapper;
using espverbs.Domain;
using espverbs.Domain.Words.Verbs;
using espverbs.Server.Models;
using Server.Models;

namespace Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Verb, VerbViewModel>().ReverseMap();
        }
    }
}
