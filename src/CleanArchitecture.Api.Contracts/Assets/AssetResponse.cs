namespace CleanArchitecture.Api.Contracts.Assets;

public record AssetResponse(
    int Id,
    int GeneratorId,
    string Name,
    string Postcode);