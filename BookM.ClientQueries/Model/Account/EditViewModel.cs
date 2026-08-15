namespace BookM.ClientQueries.Model.Account
{
    public class EditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string? Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Address { get; set; }
    }
}