using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BikeSharing
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BikePage2 : ContentPage
    {
        public BikePage2()
        {
            InitializeComponent();
        }

        private async void Prenotazione_Clicked(object sender, EventArgs e)
        {
            var valore = await DisplayAlert("PRENOTAZIONE", "SI VUOLE CONFERMARE IL PRESTITO", "SI", "NO");
            if (valore)
            {                
                var idBici = "1";
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