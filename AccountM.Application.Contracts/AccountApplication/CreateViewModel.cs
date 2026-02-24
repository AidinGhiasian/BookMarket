using Microsoft.AspNetCore.Http;

namespace AccountM.Application.Contracts.AccountApplication
{
    public class CreateViewModel
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Addres { get; set; }
        public string Password { get; set; }
        public IFormFile FilePicture { get; set; }

    }
}
