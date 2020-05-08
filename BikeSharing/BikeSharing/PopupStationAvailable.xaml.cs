using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BikeSharing
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupStationAvailable : PopupPage
    {
        string numeroOrdineRichiesta;
        public PopupStationAvailable(string numeroOrdineRiconsegna)
        {
            InitializeComponent();
            numeroOrdineRichiesta = numeroOrdineRiconsegna;
            PopupRequest request = new PopupRequest(this, "http://nicolaricciardi.altervista.org/stazioni_disponibili.php");
            request.StationAvailable();            

        }
        private void Handle_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync(true);
            Navigation.PushAsync(new SlidePage());
        }
        public void returnStationAvailable(List<StazioneDisponibile> response)
        {

            foreach (StazioneDisponibile stazione in response)
            {                
                StationAvailable.Items.Add(stazione.Nome);
            }
        }

        void Confirm_Clicked(object sender, EventArgs e)
        {
            
            if (StationAvailable.SelectedItem == null)
            {
                
            }
            else
            {                
                
                var id = Application.Current.Properties["IdUser"];
                
                var dataConsegna = DateTime.Today.ToString("d");                

                PopupRequest request = new PopupRequest(this, "http://nicolaricciardi.altervista.org/restituzione_ordine.php");
                request.RestituzioneOrdine(StationAvailable.SelectedItem.ToString(), numeroOrdineRichiesta, id.ToString(), dataConsegna);

                PopupNavigation.Instance.PopAsync();
                Navigation.PushAsync(new BottomBarPage(0));
                var existingPages = Navigation.NavigationStack.ToList();
                foreach (var page in existingPages)
                {
                    Navigation.RemovePage(page);
                }

            }

        }

    }
}