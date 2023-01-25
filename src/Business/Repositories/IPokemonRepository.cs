using Business.Core;
using Business.Entities;
using Business.Queries;

namespace Business.Repositories;

public interface IPokemonRepository : IRepositoryBase
{
    Task AddAsync(Pokemon pokemon);

    void Update(Pokemon pokemon);

    void Delete(Guid pokemonId);

    Task<bool> HasPokememonAsync(Guid pokemonId);

    Task<Pokemon?> GetByIdAsync(Guid pokemonId);

    Task<Pokemon?> GetByNameAsync(string name);

    Task<IEnumerable<Pokemon>> FindAsync(FindPokemonQuery query);
}
