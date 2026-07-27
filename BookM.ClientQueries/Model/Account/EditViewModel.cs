namespace BookM.ClientQueries.Model.Account
{
    public class EditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Addres { get; set; }
        public bool status { get; set; }
        public string PhoneNumber { get; set; }
        public string PictureName { get; set; }
        public int RoleId { get; set; }
    }
}
