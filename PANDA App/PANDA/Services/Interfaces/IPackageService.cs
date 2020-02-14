using System.Collections.Generic;
using PANDA.ViewModels;
using PANDA.ViewModels.PackageViewModels;

namespace PANDA.Services.Interfaces
{
    public interface IPackageService
    {
        void CreatePackage(CreatePackageViewModel input);

        PackagesViewModel GetPendingPackages();

        PackagesViewModel GetDeliveredPackages();

        void DeliverPackage(string packageId);
    }
}