using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BikeSharing
{
    public class User : INotifyPropertyChanged
    {
        public Field FirstName { get; set; } = new Field();
        public Field LastName { get; set; } = new Field();
        public Field Email { get; set; } = new Field();
        public Field Password { get; set; } = new Field();
        public Field ConfirmPassword { get; set; } = new Field();
        public Field Birth { get; set; } = new Field();
        public Field Sex { get; set; } = new Field();

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class Field : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public bool IsNotValid { get; set; }
        public string NotValidMessageError { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
