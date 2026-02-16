namespace BlogM.Application.Contacts.BlogCategoryApplication
{
    public class EditBlogCategoryViewModel : CreateBlogCategoryViewModel
    {
        public int Id { get; set; }
        public string PictureName { get; set; }
        public bool IsAvailable { get; set; }
    }

}
