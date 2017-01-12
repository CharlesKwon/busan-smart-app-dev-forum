using Windows.UI.Xaml.Controls;

namespace WhereAmI.Views
{
    public sealed partial class MapPage : Page
    {
        public MapPage()
        {
            InitializeComponent();
            //캐쉬 활성화 시키면 뷰모델을 새로 만들지 않음, 뷰도 재 사용하는 듯..
            //NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }
    }
}
