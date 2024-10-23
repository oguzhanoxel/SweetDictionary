using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SweetDictionary.Domain.Entities;
using System.Reflection;

namespace SweetDictionary.Persistence.Contexts;

public class EfCoreDbContext : IdentityDbContext
{
    public EfCoreDbContext(DbContextOptions<EfCoreDbContext> options) : base(options)
    {
        
    }

	public DbSet<Post> Posts { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<Comment> Comments { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		SeedData(modelBuilder);
	}

	private void SeedData(ModelBuilder modelBuilder)
	{
		var passwordHasher = new PasswordHasher<User>();

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
			new User { Id = Guid.NewGuid().ToString(), FirstName = "Joseph", LastName = "Joestar", Email = "joseph@jojo.com", UserName = "joseph" },
			new User { Id = Guid.NewGuid().ToString(), FirstName = "Jotaro", LastName = "Kujo", Email = "jotaro@jojo.com", UserName = "jotaro" },
			new User { Id = Guid.NewGuid().ToString(), FirstName = "Dio", LastName = "Brando", Email = "dio@jojo.com", UserName = "dio" },
			new User { Id = Guid.NewGuid().ToString(), FirstName = "Giorno", LastName = "Giovanna", Email = "giorno@jojo.com", UserName = "giorno" },
			new User { Id = Guid.NewGuid().ToString(), FirstName = "Josuke", LastName = "Higashikata", Email = "josuke@jojo.com", UserName = "josuke" },
			new User { Id = Guid.NewGuid().ToString(), FirstName = "Jonathan", LastName = "Joestar", Email = "jonathan@jojo.com", UserName = "jonathan" },
			new User { Id = Guid.NewGuid().ToString(), FirstName = "Bruno", LastName = "Bucciarati", Email = "bruno@jojo.com", UserName = "bruno" },
			new User { Id = Guid.NewGuid().ToString(), FirstName = "Rohan", LastName = "Kishibe", Email = "rohan@jojo.com", UserName = "rohan" },
			new User { Id = Guid.NewGuid().ToString(), FirstName = "Kakyoin", LastName = "Noriaki", Email = "kakyoin@jojo.com", UserName = "kakyoin" },
			new User { Id = Guid.NewGuid().ToString(), FirstName = "Jean Pierre", LastName = "Polnareff", Email = "polnareff@jojo.com", UserName = "polnareff" },
		};

		users[0].PasswordHash = passwordHasher.HashPassword(users[0], "hermitpurple");
		users[1].PasswordHash = passwordHasher.HashPassword(users[1], "starplatinum");
		users[2].PasswordHash = passwordHasher.HashPassword(users[2], "zaWarudo");
		users[3].PasswordHash = passwordHasher.HashPassword(users[3], "goldenwind");
		users[4].PasswordHash = passwordHasher.HashPassword(users[4], "crazydiamond");
		users[5].PasswordHash = passwordHasher.HashPassword(users[5], "sunlightyellow");
		users[6].PasswordHash = passwordHasher.HashPassword(users[6], "zippers");
		users[7].PasswordHash = passwordHasher.HashPassword(users[7], "heaven'sdoor");
		users[8].PasswordHash = passwordHasher.HashPassword(users[8], "cherryeater");
		users[9].PasswordHash = passwordHasher.HashPassword(users[9], "silverchariot");

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
