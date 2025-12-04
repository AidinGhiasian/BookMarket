using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentM.Domain.Comment.AD;
using Microsoft.EntityFrameworkCore;

namespace CommentM.Infrastructure.EFCore
{
    public class CommentDbContext:DbContext
    {
       public CommentDbContext(DbContextOptions<CommentDbContext> options) : base(options) { }
        public DbSet<Comments> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
