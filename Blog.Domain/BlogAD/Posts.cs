using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.BlogAD
{
    public class Posts
    {
        public int Id { get; private set; }
        public string Picture { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public DateTime PostTime { get; private set; }
        public DateTime UpdatedTime { get; private set; }
        public bool IsAvailable { get; private set; }


        private Posts() { }


        public Posts(string picture, string title, string shortDescription, string description)
        {
            Picture = picture;
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            PostTime = DateTime.Now;
            UpdatedTime = DateTime.Now;
            IsAvailable = true;
        }
        public void Edit(string picture, string title, string shortDescription, string description, bool statusAvalable)
        {
                 if (picture != null)
            Picture = picture;
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            UpdatedTime = DateTime.Now;
            IsAvailable = statusAvalable;
        }
    }
}
