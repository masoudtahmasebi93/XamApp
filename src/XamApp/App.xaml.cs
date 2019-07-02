using Acr.UserDialogs;
using Autofac;
using Bit;
using Bit.ViewModel.Contracts;
using Bit.ViewModel.Implementations;
using Prism;
using Prism.Autofac;
using Prism.Ioc;
using Prism.Navigation;
using System.Globalization;
using System.Threading.Tasks;
using XamApp.Resources;
using XamApp.ViewModels;
using XamApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace XamApp
{
    public partial class App : BitApplication
    {
        public static new App Current => (App)Application.Current;

        public App()
            : this(null)
        {
        }

        public App(IPlatformInitializer platformInitializer)
            : base(platformInitializer)
        {
#if DEBUG
            LiveReload.Init();
#endif
        }

        protected override async Task OnInitializedAsync()
        {
            InitializeComponent();

            Strings.Culture = CultureInfo.CurrentUICulture = new CultureInfo("en");
            
            await NavigationService.NavigateAsync("/Nav/Code", animated: false);

            await base.OnInitializedAsync();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ContainerBuilder containerBuilder = containerRegistry.GetBuilder();

            containerRegistry.RegisterForNav<NavigationPage>("Nav");
          
            containerRegistry.RegisterForNav<CodeVerifyView, CodeVerifyViewModel>("Code");
            containerRegistry.RegisterForNav<ServiceItemsView, ServiceItemsViewModel>("ServiceItems");

            containerBuilder.Register<IClientAppProfile>(c => new DefaultClientAppProfile
            {
                AppName = "XamApp",
            }).SingleInstance();

            containerBuilder.RegisterRequiredServices();

            containerBuilder.RegisterInstance(UserDialogs.Instance);

            base.RegisterTypes(containerRegistry);
        }
    }
}
