using Android.Graphics.Drawables;
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
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new SignUpPageControlBehavior();
            
        }

        public void OnDateSelected(object sender, DateChangedEventArgs args)
        {
            datepicker.IsBorderErrorVisible = false;
            datepicker.Placeholder = null;            
        }


        public static void inviaQeury(string a, string b, string c, string d, string e, string f)
        {            
            SignupPage obj = new SignupPage();
            obj.query(a,b,c,d,e,f);

        }

        public void query(string nome, string cognome, string email, string password, string date, string sesso)
        {
            ServerRequest request = new ServerRequest(this, "http://nicolaricciardi.altervista.org/aggiungi_utente_post.php");
            request.SignUp(nome, cognome, email, password, date, sesso);
        }

        public void sonofuckinregistrato()
        {
            Navigation.PushAsync(new MainPage());
            var existingPages = Navigation.NavigationStack.ToList();
            foreach (var page in existingPages)
            {
                Navigation.RemovePage(page);
            }
        }
    }
}