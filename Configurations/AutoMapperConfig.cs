using AutoMapper;
using Business.Entities;
using Pokedex.Models;

namespace Pokedex.Configurations;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<PokemonModel, Pokemon>().ReverseMap();
    }
}
