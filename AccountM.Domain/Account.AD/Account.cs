using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AccountManagement.Domain.RoleAgg;

namespace AM.Domain.Account.AD
{
    public class Account
    {

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string? Email { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public DateTime CreationDate { get; private set; } = DateTime.Now;
        public string? Address { get; private set; }
        public string Password { get; private set; }
        public bool IsAvalable { get; private set; }
        public int RoleId { get; private set; }
        public string? Picture { get; private set; }
        public Role Role { get; private set; }
        public Account() { }

        public Account(string name, string family, string phoneNumber, string? email, DateTime? birthDate, string? address, string password, int roleId, string? picture)
        {
            var random = new Random();

            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            BirthDate = birthDate;
            CreationDate = DateTime.Now;
            Address = address;
            Password = password;
            IsAvalable = true;
            RoleId = 2;
            Picture = picture;
        }
        public void Edit(string name, string family, string phoneNumber, string? email, DateTime? birthDate, string? address, string? picture)
        {
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            BirthDate = birthDate;
            CreationDate = DateTime.Now;
            Address = address;
            Picture = picture;

        }
        public void ChangeStatus(bool isAvaleble)
        {
            IsAvalable = isAvaleble;
        }
        public void ChangePassword(string password)
        {
            Password = password;
        }
        public void ChangeRole(int roleId)
        {
            RoleId = roleId;
        }
    }
}
