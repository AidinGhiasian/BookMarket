namespace BookM.ClientQueries.Blog.Categores
{
    public class BlogCategoryQueryViewModel
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public string CreationDate { get; set; }
        public int? PostCount { get; set; }
    }

}
