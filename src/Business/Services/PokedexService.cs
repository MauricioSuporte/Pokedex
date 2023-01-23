using Business.Core.Notifications;
using Business.Entities;
using Business.Repositories;

namespace Business.Services;

public class PokedexService : IPokedexService
{
    private readonly INotifier _notifier;
    private readonly IPokemonRepository _pokemonRepository;

    public PokedexService(IPokemonRepository pokemonRepository, INotifier notifier)
    {
        _pokemonRepository = pokemonRepository;
        _notifier = notifier;
    }

    public async Task<Guid?> AddPokemonAsync(Pokemon pokemon)
    {
        var validation = pokemon.Validate();

        if (!validation.IsValid)
        {
            _notifier.Notify(validation);
            return null;
        }

        var registeredPokemon = await _pokemonRepository.GetByNameAsync(pokemon.Name);

        if (registeredPokemon != null)
        {
            _notifier.Notify("Já existe um pokemon com o mesmo nome");
            return null;
        }

        await _pokemonRepository.AddAsync(pokemon);

        return pokemon.Id;
    }

    public async Task DeletePokemonAsync(Guid pokemonId)
    {
        var hasPokemon = await _pokemonRepository.HasPokememonAsync(pokemonId);

        if (!hasPokemon)
        {
            _notifier.Notify("Não foi possivel encontrar o pokemon informado para deleta-lo.");
            return;
        }

        _pokemonRepository.Delete(pokemonId);
    }

    public async Task UpdatePokemonAsync(Pokemon pokemon)
    {
        var validation = pokemon.Validate();

        if (!validation.IsValid)
        {
            _notifier.Notify(validation);
            return;
        }

        var hasPokemon = await _pokemonRepository.HasPokememonAsync(pokemon.Id);

        if (!hasPokemon)
        {
            _notifier.Notify("Não foi possivel encontrar o pokemon informado.");
            return;
        }

        var registeredPokemon = await _pokemonRepository.GetByNameAsync(pokemon.Name);

        if (registeredPokemon != null && registeredPokemon.Id != pokemon.Id)
        {
            _notifier.Notify("Não é possível alterar o nome desse pokemon pois já existe um outro com o mesmo nome possivel encontrar o pokemon informado.");
            return;
        }

        _pokemonRepository.Update(pokemon);
    }
}
