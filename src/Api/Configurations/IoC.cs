using Business.Repositories;
using Business.Services;
using Infra.Repositories;

namespace Pokedex.Configurations;

public static class IoC
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPokedexService, PokedexService>();
        return services;
    }
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPokemonRepository, PokemonRepository>();
        return services;
    }
}
