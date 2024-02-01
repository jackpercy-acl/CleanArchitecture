using FluentValidation;

namespace CleanArchitecture.Application.Assets.CreateAsset;

public class CreateAssetValidator : AbstractValidator<CreateAssetCommand>
{
    public CreateAssetValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(30);

        RuleFor(x => x.Postcode)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(8);

        RuleFor(x => x.GeneratorId)
            .GreaterThan(0);
    }
}