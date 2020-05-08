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
    public partial class SlidePage : CarouselPage
    {
        public SlidePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        
    }
}