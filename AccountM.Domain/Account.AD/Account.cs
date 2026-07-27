using AccountManagement.Domain.RoleAgg;
using System.ComponentModel.DataAnnotations;

namespace AM.Domain.Account.AD
{
    public class Account
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreationDate { get; private set; } = DateTime.Now;
        public string Addres { get; private set; }
        public string Scuritycode { get; private set; }
        public string Password { get; private set; }
        public bool IsAvalable { get; private set; }
        public int RoleId { get; private set; }
        public string? Picture { get; private set; }
        public Role? Role { get; private set; }

        private Account() { }

        public Account(string name, string family, string phoneNumber, string email,
            DateTime birthDate, string addres, string password, int roleId, string? picture)
        {
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            BirthDate = birthDate;
            CreationDate = DateTime.Now;
            Addres = addres;
            Scuritycode = RandomNumberGeneratorCode();
            Password = password;
            IsAvalable = true;
            RoleId = roleId;          // ✅ Fix: respect the provided roleId
            Picture = picture;
        }

        public void Edit(string name, string family, string phoneNumber, string email,
            DateTime birthDate, string addres, int roleId, string? picture)
        {
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            BirthDate = birthDate;
            Addres = addres;
            RoleId = roleId;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
        }

        public void ChangeStatus(bool isAvaleble) => IsAvalable = isAvaleble;

        public void ChangePassword(string password) => Password = password;

        private static string RandomNumberGeneratorCode()
        {
            // cryptographically secure 6-digit code
            Span<byte> bytes = stackalloc byte[4];
            RandomNumberGenerator.Fill(bytes);
            var num = BitConverter.ToUInt32(bytes) % 900000 + 100000;
            return num.ToString();
        }
    }
}
