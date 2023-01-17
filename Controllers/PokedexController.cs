using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Business.Entities;

namespace Pokedex.Controllers;

[Route("pokedex")]
public class PokedexController : ControllerBase
{
    [HttpPost]
    [SwaggerOperation("Register new pokemon.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> AddPokemon()
    {
        return Ok();
    }

    [HttpPut]
    [SwaggerOperation("Actualize existing pokemon.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdatePokemon()
    {
        return Ok();
    }

    [HttpDelete]
    [SwaggerOperation("Delete existing pokemon.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeletePokemon()
    {
        return Ok();
    }

    [HttpGet("{pokemonId:guid}")]
    [SwaggerOperation("Get pokemon by Id.")]
    [ProducesResponseType(typeof(Pokemon), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPokemonById(Guid pokemonId)
    {
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
