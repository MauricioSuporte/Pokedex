using FluentValidation.Results;

namespace Business.Core;

public abstract class Entity
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public virtual ValidationResult Validate()
    {
        throw new NotImplementedException("Override the validate method with valid conditions");
    }
}
