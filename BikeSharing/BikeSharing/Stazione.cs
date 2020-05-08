using System;
using System.Collections.Generic;
using System.Text;

namespace BikeSharing
{
    public class Stazione
    {

        public string Modello { get; set; }
        public string Disponibilita { get; set; }


        public Stazione(string modello, string disponibilita)
        {
            Modello = modello;
            Disponibilita = disponibilita;
        }
    }
}
