namespace SULS.Services.Interfaces
{
    public interface IUsersService
    {
        void Register(string username, string email, string password);

        bool IsValidEmail(string email);

        string GetUserId(string username, string password);
    }
}
