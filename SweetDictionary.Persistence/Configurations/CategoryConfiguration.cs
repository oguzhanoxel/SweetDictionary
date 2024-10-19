using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetDictionary.Domain.Entities;

namespace SweetDictionary.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.ToTable("Categories");

		builder.HasKey(c => c.Id);

		builder.ToTable("Categories").HasKey(c => c.Id);
		builder.Property(c => c.Id).HasColumnName("Id");
		builder.Property(c => c.Name).HasColumnName("Name");
		builder.Property(c => c.CreatedTime).HasColumnName("CreatedTime");
		builder.Property(c => c.UpdatedTime).HasColumnName("UpdatedTime");

		builder.HasMany(c => c.Posts)
			   .WithOne(p => p.Category)
			   .HasForeignKey(c => c.CategoryId)
			   .OnDelete(DeleteBehavior.Cascade);

		//builder.Navigation(c => c.Posts).AutoInclude();
	}
}
