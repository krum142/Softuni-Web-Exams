using System.Collections.Generic;
using SharedTrip.ViewModels;

namespace SharedTrip.Services.interfaces
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