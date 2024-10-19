using Microsoft.EntityFrameworkCore;
using SweetDictionary.Domain.Entities;
using System.Reflection;

namespace SweetDictionary.Persistence.Contexts;

public class EfCoreDbContext : DbContext
{
    public EfCoreDbContext(DbContextOptions<EfCoreDbContext> options) : base(options)
    {
        
    }

	public DbSet<User> Users { get; set; }
	public DbSet<Post> Posts { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<Comment> Comments { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		SeedData(modelBuilder);
	}

	private void SeedData(ModelBuilder modelBuilder)
	{
		var categories = new List<Category>
		{
			new Category { Id = Guid.NewGuid(), Name = "Battles" },
			new Category { Id = Guid.NewGuid(), Name = "Stands" },
			new Category { Id = Guid.NewGuid(), Name = "Legacy" },
			new Category { Id = Guid.NewGuid(), Name = "Villains" },
			new Category { Id = Guid.NewGuid(), Name = "Memes" }
		};

		var users = new List<User>
		{
			new User { Id = Guid.NewGuid(), FirstName = "Joseph", LastName = "Joestar", Email = "joseph@jojo.com", Username = "joseph", Password = "hermitpurple" },
			new User { Id = Guid.NewGuid(), FirstName = "Jotaro", LastName = "Kujo", Email = "jotaro@jojo.com", Username = "jotaro", Password = "starplatinum" },
			new User { Id = Guid.NewGuid(), FirstName = "Dio", LastName = "Brando", Email = "dio@jojo.com", Username = "dio", Password = "zaWarudo" },
			new User { Id = Guid.NewGuid(), FirstName = "Giorno", LastName = "Giovanna", Email = "giorno@jojo.com", Username = "giorno", Password = "goldenwind" },
			new User { Id = Guid.NewGuid(), FirstName = "Josuke", LastName = "Higashikata", Email = "josuke@jojo.com", Username = "josuke", Password = "crazydiamond" },
			new User { Id = Guid.NewGuid(), FirstName = "Jonathan", LastName = "Joestar", Email = "jonathan@jojo.com", Username = "jonathan", Password = "sunlightyellow" },
			new User { Id = Guid.NewGuid(), FirstName = "Bruno", LastName = "Bucciarati", Email = "bruno@jojo.com", Username = "bruno", Password = "zippers" },
			new User { Id = Guid.NewGuid(), FirstName = "Rohan", LastName = "Kishibe", Email = "rohan@jojo.com", Username = "rohan", Password = "heaven'sdoor" },
			new User { Id = Guid.NewGuid(), FirstName = "Kakyoin", LastName = "Noriaki", Email = "kakyoin@jojo.com", Username = "kakyoin", Password = "cherryeater" },
			new User { Id = Guid.NewGuid(), FirstName = "Jean Pierre", LastName = "Polnareff", Email = "polnareff@jojo.com", Username = "polnareff", Password = "silverchariot" },
		};

		var posts = new List<Post>
		{
			new Post { Id = Guid.NewGuid(), Title = "It was me, Dio!", Content = "I, Dio, have returned!", AuthorId = users[2].Id, CategoryId = categories[3].Id },
			new Post { Id = Guid.NewGuid(), Title = "Oh? You're approaching me?", Content = "Jotaro approaches Dio with determination!", AuthorId = users[1].Id, CategoryId = categories[0].Id },
			new Post { Id = Guid.NewGuid(), Title = "Yare Yare Daze", Content = "Another day, another Stand user.", AuthorId = users[1].Id, CategoryId = categories[1].Id },
			new Post { Id = Guid.NewGuid(), Title = "Golden Experience Requiem!", Content = "Nothing can escape my Requiem.", AuthorId = users[3].Id, CategoryId = categories[2].Id },
			new Post { Id = Guid.NewGuid(), Title = "I reject my humanity!", Content = "Dio Brando casts off his humanity to become a vampire.", AuthorId = users[2].Id, CategoryId = categories[3].Id },
			new Post { Id = Guid.NewGuid(), Title = "ZAWARUDO!", Content = "Time has stopped. No one can move.", AuthorId = users[2].Id, CategoryId = categories[1].Id },
			new Post { Id = Guid.NewGuid(), Title = "ORA ORA ORA!", Content = "Jotaro unleashes a flurry of punches.", AuthorId = users[1].Id, CategoryId = categories[0].Id },
			new Post { Id = Guid.NewGuid(), Title = "MUDAMUDAMUDA!", Content = "Dio responds with his own barrage of attacks.", AuthorId = users[2].Id, CategoryId = categories[0].Id },
			new Post { Id = Guid.NewGuid(), Title = "Let's go, Koichi!", Content = "Josuke and Koichi are on another adventure.", AuthorId = users[4].Id, CategoryId = categories[2].Id },
			new Post { Id = Guid.NewGuid(), Title = "Silver Chariot!", Content = "Polnareff's Stand is unstoppable!", AuthorId = users[9].Id, CategoryId = categories[1].Id },
            new Post { Id = Guid.NewGuid(), Title = "Crazy Diamond!", Content = "Josuke's Stand has the power to heal!", AuthorId = users[4].Id, CategoryId = categories[1].Id },
			new Post { Id = Guid.NewGuid(), Title = "The Joestar bloodline", Content = "Jonathan reflects on his legacy.", AuthorId = users[5].Id, CategoryId = categories[2].Id },
			new Post { Id = Guid.NewGuid(), Title = "Muda vs Ora", Content = "The ultimate battle begins.", AuthorId = users[1].Id, CategoryId = categories[0].Id },
			new Post { Id = Guid.NewGuid(), Title = "Killer Queen", Content = "Rohan discusses the mysterious Kira.", AuthorId = users[7].Id, CategoryId = categories[3].Id },
			new Post { Id = Guid.NewGuid(), Title = "Cherry Eater", Content = "Kakyoin loves cherries!", AuthorId = users[8].Id, CategoryId = categories[4].Id },
			new Post { Id = Guid.NewGuid(), Title = "How many breads have you eaten?", Content = "Dio taunts Jonathan.", AuthorId = users[2].Id, CategoryId = categories[4].Id },
			new Post { Id = Guid.NewGuid(), Title = "Heaven's Door", Content = "Rohan uses his Stand to unlock secrets.", AuthorId = users[7].Id, CategoryId = categories[1].Id },
			new Post { Id = Guid.NewGuid(), Title = "Hand Licker", Content = "Josuke vs Okuyasu.", AuthorId = users[4].Id, CategoryId = categories[0].Id },
			new Post { Id = Guid.NewGuid(), Title = "Stone Ocean", Content = "The next chapter of the JoJo legacy.", AuthorId = users[0].Id, CategoryId = categories[2].Id },
			new Post { Id = Guid.NewGuid(), Title = "Stand Proud", Content = "The legacy continues with new Stand users.", AuthorId = users[6].Id, CategoryId = categories[2].Id },
		};

		var comments = new List<Comment>
		{
			new Comment { Id = Guid.NewGuid(), Text = "The World! Time stops now!", PostId = posts[0].Id, UserId = users[2].Id },
			new Comment { Id = Guid.NewGuid(), Text = "Yare yare daze...", PostId = posts[1].Id, UserId = users[1].Id },
			new Comment { Id = Guid.NewGuid(), Text = "MUDAMUDA!!", PostId = posts[7].Id, UserId = users[2].Id },
			new Comment { Id = Guid.NewGuid(), Text = "ORAORAORAORA!!", PostId = posts[6].Id, UserId = users[1].Id },
			new Comment { Id = Guid.NewGuid(), Text = "I, Dio, am eternal!", PostId = posts[4].Id, UserId = users[2].Id },
			new Comment { Id = Guid.NewGuid(), Text = "This is Requiem...", PostId = posts[3].Id, UserId = users[3].Id },
		};

		modelBuilder.Entity<Category>().HasData(categories);
		modelBuilder.Entity<User>().HasData(users);
		modelBuilder.Entity<Post>().HasData(posts);
		modelBuilder.Entity<Comment>().HasData(comments);
	}
}
