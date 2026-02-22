using Blog.Domain.BlogAD;
using Blog.Domain.BlogCategoryAD;
using BlogM.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Infrastructure.EFCore
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogCategoryMapping());
            modelBuilder.ApplyConfiguration(new PostsMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
}
