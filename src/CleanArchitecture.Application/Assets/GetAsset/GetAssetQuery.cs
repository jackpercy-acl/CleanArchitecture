using CleanArchitecture.Application.Common.Abstractions.Queries;
using CleanArchitecture.Domain.Assets;

namespace CleanArchitecture.Application.Assets.GetAsset;

public record GetAssetQuery(int Id) : IQuery<Asset>;