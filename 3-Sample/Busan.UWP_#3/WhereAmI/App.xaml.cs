using System.Threading.Tasks;
using Template10.Common;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Data;

namespace WhereAmI
{
    // sample: https://github.com/Windows-XAML/Template10/blob/master/Templates%20(Project)/Minimal/App.xaml.cs
    
    [Bindable]
    sealed partial class App : BootStrapper
    {
        public App()
        {
            InitializeComponent();
            RequestedTheme = Windows.UI.Xaml.ApplicationTheme.Light;
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            // TODO: add your long-running task here
            await NavigationService.NavigateAsync(typeof(Views.MainPage));
        }
    }
}

