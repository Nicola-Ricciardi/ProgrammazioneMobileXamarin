using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;
using static Android.App.Notification.MessagingStyle;

namespace BikeSharing
{
    class ServerRequest
    {
        private string URL; 
        private HttpClient _client;
        private ContentPage mainPage;
        
        public ServerRequest(ContentPage mainPage, string URL)
        {
            this.mainPage = mainPage;
            this.URL = URL;
            this._client = new HttpClient();
        }


        public async void CheckLogin(string Mail, string Pass)
        {
            var response = await _client.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                
                String Id = "";
                var email = Mail;
                var password = Pass;
                var result = response.Content.ReadAsStringAsync().Result;
                Dictionary<string, Utente> result_utenti = JsonConvert.DeserializeObject<Dictionary<string, Utente>>(result);

                foreach (KeyValuePair<string, Utente> entry in result_utenti)
                {

                    if ((email.Equals(entry.Value.Email)) && (password.Equals(entry.Value.Password)))
                    {                        
                        Id = entry.Key;
                    }
                }
                LoginPage loginPage = (LoginPage)mainPage;
                loginPage.sonofuckinloggato(Id);
            }
            else
            {
                
            }
            
        }

        public async void InfoUser()
        {
            var id = Application.Current.Properties["IdUser"];
            HttpContent formcontent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("id_utente",id.ToString())});

            var response = await _client.PostAsync(URL, formcontent);
            if (response.IsSuccessStatusCode)
            {
                String firstName = "";
                String lastName = "";
                String email = "";
                string resultQuery = response.Content.ReadAsStringAsync().Result.ToString();
                
                Dictionary<string, Utente> info_utente = JsonConvert.DeserializeObject<Dictionary<string, Utente>>(resultQuery);
                
                foreach (KeyValuePair<string, Utente> entry in info_utente)
                {
                    firstName = entry.Value.Nome;
                    lastName = entry.Value.Cognome;
                    email = entry.Value.Email;

                }
                UserPage info_userPage = (UserPage)mainPage;
                info_userPage.returnUserInfo(firstName, lastName, email);
            }
            
        }

        public async void InfoOrder()
        {
            var id = Application.Current.Properties["IdUser"];
            HttpContent formcontent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("id_utente",id.ToString())});
            var response = await _client.PostAsync(URL, formcontent);
            if (response.IsSuccessStatusCode)
            {
                string resultQuery = response.Content.ReadAsStringAsync().Result.ToString();

                if (resultQuery != " ")
                {
                    Dictionary<string, Ordine> info_ordine = JsonConvert.DeserializeObject<Dictionary<string, Ordine>>(resultQuery);
                    List<Ordine> id_ordini = new List<Ordine>();
                    foreach (KeyValuePair<string, Ordine> entry in info_ordine)
                    {
                        id_ordini.Add(new Ordine(entry.Value.Prenotazione));

                    }
                    UserPage order_userPage = (UserPage)mainPage;
                    order_userPage.returnUserOrder(id_ordini);
                }
                else
                {
                    
                }
                
            }

        }       

        public async void ConfermaOrdine(string Bici, string data)
        {
            string numeroBici = Bici;
            string dataPrenotazione = data;
            var idUtente = Application.Current.Properties["IdUser"];
            var nomeStazione = Application.Current.Properties["NomeStazione"];

            HttpContent formcontent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("id_utente",idUtente.ToString()),
                new KeyValuePair<string,string>("id_stazione",nomeStazione.ToString()),
                new KeyValuePair<string,string>("id_bici",numeroBici.ToString()),
                new KeyValuePair<string,string>("date",dataPrenotazione.ToString())});
            var response = await _client.PostAsync(URL, formcontent);
            if (response.IsSuccessStatusCode)
            {                
                DependencyService.Get<IToast>().LongAlert("Prestito Effettuato. L'ordine sarà presente nella sezione utente");
            }
            else
            {
                
            }
        }

        public async void SignUp(string nome, string cognome, string email, string password, string data, string sesso)
        {
            string nomeUtente = nome;
            string cognomeUtente = cognome;
            string emailUtente = email;
            string passwordUtente = password;
            string dataUtente = data;
            string sessoUtente = sesso;

            HttpContent formcontent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("nome",nomeUtente.ToString()),
                new KeyValuePair<string,string>("cognome",cognomeUtente.ToString()),
                new KeyValuePair<string,string>("email",emailUtente.ToString()),
                new KeyValuePair<string,string>("password",passwordUtente.ToString()),
                new KeyValuePair<string,string>("date",dataUtente.ToString()),
                new KeyValuePair<string,string>("sesso",sessoUtente.ToString())});
            var response = await _client.PostAsync(URL, formcontent);
            if (response.IsSuccessStatusCode)
            {                
                SignupPage signupPage = (SignupPage)mainPage;
                signupPage.sonofuckinregistrato();

            }
            else
            {
                
            }
        }
    }
}