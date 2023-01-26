using Business.Entities;
using Business.Queries;

namespace Business.Services;

public interface IPokedexService
{
    Task<Guid?> AddPokemonAsync(Pokemon pokemon);

    Task UpdatePokemonAsync(Pokemon pokemon);

    Task DeletePokemonAsync(Guid pokemonId);

    Task<Pokemon?> GetByIdAsync(Guid pokemonId);

    Task<IEnumerable<Pokemon>> FindAsync(FindPokemonQuery query);
}
