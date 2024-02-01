using ErrorOr;

namespace CleanArchitecture.Domain.Assets;

public static class AssetErrors
{
    public static Error NotFound { get; } = Error.NotFound(
        code: "Asset.NotFound",
        description: "The asset could not be found");
}