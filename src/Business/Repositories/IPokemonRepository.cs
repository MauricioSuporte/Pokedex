using Business.Entities;

namespace Business.Repositories;

public interface IPokemonRepository
{
    Task AddAsync(Pokemon pokemon);

    void Update(Pokemon pokemon);

    void Delete(Guid pokemonId);

    Task<bool> HasPokememonAsync(Guid pokemonId);

    Task<Pokemon> GetByIdAsync(Guid pokemonId);

    Task<Pokemon> GetByNameAsync(string name);

    Task<IEnumerable<Pokemon>> FindAsync();
}
