using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BikeSharing
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public void sonofuckinloggato(string id)
        {            
            if (!string.IsNullOrEmpty(id))
            {
                Application.Current.Properties["IdUser"] = id;
                Application.Current.Properties["LoggedIn"] = "true";
                Application.Current.SavePropertiesAsync();

                Navigation.PushAsync(new BottomBarPage());
                var existingPages = Navigation.NavigationStack.ToList();
                foreach (var page in existingPages)
                {
                    Navigation.RemovePage(page);
                }
            }
            else
                DisplayAlert("Error", "No Match", "OK");
        }

        void LoadTabbedPage_Clicked(object sender, EventArgs e)
        {
            var email = Email.Text;
            var password = Password.Text;
            if (string.IsNullOrEmpty(email) == true || string.IsNullOrEmpty(password) == true)
            {

            }
            else
            {
                ServerRequest request = new ServerRequest(this, "http://nicolaricciardi.altervista.org/controlla_registro.php");
                request.CheckLogin(email, password);
            }
            
           
        }
    }
}