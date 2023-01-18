using Business.Enums;

namespace Pokedex.Models;

public class PokemonModel
{
    public string Name { get; private set; }

    public Guid CategoryId { get; private set; }

    public Gender Gender { get; private set; }

    public int Hp { get; private set; }

    public int Attack { get; private set; }

    public int Defense { get; private set; }

    public int Speed { get; private set; }
}
