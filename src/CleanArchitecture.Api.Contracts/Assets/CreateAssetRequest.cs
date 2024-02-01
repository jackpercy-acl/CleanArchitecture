namespace CleanArchitecture.Api.Contracts.Assets;

public record CreateAssetRequest(
    int GeneratorId,
    string Name,
    string Postcode);