using CleanArchitecture.Application.Common.Abstractions.Queries;
using CleanArchitecture.Domain.Assets;

namespace CleanArchitecture.Application.Assets.ListAssets;

public record ListAssetsQuery : IQuery<ICollection<Asset>>;