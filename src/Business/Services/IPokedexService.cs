using Business.Entities;

namespace Business.Services;

public interface IPokedexService
{
    Task<Guid?> AddPokemonAsync(Pokemon pokemon);

    Task UpdatePokemonAsync(Pokemon pokemon);

    Task DeletePokemonAsync(Guid pokemonId);
}
