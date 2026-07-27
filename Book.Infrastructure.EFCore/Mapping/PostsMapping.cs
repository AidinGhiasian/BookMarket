using Blog.Domain.BlogAD;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Infrastructure.EFCore.Mapping
{
    public class PostsMapping: IEntityTypeConfiguration<Posts>
    {
        public void Configure(EntityTypeBuilder<Posts> builder)
        {
            builder.ToTable("Posts"); // نام جدول

            builder.HasKey(x => x.Id); // کلید اصلی

            // تنظیمات ستون‌ها
            builder.Property(x => x.Picture)
                   .IsRequired(false)
                   .HasMaxLength(500);

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.ShortDescription)
                   .HasMaxLength(1000);

            builder.Property(x => x.Description)
                   .HasMaxLength(int.MaxValue);

            builder.Property(x => x.PostTime)
                   .IsRequired();

            builder.Property(x => x.UpdatedTime)
                   .IsRequired();

            builder.Property(x => x.IsAvailable)
                   .IsRequired();

            // تنظیم رابطه با BlogCategory (Many-to-One)
            builder.HasOne(x => x.BlogCategory)
                   .WithMany(c => c.Posts)
                   .HasForeignKey(x => x.BlogCategoryId)
                   .OnDelete(DeleteBehavior.Cascade); // حذف cascade

            // برای lazy loading (در صورت نیاز)
            builder.Navigation(x => x.BlogCategory).AutoInclude();
        }
    }
}
