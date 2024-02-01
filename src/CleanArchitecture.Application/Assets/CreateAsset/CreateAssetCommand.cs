using CleanArchitecture.Application.Common.Abstractions.Commands;
using CleanArchitecture.Domain.Assets;

namespace CleanArchitecture.Application.Assets.CreateAsset;

public record CreateAssetCommand(
    int GeneratorId,
    string Name,
    string Postcode
    ) : ICommand<Asset>;