using Rg.Plugins.Popup.Pages;
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

    public partial class PopupStation : PopupPage
    {
        string nomeS;
        public PopupStation(string nomeStazione)
        {
            
            InitializeComponent();
            nomeS = nomeStazione;
            
            PopupRequest request = new PopupRequest(this, "http://nicolaricciardi.altervista.org/visualizza_stazioni.php");
            request.InfoStation(nomeS);
        }

        private void Handle_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties["NomeStazione"] = nomeS;
            Application.Current.SavePropertiesAsync();
            PopupNavigation.Instance.PopAsync(true);
            Navigation.PushAsync(new SlidePage());
        }

        public void returnStationInfo(List<Stazione> response, string nomeStazione)
        {
            nome_stazione.Text = nomeStazione;
            info_stazioni.ItemsSource = response;
            info_stazioni.ItemTemplate = new DataTemplate(typeof(StazioneCell));

        }

        

        class StazioneCell : ViewCell
        {
            public StazioneCell()
            {
                Label modelloLabel = new Label
                {
                    FontSize = 24,
                    TextColor = Xamarin.Forms.Color.White,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    IsEnabled = false                   
                };
                Label disponibilitaLabel = new Label
                {
                    FontSize = 24,
                    TextColor = Xamarin.Forms.Color.White,
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    IsEnabled = false
                };
                

                modelloLabel.SetBinding(Label.TextProperty, "Modello");
                disponibilitaLabel.SetBinding(Label.TextProperty, "Disponibilita");
                

                StackLayout stack = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children =
                    {
                        modelloLabel,
                        disponibilitaLabel                        
                    }
                };
                IsEnabled = false;
                View = stack;

            }
        }
    }
}