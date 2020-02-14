using PANDA.ViewModels;

namespace PANDA.Services.Interfaces
{
    public interface IRecipientService
    {
        void CreateRecipient(double weight, string packageId, string userId);

        ReceiptsViewModel GetAllReceiptsForUser(string userId);
    }
}