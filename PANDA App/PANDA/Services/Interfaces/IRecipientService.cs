using PANDA.ViewModels;

namespace PANDA.Services.Interfaces
{
    public interface IRecipientService
    {
        string CreateRecipient(double weight, string packageId, string userId);

        ReceiptsViewModel GetAllReceiptsForUser(string userId);
    }
}