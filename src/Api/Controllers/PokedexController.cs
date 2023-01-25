using AutoMapper;
using Business.Core.Notifications;
using Business.Entities;
using Business.Queries;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Pokedex.Controllers;

[Route("pokedex")]
public class PokedexController : ControllerBase
{
    private readonly IPokedexService _pokedexService;
    private readonly IMapper _mapper;
    private readonly INotifier _notifier;

    public PokedexController(
        IPokedexService pokedexService,
        IMapper mapper,
        INotifier notifier)
    {
        _pokedexService = pokedexService;
        _mapper = mapper;
        _notifier = notifier;
    }

    [HttpPost]
    [SwaggerOperation("Register new pokemon.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IEnumerable<Notification>), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> AddPokemon([FromBody] PokemonModel model)
    {
        var pokemon = _mapper.Map<Pokemon>(model);

        var pokemonById = await _pokedexService.AddPokemonAsync(pokemon);

        return Created($"{HttpContext.Request.Path}/{pokemonById}", null);
    }

    [HttpPut]
    [SwaggerOperation("Actualize existing pokemon.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdatePokemon([FromBody] PokemonModel model)
    {
        var pokemon = _mapper.Map<Pokemon>(model);

        await _pokedexService.UpdatePokemonAsync(pokemon);

        return NoContent();
    }

    [HttpDelete("{pokemonId:guid}")]
    [SwaggerOperation("Delete existing pokemon.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeletePokemon(Guid pokemonId)
    {
        await _pokedexService.DeletePokemonAsync(pokemonId);

        return NoContent();
    }

    [HttpGet("{pokemonId:guid}")]
    [SwaggerOperation("Get pokemon by Id.")]
    [ProducesResponseType(typeof(Pokemon), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPokemonById(Guid pokemonId)
    {
        return Ok(new Pokemon("", Guid.NewGuid(), Business.Enums.Gender.All, 1, 1, 1, 1));
    }

    [HttpGet("find")]
    [SwaggerOperation("Find pokemons.")]
    [ProducesResponseType(typeof(IEnumerable<Pokemon>), StatusCodes.Status200OK)]
    public async Task<IActionResult> FindPokemon([FromQuery] FindPokemonQuery query)
    {
        var pokemons =  await _pokedexService.FindAsync(query);

        HttpContext.Response.Headers.Add("X-Total-Count", pokemons.Count().ToString());

        var result = _mapper.Map<IEnumerable<PokemonModel>>(pokemons);
        return Ok(result);
    }
}
