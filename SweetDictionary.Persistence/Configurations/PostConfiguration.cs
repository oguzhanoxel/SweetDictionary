using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetDictionary.Domain.Entities;

namespace SweetDictionary.Persistence.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
	public void Configure(EntityTypeBuilder<Post> builder)
	{
		builder.ToTable("Posts").HasKey(c => c.Id);
		builder.Property(c => c.Id).HasColumnName("Id");
		builder.Property(c => c.CreatedTime).HasColumnName("CreatedTime");
		builder.Property(c => c.UpdatedTime).HasColumnName("UpdatedTime");
		builder.Property(c => c.Title).HasColumnName("Title");
		builder.Property(c => c.Content).HasColumnName("Content");
		builder.Property(c => c.AuthorId).HasColumnName("AuthorId");
		builder.Property(c => c.CategoryId).HasColumnName("CategoryId");

		builder.HasOne(p => p.Category)
			   .WithMany(c => c.Posts)
			   .HasForeignKey(p => p.CategoryId)
			   .OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(p => p.Author)
			   .WithMany(a => a.Posts)
			   .HasForeignKey(p => p.AuthorId)
			   .OnDelete(DeleteBehavior.Restrict);

		builder.HasMany(p => p.Comments)
			   .WithOne(c => c.Post)
			   .HasForeignKey(p => p.PostId)
			   .OnDelete(DeleteBehavior.Cascade);

		builder.Navigation(p => p.Author).AutoInclude();
		builder.Navigation(p => p.Category).AutoInclude();
		builder.Navigation(p => p.Comments).AutoInclude();
	}
}
