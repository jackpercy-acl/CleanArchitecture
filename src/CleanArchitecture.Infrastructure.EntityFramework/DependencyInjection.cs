using CleanArchitecture.Application.Common.Abstractions.Data;
using CleanArchitecture.Application.Common.Abstractions.Data.Repositories;
using CleanArchitecture.Infrastructure.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.EntityFramework;

public static class DependencyInjection
{
    public static IServiceCollection AddEntityFramework(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("ApplicationDbContext"),
                builder => builder.EnableRetryOnFailure()));

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAssetRepository, AssetRepository>();
        services.AddScoped<IGeneratorRepository, GeneratorRepository>();

        return services;
    }
}