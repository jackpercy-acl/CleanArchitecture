using CleanArchitecture.Application.Common.Abstractions.Data.Repositories;
using CleanArchitecture.Application.Common.Abstractions.Queries;
using CleanArchitecture.Domain.Assets;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Assets.ListAssets;

internal sealed class ListAssetsQueryHandler(IAssetRepository assetRepository) : IQueryHandler<ListAssetsQuery, ICollection<Asset>>
{
    public async Task<ErrorOr<ICollection<Asset>>> Handle(ListAssetsQuery request, CancellationToken cancellationToken)
    {
        var assets = await assetRepository.GetAll().ToArrayAsync(cancellationToken);

        return assets;
    }
}