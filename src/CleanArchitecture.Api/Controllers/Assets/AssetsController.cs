using CleanArchitecture.Api.Contracts.Assets;
using CleanArchitecture.Application.Assets.CreateAsset;
using CleanArchitecture.Application.Assets.GetAsset;
using CleanArchitecture.Application.Assets.ListAssets;
using CleanArchitecture.Application.Assets.UpdateAsset;
using CleanArchitecture.Domain.Assets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers.Assets;

[Route("assets")]
public class AssetsController(IMediator mediator) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateAsset(CreateAssetRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateAssetCommand(request.GeneratorId, request.Name, request.Postcode);

        var result = await mediator.Send(command, cancellationToken);

        return result.Match(
            value => Ok(ToResponse(value)),
            Problem);
    }

    [HttpPut("{assetId:int}")]
    public async Task<IActionResult> UpdateAsset(int assetId, UpdateAssetRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateAssetCommand(assetId, request.Name, request.Postcode);

        var result = await mediator.Send(command, cancellationToken);

        return result.Match(
            value => Ok(ToResponse(value)),
            Problem);
    }

    [HttpGet("{assetId:int}")]
    public async Task<IActionResult> GetAsset([FromRoute]int assetId, CancellationToken cancellationToken)
    {
        var command = new GetAssetQuery(assetId);

        var result = await mediator.Send(command, cancellationToken);

        return result.Match(
            value => Ok(ToResponse(value)),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> ListAssets(CancellationToken cancellationToken)
    {
        var command = new ListAssetsQuery();

        var result = await mediator.Send(command, cancellationToken);

        return result.Match(
            value => Ok(value.Select(ToResponse)),
            Problem);
    }

    private static AssetResponse ToResponse(Asset asset) => new(
        asset.Id,
        asset.GeneratorId,
        asset.Name,
        asset.Postcode);
}