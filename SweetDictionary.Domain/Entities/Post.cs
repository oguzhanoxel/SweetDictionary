using Core.Entities;

namespace SweetDictionary.Domain.Entities;

public sealed class Post : Entity<Guid>
{
    public string Title { get; set; }
    public string Content { get; set; }
}
