using Business.Entities;
using FluentValidation;

namespace Business.Validations;

internal class PokemonValidation : AbstractValidator<Pokemon>
{
    public PokemonValidation()
    {
        RuleFor(p => p.Name)
            .Length(3, 50)
            .WithMessage("The name of pokemon mus be between {MinLength} and {MaxLength} caracteres.");

        RuleFor(p => p.CategoryId)
            .NotEmpty()
            .WithMessage("Category must be a valid value.");

        RuleFor(p => p.Hp)
            .GreaterThan(0)
            .WithMessage("The Hp must be greater than zero.");

        RuleFor(p => p.Attack)
            .GreaterThan(0)
            .WithMessage("The Attack must be greater than zero.");

        RuleFor(p => p.Defense)
            .GreaterThan(0)
            .WithMessage("The Defense must be greater than zero.");

        RuleFor(p => p.Speed)
            .GreaterThan(0)
            .WithMessage("The Speed must be greater than zero.");
    }
}
