using FluentValidation;

namespace CleanArchitecture.Application.Assets.UpdateAsset;

public class UpdateAssetValidator : AbstractValidator<UpdateAssetCommand>
{
    public UpdateAssetValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(30);

        RuleFor(x => x.Postcode)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(8);

        RuleFor(x => x.AssetId)
            .GreaterThan(0);
    }
}