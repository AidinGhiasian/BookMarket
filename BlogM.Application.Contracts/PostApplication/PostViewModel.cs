using System;

namespace BlogM.Application.Contracts.PostApplication
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string? Picture { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string PostTime { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string? Category { get; set; }
        public int BlogCategoryId { get; set; }
    }
}
