using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BikeSharing
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomBarPage : TabbedPage
    {
        public BottomBarPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            CurrentPage = this.Children[1];
        }

        public BottomBarPage(int sezioneUtente)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            CurrentPage = this.Children[0];
        }
    }
}