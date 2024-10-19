using Core.Entities;

namespace SweetDictionary.Domain.Entities;

public sealed class User : Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public List<Post> Posts { get; set; }
    public List<Comment> Comments { get; set; }
}