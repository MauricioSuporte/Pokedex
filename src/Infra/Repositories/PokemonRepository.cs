﻿using Business.Entities;
using Business.Repositories;

namespace Infra.Repositories;

public class PokemonRepository : IPokemonRepository
{
    public Task AddAsync(Pokemon pokemon)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid pokemonId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Pokemon>> FindAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Pokemon> GetByIdAsync(Guid pokemonId)
    {
        throw new NotImplementedException();
    }

    public Task<Pokemon> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<bool> HasPokememonAsync(Guid pokemonId)
    {
        throw new NotImplementedException();
    }

    public void Update(Pokemon pokemon)
    {
        throw new NotImplementedException();
    }
}
