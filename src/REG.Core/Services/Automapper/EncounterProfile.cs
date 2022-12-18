using AutoMapper;
using REG.Core.Abstractions.Services.Models;
using REG.Core.Abstractions.Services.Models.Json;

namespace REG.Core.Services.Automapper;

public class EncounterProfile : Profile
{
    public EncounterProfile()
    {
        CreateMap<Monster, EncounterDetail>(MemberList.None)
            .ForMember(d => d.Hp, opt => opt.MapFrom(s => s.HitPoints))
            .ForMember(d => d.Ac, opt => opt.MapFrom(s => s.ArmorClass));
    }
}