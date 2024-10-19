using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetDictionary.Domain.Entities;

namespace SweetDictionary.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("Users").HasKey(c => c.Id);
		builder.Property(c => c.Id).HasColumnName("Id");
		builder.Property(c => c.CreatedTime).HasColumnName("CreatedTime");
		builder.Property(c => c.UpdatedTime).HasColumnName("UpdatedTime");
		builder.Property(c => c.Username).HasColumnName("Username");
		builder.Property(c => c.FirstName).HasColumnName("Firstname");
		builder.Property(c => c.LastName).HasColumnName("Lastname");
		builder.Property(c => c.Email).HasColumnName("Email");
		builder.Property(c => c.Password).HasColumnName("Password");

		builder.HasMany(u => u.Posts)
			   .WithOne(p => p.Author)
			   .HasForeignKey(u => u.AuthorId)
			   .OnDelete(DeleteBehavior.Restrict);

		builder.HasMany(u => u.Comments)
			   .WithOne(c => c.User)
			   .HasForeignKey(u => u.UserId)
			   .OnDelete(DeleteBehavior.Cascade);

		//builder.Navigation(u => u.Posts).AutoInclude();
		//builder.Navigation(u => u.Comments).AutoInclude();
	}
}
