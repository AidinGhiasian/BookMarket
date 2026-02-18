using Blog.Domain.BlogCategoryAD;
using Book.Infrastructure.EFCore;
using DocumentFormat.OpenXml.Office2010.Excel;
using Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogM.Infrastructure.EFCore.Repository
{
    public class BlogCategoryRepository : RepositoryBase<BlogCategory>, IBlogCategoryRepository
    {
        private readonly BlogDbContext _context;

        public BlogCategoryRepository(BlogDbContext context):base(context)
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
            return _context.BlogCategories
                           .FirstOrDefault(x => x.Name == name);
        }

        public BlogCategory? GetBySlug(string slug)
        {
            return _context.BlogCategories
                           .FirstOrDefault(x => x.Slug == slug);
        }

       
        public void Update(BlogCategory category)
        {
            _context.BlogCategories.Update(category);
            _context.SaveChanges();
        }

        public void Delete(BlogCategory category)
        {
           
                _context.BlogCategories.Remove(category);
                _context.SaveChanges();
        }

        public List<BlogCategory> GetAvailableCategories()
        {
            return _context.BlogCategories
                           .Where(x => x.IsAvailable)
                           .ToList();
        }

     

        public BlogCategory? GetWithPostsBySlug(string slug)
        {
            return _context.BlogCategories.FirstOrDefault(x => x.Slug == slug);
        }

        public bool Exists(string name)
        {
            return _context.BlogCategories.Where(x=>x.Name == name).Any();
        }

       
    }
}
