using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetDictionary.Domain.Entities;

namespace SweetDictionary.Persistence.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
	public void Configure(EntityTypeBuilder<Comment> builder)
	{
		builder.ToTable("Comments").HasKey(c => c.Id);
		builder.Property(c => c.Id).HasColumnName("Id");
		builder.Property(c => c.CreatedTime).HasColumnName("CreatedTime");
		builder.Property(c => c.UpdatedTime).HasColumnName("UpdatedTime");
		builder.Property(c => c.Text).HasColumnName("Text");
		builder.Property(c => c.UserId).HasColumnName("UserId");
		builder.Property(c => c.PostId).HasColumnName("PostId");

		builder.HasOne(c => c.Post)
			   .WithMany(p => p.Comments)
			   .HasForeignKey(c => c.PostId)
			   .OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(c => c.User)
			   .WithMany(u => u.Comments)
			   .HasForeignKey(c => c.UserId)
			   .OnDelete(DeleteBehavior.Restrict);

		builder.Navigation(c => c.Post).AutoInclude();
		builder.Navigation(c => c.User).AutoInclude();
	}
}
