using CleanArchitecture.Application.Common.Abstractions.Commands;
using CleanArchitecture.Application.Common.Abstractions.Data.Repositories;
using CleanArchitecture.Domain.Assets;
using ErrorOr;

namespace CleanArchitecture.Application.Assets.UpdateAsset;

internal sealed class UpdateAssetCommandHandler(
    IAssetRepository assetRepository
    ) : ICommandHandler<UpdateAssetCommand, Asset>
{
    public async Task<ErrorOr<Asset>> Handle(UpdateAssetCommand request, CancellationToken cancellationToken)
    {
        var asset = await assetRepository.GetByIdAsync(request.AssetId);
        if (asset is null)
        {
            return AssetErrors.NotFound;
        }

        asset.Name = request.Name;
        asset.Postcode = request.Postcode;

        await assetRepository.SaveChangesAsync(cancellationToken);

        return asset;
    }
}