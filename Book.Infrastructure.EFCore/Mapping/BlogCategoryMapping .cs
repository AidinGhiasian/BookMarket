using Blog.Domain.BlogCategoryAD;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogM.Infrastructure.EFCore.Mapping
{
    public class BlogCategoryMapping : IEntityTypeConfiguration<BlogCategory>
    {
        public void Configure(EntityTypeBuilder<BlogCategory> builder)
        {
            builder.ToTable("BlogCategories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.Picture)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(x => x.Slug)
                   .IsRequired()
                   .HasMaxLength(300);

            builder.Property(x => x.Description)
                   .HasMaxLength(1000);

            builder.Property(x => x.CreationDate)
                   .IsRequired();

            builder.Property(x => x.UpdatedDate)
                   .IsRequired();

            builder.Property(x => x.IsAvailable)
                   .IsRequired();

            // رابطه یک به چند با Posts
            builder.HasMany(x => x.Posts)
                   .WithOne(x => x.BlogCategory)
                   .HasForeignKey(x => x.BlogCategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

