using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;

namespace BikeSharing
{
    class PopupRequest
    {
        private string URL;
        private HttpClient _client;
        private PopupPage popupPage;

        public PopupRequest(PopupPage popupPage, string URL)
        {
            this.popupPage = popupPage;
            this.URL = URL;
            this._client = new HttpClient();
        }

        public async void InfoStation(string nomeS)
        {
            string nomeStazione = nomeS;

            HttpContent formcontent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("nome_stazione",nomeStazione)});

            var response = await _client.PostAsync(URL, formcontent);
            if (response.IsSuccessStatusCode)
            {
                string resultQuery = response.Content.ReadAsStringAsync().Result.ToString();
                
                Dictionary<string, Stazione> info_stazione = JsonConvert.DeserializeObject<Dictionary<string, Stazione>>(resultQuery);
                
                List<Stazione> stazione = new List<Stazione>();
                foreach (KeyValuePair<string, Stazione> entry in info_stazione)
                { 
                    stazione.Add(new Stazione(entry.Value.Modello, entry.Value.Disponibilita));
                }
                PopupStation station_popupPage = (PopupStation)popupPage;
                station_popupPage.returnStationInfo(stazione, nomeStazione);
            }
        }

        public async void StationAvailable()
        {
            var response = await _client.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                string resultQuery = response.Content.ReadAsStringAsync().Result.ToString();
                
                if(resultQuery=="[]")
                {
                    
                }
                else
                { 
                    
                    Dictionary<string, StazioneDisponibile> stazione_disp = JsonConvert.DeserializeObject<Dictionary<string, StazioneDisponibile>>(resultQuery);
                    
                    List<StazioneDisponibile> stazione = new List<StazioneDisponibile>();
                    foreach (KeyValuePair<string, StazioneDisponibile> entry in stazione_disp)
                    {                        
                        stazione.Add(new StazioneDisponibile(entry.Value.Nome));
                    }
                    PopupStationAvailable stationAvailable_popupPage = (PopupStationAvailable)popupPage;
                    stationAvailable_popupPage.returnStationAvailable(stazione);
                }
               
            }
        }

        public async void RestituzioneOrdine(string stazione, string idRiconsegna, string idUtente, string dataRestituzione)
        {
            HttpContent formcontent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("id_utente",idUtente.ToString()),
                new KeyValuePair<string,string>("id_ordine",idRiconsegna.ToString()),
                new KeyValuePair<string,string>("nome_stazione",stazione.ToString()),
                new KeyValuePair<string,string>("date",dataRestituzione.ToString())});
            var response = await _client.PostAsync(URL, formcontent);
            if (response.IsSuccessStatusCode)
            {
                
            }
            else
            {
                
            }
        }
    }
}
