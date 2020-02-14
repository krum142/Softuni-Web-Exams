using System;
using System.Collections.Generic;
using System.Linq;
using PANDA.Data;
using PANDA.Models;
using PANDA.Models.Enums;
using PANDA.Services.Interfaces;
using PANDA.ViewModels;
using PANDA.ViewModels.PackageViewModels;

namespace PANDA.Services
{
    public class PackageService : IPackageService
    {
        private PandaContext db;
        private readonly IUsersService usersService;
        private readonly IRecipientService recipientService;

        public PackageService(PandaContext db, IUsersService usersService, IRecipientService recipientService)
        {
            this.db = db;
            this.usersService = usersService;
            this.recipientService = recipientService;
        }
        public void CreatePackage(CreatePackageViewModel packageInfo)
        {
            var package = new Package()
            {
                Description = packageInfo.Description,
                EstimatedDeliveryDate = DateTime.UtcNow.AddDays(2),
                RecipientId = usersService.GetUserId(packageInfo.RecipientName),
                //Recipient = usersService.GetUser(packageInfo.RecipientName),
                Status = Status.Pending,
                Weight = double.Parse(packageInfo.Weight),
                ShippingAddress = packageInfo.ShippingAddress,
            };

            db.Package.Add(package);
            db.SaveChanges();

            //recipientService.CreateRecipient(packageInfo.Weight, package.Id, package.RecipientId);
        }

        public PackagesViewModel GetPendingPackages()
        {
            var packages = db.Package
                .Where(p => p.Status == Status.Pending)
                .Select(p => new PackageViewModels
                {
                    Description = p.Description,
                    Id = p.Id,
                    RecipientName = p.Recipient.Username,
                    ShippingAddress = p.ShippingAddress,
                    Weight = p.Weight
                }).ToList();

            var viewModel = new PackagesViewModel
            {
                Packages = packages
            };

            return viewModel;
        }

        public void DeliverPackage(string packageId)
        {
            var package = db.Package.FirstOrDefault(p => p.Id == packageId);

            package.Status = Status.Delivered;

            recipientService.CreateRecipient(package.Weight, packageId, package.RecipientId);

            db.SaveChanges();
        }

        public PackagesViewModel GetDeliveredPackages()
        {
            var packages = db.Package
                .Where(p => p.Status == Status.Delivered)
                .Select(p => new PackageViewModels
                {
                    Description = p.Description,
                    Id = p.Id,
                    RecipientName = p.Recipient.Username,
                    ShippingAddress = p.ShippingAddress,
                    Weight = p.Weight
                }).ToList();

            var viewModel = new PackagesViewModel
            {
                Packages = packages
            };

            return viewModel;
        }
    }
}