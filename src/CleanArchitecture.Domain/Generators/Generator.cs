using CleanArchitecture.Domain.Assets;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Generators;

public class Generator : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<Asset> Assets { get; } = new List<Asset>();
}