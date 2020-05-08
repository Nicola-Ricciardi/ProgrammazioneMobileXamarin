using System;
using System.Collections.Generic;
using System.Text;

namespace BikeSharing
{
    public class StazioneDisponibile
    {
        public string Nome { get; set; }

        public StazioneDisponibile(string nome)
        {
            Nome = nome;
        }
    }
}
