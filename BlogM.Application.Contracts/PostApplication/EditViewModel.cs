

namespace BlogM.Application.Contracts.PostApplication
{
    public class EditViewModel:CreateViewModel
    {


        public int Id { get; set; }
        public bool IsAvailable { get;  set; }
        public string Picture { get; set; }
    }
}
