namespace BlogM.Application.Contracts.BlogCategoryApplication
{
    public class BlogCategoryViewModel
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public string CreationDate { get; set; }
    }

}
