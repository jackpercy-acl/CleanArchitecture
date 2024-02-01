using CleanArchitecture.Application.Common.Abstractions.Commands;
using CleanArchitecture.Domain.Assets;

namespace CleanArchitecture.Application.Assets.UpdateAsset;

public record UpdateAssetCommand(
    int AssetId,
    string Name,
    string Postcode
) : ICommand<Asset>;