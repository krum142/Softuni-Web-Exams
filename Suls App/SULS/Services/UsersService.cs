using SIS.MvcFramework;
using SULS.Data;
using SULS.Models;
using SULS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace SULS.Services
{
    public class UsersService : IUsersService
    {
        private SulsDbContext db;
        public UsersService(SulsDbContext db)
        {
            this.db = db;
        }
        public void Register(string username, string email, string password)
        {
            User user = new User {
                Username = username,
                Email = email,
                Password = this.Hash(password),
                Role = IdentityRole.User
            };

            db.Users.Add(user);
            db.SaveChanges();
        }

        public string GetUserId(string username,string password)
        {
            var userId = db.Users
                .Where(u => u.Username == username && u.Password == this.Hash(password))
                .Select(x => x.Id)
                .FirstOrDefault();

            return userId;
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private string Hash(string input)
        {
            if(input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (var theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
