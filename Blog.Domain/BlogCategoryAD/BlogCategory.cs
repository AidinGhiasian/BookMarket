using Blog.Domain.BlogAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.BlogCategoryAD
{

    public class BlogCategory
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Picture { get; private set; }
        public string Slug { get; private set; }
        public string Description { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }
        public bool IsAvailable { get; private set; }

        public List<Posts> Posts { get; private set; }


        // برای EF
        private BlogCategory() { }

        public BlogCategory(string name, string picture, string slug, string description)
        {
            Name = name;
            Picture = picture;
            Slug = slug;
            Description = description;
            CreationDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            IsAvailable = true;
        }

        public void Edit(string name, string picture, string slug, string description, bool statusAvailable)
        {
            Name = name;
            if (Picture != null)
                Slug = slug;
            Description = description;
            UpdatedDate = DateTime.Now;
            IsAvailable = statusAvailable;
        }
    }


}
