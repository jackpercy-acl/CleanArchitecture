using CleanArchitecture.Application.Common.Abstractions.Commands;
using CleanArchitecture.Application.Common.Abstractions.Data.Repositories;
using CleanArchitecture.Domain.Assets;
using CleanArchitecture.Domain.Generators;
using ErrorOr;

namespace CleanArchitecture.Application.Assets.CreateAsset;

internal sealed class CreateAssetCommandHandler(
    IAssetRepository assetRepository,
    IGeneratorRepository generatorRepository
    ) : ICommandHandler<CreateAssetCommand, Asset>
{
    public async Task<ErrorOr<Asset>> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
    {
        var generator = await generatorRepository.GetByIdAsync(request.GeneratorId);
        if (generator is null)
        {
            return GeneratorErrors.NotFound;
        }

        var asset = new Asset
        {
            Name = request.Name,
            Postcode = request.Postcode,
            GeneratorId = request.GeneratorId 
        };

        await assetRepository.AddAsync(asset);

        await assetRepository.SaveChangesAsync(cancellationToken);

        return asset;
    }
}