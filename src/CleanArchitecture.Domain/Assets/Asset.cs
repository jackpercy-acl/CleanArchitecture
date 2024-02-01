using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Generators;

namespace CleanArchitecture.Domain.Assets;

public class Asset : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Postcode { get; set; } = null!;

    public int GeneratorId { get; set; }

    public Generator Generator { get; set; } = null!;
}