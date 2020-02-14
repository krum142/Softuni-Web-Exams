using System.Collections.Generic;
using PANDA.Models;
using PANDA.ViewModels;
using PANDA.ViewModels.UserViewModels;

namespace PANDA.Services.Interfaces
{
    public interface IUsersService
    {
        void CreateUser(UserRegisterViewModel input);

        bool IsValidEmail(string email);

        string GetUserId(string username, string password);

        string GetUserId(string username);

        ICollection<string> GetAllUsernames();

        string GetUserNmae(string userId);

    }
}