using AutoMapper;
using PokemonAPI.Common.Mappings;

namespace PokemonAPI.Models.DTOs.Ability;

using Ability = DAL.Entities.Ability;

public class UpdateAbilityDto : IMapWith<Ability>
{
    public int PokemonId { get; set; }
    
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateAbilityDto, Ability>()
            .ForMember(x => x.PokemonId,
                opt =>
                    opt.MapFrom(y => y.PokemonId))
            .ForMember(x => x.AbilityName,
                opt =>
                    opt.MapFrom(y => y.Name));
    }
}