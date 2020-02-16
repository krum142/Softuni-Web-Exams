using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using SharedTrip.Models;
using System.Linq;
using SharedTrip.Services.interfaces;
using SharedTrip.ViewModels;

namespace SharedTrip.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void CreateUser(UserRegisterViewModel input)
        {
            var user = new User()
            {
                Username = input.Username,
                Password = Hash(input.Password),
                Email = input.Email
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
            var userId = db.User.Where(u => u.Username == username &&
                                           u.Password == Hash(password)).Select(x => x.Id).FirstOrDefault();

            return userId;
        }

        public string GetUserId(string username)
        {
            var userId = db.User.Where(u => u.Username == username).Select(x => x.Id).FirstOrDefault();

            return userId;
        }

        public ICollection<string> GetAllUsernames()
        {
            var usernames = db.User.Select(u => u.Username).ToList();

            return usernames;
        }

        public string GetUserNmae(string userId)
        {
            var username = db.User.Where(u => u.Id == userId).Select(x => x.Username).FirstOrDefault();

            return username;
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