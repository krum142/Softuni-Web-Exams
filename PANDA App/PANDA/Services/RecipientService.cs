using System;
using System.Linq;
using PANDA.Data;
using PANDA.Models;
using PANDA.Services.Interfaces;
using PANDA.ViewModels;

namespace PANDA.Services
{
    public class RecipientService : IRecipientService
    {
        private readonly PandaContext db;

        public RecipientService(PandaContext db)
        {
            this.db = db;
        }

        public void CreateRecipient(double weight,string packageId,string userId)
        {
            var recipient = new Receipt()
            {
                Fee = (decimal)(weight * 2.64),
                IssuedOn = DateTime.UtcNow,
                RecipientId = userId,
                PackageId = packageId,
            };

            db.Receipt.Add(recipient);
            db.SaveChanges();
        }

        public ReceiptsViewModel GetAllReceiptsForUser(string userId)
        {
            var receipts = db.Receipt
                .Where(r => r.RecipientId == userId)
                .Select(r => new ReceiptViewModel
                {
                    Id = r.Id,
                    Fee = r.Fee,
                    IssuedOn = r.IssuedOn,
                    Name = r.Recipient.Username
                }).ToList();

            var viewModel = new ReceiptsViewModel
            {
                Receipts = receipts
            };

            return viewModel;
        }
    }
}