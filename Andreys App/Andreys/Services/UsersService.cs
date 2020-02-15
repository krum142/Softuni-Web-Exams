using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Andreys.App.Models;
using Andreys.Data;
using SIS.MvcFramework;

namespace Andreys.App.Services
{
    public class UsersService : IUsersService
    {
        private readonly AndreysDbContext db;

        public UsersService(AndreysDbContext db)
        {
            this.db = db;
        }

        public void Register(string username, string email, string password)
        {
            User user = new User
            {
                Username = username,
                Email = email,
                Password = this.Hash(password),
                Role = IdentityRole.User
            };

            db.User.Add(user);
            db.SaveChanges();
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

        public string GetUserId(string username, string password)
        {
            var userId = db.User
                .Where(u => u.Username == username && u.Password == this.Hash(password))
                .Select(x => x.Id)
                .FirstOrDefault();

            return userId;
        }

        private string Hash(string input)
        {
            if (input == null)
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