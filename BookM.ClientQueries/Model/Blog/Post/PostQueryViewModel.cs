namespace BookM.ClientQueries.Model.Blog.Post
{
    public class PostQueryViewModel
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string PostTime { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; }
        public int categoryId { get; set; }
    }
}
