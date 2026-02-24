using System.Collections.Generic;

namespace Services.Application.AuthHelper
{
    public class AuthViewModel
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string Role { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }

        public string? Address { get; set; }
        public List<int> Permissions { get; set; }
        public string ProfilePicture { get; set; }

        public bool IsActiv { get; set; }

        public AuthViewModel()
        {
        }

        public AuthViewModel(long id, long roleId, string fullname, string username, string phone,
            List<int> permissions, string profilePicture, string address, bool isActiv)
        {
            Id = id;
            RoleId = roleId;
            Fullname = fullname;
            Username = username;
            Phone = phone;
            Permissions = permissions;
            ProfilePicture = profilePicture;
            Address = address;

            IsActiv = isActiv;
        }
    }
}