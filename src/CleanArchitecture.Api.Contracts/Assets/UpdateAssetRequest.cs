namespace CleanArchitecture.Api.Contracts.Assets;

public record UpdateAssetRequest(
    string Name,
    string Postcode);