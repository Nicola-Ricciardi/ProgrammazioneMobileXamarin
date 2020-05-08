using System;
using System.Collections.Generic;
using System.Text;

namespace BikeSharing
{
    public class Ordine
    {
        public string Prenotazione { get; set; }

        public Ordine(string prenotazione)
        {
            Prenotazione = prenotazione;
        }
    }
}
