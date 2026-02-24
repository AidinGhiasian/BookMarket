namespace AccountM.Application.Contracts.AccountApplication
{
    public class EditViewModel:CreateViewModel
    {
        public int Id { get; set; }
        public bool status { get; set; }
        public int RoleId { get; set; }
        public string? PictureName { get; set; }
    }
}
