using System;
using System.Collections.Generic;
using System.Text;

namespace BikeSharing
{
    public class Utente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Utente(int id, string nome, string cognome, string email, string password)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Email = email;
            Password = password;
        }
    }
}
