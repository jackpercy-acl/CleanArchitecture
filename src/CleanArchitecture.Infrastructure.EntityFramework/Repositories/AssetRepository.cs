using CleanArchitecture.Application.Common.Abstractions.Data.Repositories;
using CleanArchitecture.Domain.Assets;

namespace CleanArchitecture.Infrastructure.EntityFramework.Repositories;

internal sealed class AssetRepository(ApplicationDbContext context) : BaseRepository<Asset>(context), IAssetRepository;