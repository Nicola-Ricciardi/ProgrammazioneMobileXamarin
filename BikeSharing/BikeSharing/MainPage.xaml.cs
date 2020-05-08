using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace BikeSharing
{   
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            if (Application.Current.Properties.ContainsKey("LoggedIn"))
            {
                if (Application.Current.Properties["LoggedIn"].ToString() == "true")
                {                    
                    Navigation.PushAsync(new BottomBarPage());
                }
                else
                {
                    InitializeComponent();
                    NavigationPage.SetHasNavigationBar(this, false);
                }
            }
            else
            {
                InitializeComponent();
                NavigationPage.SetHasNavigationBar(this, false);
            }
        }


        void LoadLoginPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        void LoadSignupPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignupPage());
        }

    }

}
