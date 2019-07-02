using Bit.ViewModel;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XamApp.Models;
using Xamarin.Forms;

namespace XamApp.ViewModels
{
    public class ServiceItemsViewModel : BitViewModelBase //, INotifyPropertyChanged
    {
        public BitDelegateCommand DeactivateCommand { get; set; }
        private ServiceItemsRepository itemRepo;
        public ServiceItemsViewModel()
        {
            itemRepo = new ServiceItemsRepository();
            DeactivateCommand = new BitDelegateCommand(DeactivationMenu);
        }
        public List<ServiceItems> serviceItems { get; set; }

        public async override Task OnNavigatedToAsync(INavigationParameters parameters)
        {            
            Assembly assembly = typeof(XamApp.Views.ServiceItemsView).GetTypeInfo().Assembly;           
            serviceItems = new List<ServiceItems>
            {
                new ServiceItems {Name = itemRepo.Names[0] , Images = ImageSource.FromResource("XamApp.Images.blue.jpg", assembly)},
                new ServiceItems {Name = itemRepo.Names[1] , Images = ImageSource.FromResource("XamApp.Images.green.jpg", assembly)},
                new ServiceItems {Name = itemRepo.Names[2] , Images = ImageSource.FromResource("XamApp.Images.iceBlue.jpg", assembly)},
                new ServiceItems {Name = itemRepo.Names[3] , Images = ImageSource.FromResource("XamApp.Images.green.jpg", assembly)},
                new ServiceItems {Name = itemRepo.Names[4] , Images = ImageSource.FromResource("XamApp.Images.blue.jpg", assembly)},
                new ServiceItems {Name = itemRepo.Names[5] , Images = ImageSource.FromResource("XamApp.Images.green.jpg", assembly)},
                new ServiceItems {Name = itemRepo.Names[6] , Images = ImageSource.FromResource("XamApp.Images.iceBlue.jpg", assembly)},
                new ServiceItems {Name = itemRepo.Names[7] , Images = ImageSource.FromResource("XamApp.Images.green.jpg", assembly)},
                new ServiceItems {Name = itemRepo.Names[8] , Images = ImageSource.FromResource("XamApp.Images.blue.jpg", assembly)}
            };
            await base.OnNavigatedToAsync(parameters);
        }

        public async Task DeactivationMenu()
        {

        }

    }
}
