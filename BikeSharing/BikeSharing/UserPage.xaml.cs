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
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            
            Task.Delay(2500).Wait();
            InitializeComponent();
            ServerRequest request = new ServerRequest(this, "http://nicolaricciardi.altervista.org/info_utente.php");
            request.InfoUser();
            ServerRequest request1 = new ServerRequest(this, "http://nicolaricciardi.altervista.org/visualizza_prestiti.php");
            request1.InfoOrder();           

        }

        public void returnUserInfo(string NomeUtente, string CognomeUtente, string EmailUtente)
        {
            NomeUser.Text = NomeUtente;
            CognomeUser.Text = CognomeUtente;
            EmailUser.Text = EmailUtente;

        }
        
        public void returnUserOrder(List<Ordine> info_order)
        {
            info_ordini.ItemsSource = info_order;
            info_ordini.ItemTemplate = new DataTemplate(typeof(OrdineCell));

        }
       

        public class OrdineCell : CustomCell
        {
            public OrdineCell()
            {
                
                Label textBaseLabel = new Label
                {
                    FontSize = 24,
                    Text = "Numero Ordine: ",
                    TextColor = Xamarin.Forms.Color.Black,
                    HorizontalOptions = LayoutOptions.StartAndExpand
                    
                };
                Label ordineLabel = new Label
                {
                    FontSize = 24,
                    TextColor = Xamarin.Forms.Color.Black,
                    HorizontalOptions = LayoutOptions.EndAndExpand
                    
                    
                };
                
                CustomButtons riconsegnaButton = new CustomButtons
                {
                    Text = "Redelivery",
                    FontAttributes = Xamarin.Forms.FontAttributes.Bold,
                    CustomBorderColor = Xamarin.Forms.Color.Black,
                    CustomBackgroundColor = Xamarin.Forms.Color.Transparent,
                    TextColor = Xamarin.Forms.Color.Black,
                    CustomBorderRadius = 21,
                    CustomBorderWidth = 7,
                    HorizontalOptions = Xamarin.Forms.LayoutOptions.End
                };

                riconsegnaButton.Clicked += (sender, EventArgs) => { RiconsegnaButton_Clicked(sender, EventArgs, ordineLabel.Text); };


                ordineLabel.SetBinding(Label.TextProperty, "Prenotazione");


                StackLayout stack = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children =
                    {
                        textBaseLabel,
                        ordineLabel,
                        riconsegnaButton
                    }
                };

               
                SelectedBackgroundColor = Xamarin.Forms.Color.Chocolate;
                View = stack;
                

            }

            private void RiconsegnaButton_Clicked(object sender, EventArgs e, string numeroOrdine)
            {
                PopupNavigation.Instance.PushAsync(new PopupStationAvailable(numeroOrdine));
            }
        }



       

        void Logout_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties.Clear();
            Application.Current.SavePropertiesAsync();
            
            DisplayAlert("Success", "Logout", "OK");
            Navigation.PushAsync(new MainPage());
           
        }
    }
}