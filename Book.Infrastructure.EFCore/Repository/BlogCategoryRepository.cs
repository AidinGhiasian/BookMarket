using Blog.Domain.BlogCategoryAD;
using Book.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Services.Application;

namespace Book.Infrastructure.EFCore.Repository
{
    public class BlogCategoryRepository : RepositoryBase<BlogCategory>, IBlogCategoryRepository
    {
        private readonly BlogDbContext _context;

        public BlogCategoryRepository(BlogDbContext context) : base(context)
        {
            _context = context;
        }

        public void Create(BlogCategory category)
        {
            _context.BlogCategories.Add(category);
            _context.SaveChanges();
        }

        public BlogCategory? GetByName(string name)
        {
            return _context.BlogCategories.FirstOrDefault(x => x.Name == name);
        }

        public BlogCategory? GetBySlug(string slug)
        {
            return _context.BlogCategories.FirstOrDefault(x => x.Slug == slug);
        }

        public List<BlogCategory> GetAvailableCategories()
        {
            return _context.BlogCategories.Where(x => x.IsAvailable).ToList();
        }

        public List<BlogCategory> GetPostWithCategories()
        {
            return _context.BlogCategories.Include(x => x.Posts)
                                          .Where(x => x.IsAvailable)
                                          .ToList();
        }

        public BlogCategory? GetWithPostsBySlug(string slug)
        {
            return _context.BlogCategories.Include(x => x.Posts)
                                          .FirstOrDefault(x => x.Slug == slug);
        }

        public bool Exists(string name)
        {
            return _context.BlogCategories.Any(x => x.Name == name);
        }

        // NOTE: GetPostsWithCategory method removed because it was always
        // throwing InvalidCastException (casting IQueryable<BlogCategory> to BlogCategory).
        // Use GetPostWithCategories() instead.
    }
}

