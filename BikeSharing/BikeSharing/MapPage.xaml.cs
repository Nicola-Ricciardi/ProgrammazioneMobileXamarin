using Rg.Plugins.Popup.Services;
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
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }


        void Station1_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupStation("Piazza Cavour"));
        }
        void Station2_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupStation("Stazione Centrale"));
        }
        void Station3_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupStation("Piazza Ugo Bassi"));
        }
        void Station4_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupStation("Universita"));
        }
        void Station5_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupStation("Supermercato Auchan"));
        }

    }
}