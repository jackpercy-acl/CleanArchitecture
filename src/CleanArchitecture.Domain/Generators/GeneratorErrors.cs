using ErrorOr;

namespace CleanArchitecture.Domain.Generators;

public static class GeneratorErrors
{
    public static Error NotFound { get; } = Error.NotFound(
        code: "Generator.NotFound",
        description: "The generator could not be found");
}