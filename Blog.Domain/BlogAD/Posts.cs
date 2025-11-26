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
        public string BookTitle { get; private set; }
        public string Writer { get; private set; }
        public string Publisher { get; private set; }
        public string Description { get; private set; }
        public int CategoryId { get; private set; }
        public DateTime PostTime { get; private set; }
        public DateTime UpdatedTime { get; private set; }
        public bool IsAvailable { get; private set; }


        public Posts(string picture, string booktitle, string writer, string publisher, string description, int categoryid)
        {
            Picture = picture;
            BookTitle = booktitle;
            Writer = writer;
            Publisher = publisher;
            Description = description;
            CategoryId = categoryid;
            PostTime = DateTime.Now;
            UpdatedTime = DateTime.Now;
            IsAvailable = true;
        }
        public void Edit(string picture, string booktitle, string writer, string publisher, string description, int categoryid, bool statusavalable)
        {
            if (picture != null)
            Picture = picture;
            BookTitle = booktitle;
            Writer = writer;
            Publisher = publisher;
            Description = description;
            CategoryId = categoryid;
            UpdatedTime = DateTime.Now;
            IsAvailable = statusavalable;
        }
    }
}
