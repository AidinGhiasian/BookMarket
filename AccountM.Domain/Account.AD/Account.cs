using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AM.Domain.Account.AD
{
    public class Account
    {
        
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get;private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatetionDate{ get;private set; }
        public string Addres { get;private set; }
        public string scuritycode { get; private set; }
        public string Password { get; private set; }
        public string RePassword { get; private set; }

        public Account( string name, string family, string phoneNumber, string email, DateTime birthDate,string addres,string password,string repassword)
        {
            var random = new Random();
            
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            BirthDate = birthDate;
            CreatetionDate = DateTime.Now;
            Addres = addres;
            scuritycode = random.Next(100000,999999).ToString();
            Password = password;
            RePassword = repassword;
        }
        public void Edit(string name, string family, string phoneNumber, string email, DateTime birthDate, string addres,string password,string repassword)
        {
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            BirthDate = birthDate;
            CreatetionDate = DateTime.Now;
            Addres = addres;
            Password=password;
            RePassword=repassword;
        }

    }
}
