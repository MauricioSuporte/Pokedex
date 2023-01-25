using Business.Entities;
using Business.Queries;
using Business.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private readonly EFDbContext _efContext;

    public PokemonRepository(EFDbContext efContext)
    {
        _efContext = efContext;
    }

    public async Task AddAsync(Pokemon pokemon)
    {
        await _efContext.Pokemons.AddAsync(pokemon);
    }

    public void Delete(Guid pokemonId)
    {
        _efContext.Pokemons
            .Where(p => p.Id == pokemonId)
            .ExecuteDelete();
    }

    public Task<Pokemon?> GetByIdAsync(Guid pokemonId)
    {
        return _efContext.Pokemons
            .FirstOrDefaultAsync(p => p.Id == pokemonId);
    }

    public Task<Pokemon?> GetByNameAsync(string name)
    {
        return _efContext.Pokemons
            .FirstOrDefaultAsync(p => p.Name == name);
    }

    public Task<bool> HasPokememonAsync(Guid pokemonId)
    {
        return _efContext.Pokemons
            .AnyAsync(p => p.Id == pokemonId);
    }

    public void Update(Pokemon pokemon)
    {
        _efContext.Pokemons.Update(pokemon);
    }

    public async Task<IEnumerable<Pokemon>> FindAsync(FindPokemonQuery query)
    {
        var findQuery = _efContext.Pokemons.AsQueryable();

        if (query.HasName)
            findQuery = findQuery.Where(p => p.Name == query.Name);

        if (query.HasCategory)
            findQuery = findQuery.Where(p => p.CategoryId == query.CategoryId);

        return await findQuery.ToListAsync();
    }

    public Task CommitAsync()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
