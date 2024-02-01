using CleanArchitecture.Application.Common.Abstractions.Data.Repositories;
using CleanArchitecture.Application.Common.Abstractions.Queries;
using CleanArchitecture.Domain.Assets;
using ErrorOr;

namespace CleanArchitecture.Application.Assets.GetAsset;

public class GetAssetQueryHandler(IAssetRepository assetRepository) : IQueryHandler<GetAssetQuery, Asset>
{
    public async Task<ErrorOr<Asset>> Handle(GetAssetQuery request, CancellationToken cancellationToken)
    {
        var asset = await assetRepository.GetByIdAsync(request.Id, cancellationToken);
        if (asset is null)
        {
            return AssetErrors.NotFound;
        }

        return asset;
    }
}