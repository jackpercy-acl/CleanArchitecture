using CleanArchitecture.Application.Common.Abstractions.Data.Repositories;
using CleanArchitecture.Domain.Generators;

namespace CleanArchitecture.Infrastructure.EntityFramework.Repositories;

internal sealed class GeneratorRepository(ApplicationDbContext context) : BaseRepository<Generator>(context), IGeneratorRepository;