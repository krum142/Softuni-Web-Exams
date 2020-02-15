namespace Andreys.App.Services
{
    public interface IUsersService
    { 
        string GetUserId(string username, string password);

        bool IsValidEmail(string email);

        void Register(string username, string email, string password);
    }
}