using AutoMapper;
using Business.Entities;
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

    public PokedexController(
        IPokedexService pokedexService,
        IMapper mapper)
    {
        _pokedexService = pokedexService;
        _mapper = mapper;
    }

    [HttpPost]
    [SwaggerOperation("Register new pokemon.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
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
        await _pokedexService.GetPokemonAsync(pokemonId);

        return Ok();
    }

    [HttpGet("find")]
    [SwaggerOperation("Find pokemons.")]
    [ProducesResponseType(typeof(IEnumerable<Pokemon>), StatusCodes.Status200OK)]
    public async Task<IActionResult> FindPokemon()
    {
        return Ok();
    }
}
