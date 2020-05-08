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
    public partial class BikePage3 : ContentPage
    {
        public BikePage3()
        {
            InitializeComponent();
        }

        private async void Prenotazione_Clicked(object sender, EventArgs e)
        {
            var valore = await DisplayAlert("PRENOTAZIONE", "SI VUOLE CONFERMARE IL PRESTITO", "SI", "NO");
            if (valore)
            {                
                var idBici = "2";
                var dataPrenotazione = DateTime.Today.ToString("d");
                ServerRequest request = new ServerRequest(this, "http://nicolaricciardi.altervista.org/aggiungi_prenotazione.php");
                request.ConfermaOrdine(idBici, dataPrenotazione);

                await Navigation.PushAsync(new BottomBarPage());
                var existingPages = Navigation.NavigationStack.ToList();
                foreach (var page in existingPages)
                {
                    Navigation.RemovePage(page);
                }

            }
            
        }
    }
}