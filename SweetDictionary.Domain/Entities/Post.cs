using Core.Entities;

namespace SweetDictionary.Domain.Entities;

public sealed class Post : Entity<Guid>
{
    public string Title { get; set; }
    public string Content { get; set; }

    public Guid AuthorId { get; set; }
    public User Author { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public List<Comment> Comments { get; set; }
}
