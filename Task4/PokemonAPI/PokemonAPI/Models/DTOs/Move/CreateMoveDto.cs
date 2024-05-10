using AutoMapper;
using PokemonAPI.Common.Mappings;

namespace PokemonAPI.Models.DTOs.Move;

using Move = DAL.Entities.Move;

public class CreateMoveDto : IMapWith<Move>
{
    public int PokemonId { get; set; }
    
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateMoveDto, Move>()
            .ForMember(x => x.MoveName,
                opt =>
                    opt.MapFrom(y => y.Name))
            .ForMember(x => x.PokemonId,
                opt =>
                    opt.MapFrom(y => y.PokemonId));
    }
}