using Core.Entities;

namespace SweetDictionary.Domain.Entities;

public sealed class Category : Entity<Guid>
{
    public string Name { get; set; }
    public List<Post> Posts { get; set; }
}
