using Android.Content.Res;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace BikeSharing
{
    class SignUpPageControlBehavior : INotifyPropertyChanged
    {
        public User User { get; set; }
        public bool ErrorMessageVisiliby { get; set; }
        public ICommand OnValidationCommand { get; set; }
        public SignUpPageControlBehavior()
        {
            User = new User();

            var textPattern = "^" +
                    "([a-zA-Z]+)" +                    
                    "$";

            var emailPattern = "^" + "([a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+)" + "$";

            var passwordPattern = "^" +
                    "(?=.*[0-9])" +
                    "(?=.*[a-z])" +
                    "(?=.*[A-Z])" +
                    "(?=.*[@#$%^&+=])" +
                    "(?=\\S+$)" +
                    ".{6,}" +
                    "$";




            OnValidationCommand = new Command((obj) =>
            {
                
                if (string.IsNullOrEmpty(User.FirstName.Name))
                {
                    User.FirstName.NotValidMessageError = "FirstName is required";
                    User.FirstName.IsNotValid = true;
                }
                else if (!Regex.IsMatch(User.FirstName.Name, textPattern) || User.FirstName.Name.Length < 5)
                {
                    
                    if (User.FirstName.Name.Length < 5)
                    {
                        User.FirstName.NotValidMessageError = "FirstName must have more than 5 characteres";
                    }
                    else if (!Regex.IsMatch(User.FirstName.Name, textPattern))
                    {
                        User.FirstName.NotValidMessageError = "Insert only characteres";                        
                    }
                    User.FirstName.IsNotValid = true;
                }
                else
                {
                    User.FirstName.IsNotValid = false;
                }
                

                if (string.IsNullOrEmpty(User.LastName.Name))
                {
                    User.LastName.NotValidMessageError = "LastName is required";
                    User.LastName.IsNotValid = true;
                }
                else if (!Regex.IsMatch(User.LastName.Name, textPattern) || User.LastName.Name.Length < 5)
                {

                    if (User.LastName.Name.Length < 5)
                    {
                        User.LastName.NotValidMessageError = "LastName must have more than 5 characteres";
                    }
                    else if (!Regex.IsMatch(User.LastName.Name, textPattern))
                    {
                        User.LastName.NotValidMessageError = "Insert only characteres";
                    }
                    User.LastName.IsNotValid = true;
                }
                else
                {
                    User.LastName.IsNotValid = false;
                }
                

                if (string.IsNullOrEmpty(User.Email.Name))
                {
                    User.Email.NotValidMessageError = "Email is required";
                    User.Email.IsNotValid = true;
                }
                else if (!Regex.IsMatch(User.Email.Name, emailPattern))
                {
                    User.Email.NotValidMessageError = "Insert a valid email";
                    User.Email.IsNotValid = true;
                }
                else
                {
                    User.Email.IsNotValid = false;
                }
                

                if (string.IsNullOrEmpty(User.Password.Name))
                {
                    User.Password.NotValidMessageError = "Password is required";
                    User.Password.IsNotValid = true;
                }
                else if (!Regex.IsMatch(User.Password.Name, passwordPattern) || User.Password.Name.Length < 6)
                {
                    if (User.Password.Name.Length < 6)
                    {
                        User.Password.NotValidMessageError = "Password must have more than 6 charcteres";
                    }
                    else if (!Regex.IsMatch(User.Password.Name, passwordPattern))
                    {
                        User.Password.NotValidMessageError = "Weak password. Insert a number, lowercase and uppercase letters and special character" ;
                    }                    
                    User.Password.IsNotValid = true;
                }
                else
                {
                    User.Password.IsNotValid = false;
                }


                if (string.IsNullOrEmpty(User.ConfirmPassword.Name))
                {
                    User.ConfirmPassword.NotValidMessageError = "Password is required";
                    User.ConfirmPassword.IsNotValid = true;
                }
                else if (!Regex.IsMatch(User.ConfirmPassword.Name, passwordPattern) || User.ConfirmPassword.Name.Length < 6)
                {
                    if (User.ConfirmPassword.Name.Length < 6)
                    {
                        User.ConfirmPassword.NotValidMessageError = "Password must have more than 6 charcteres";
                    }
                    else if (!Regex.IsMatch(User.ConfirmPassword.Name, passwordPattern))
                    {
                        User.ConfirmPassword.NotValidMessageError = "Weak password. Insert a number, lowercase and uppercase letters and special character";
                    }
                    User.ConfirmPassword.IsNotValid = true;
                }
                else
                {
                    User.ConfirmPassword.IsNotValid = false;
                }


                if (string.IsNullOrEmpty(User.Birth.Name))
                {
                    User.Birth.NotValidMessageError = "DatePicker is required";
                    User.Birth.IsNotValid = true;
                }
                else
                {
                    DateTime dateOnly = DateTime.ParseExact(User.Birth.Name, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime myDate = dateOnly.Date;
                    DateTime thisDay = DateTime.Today;

                    if (((int.Parse(thisDay.ToString("yyyy"))) - (int.Parse(myDate.ToString("yyyy")))) > 18)
                    {
                        User.Birth.NotValidMessageError = " ";
                        User.Birth.IsNotValid = false;
                    }
                    else if (((int.Parse(thisDay.ToString("yyyy"))) - (int.Parse(myDate.ToString("yyyy")))) == 18)
                    {
                        if (int.Parse(thisDay.ToString("MM")) > int.Parse(myDate.ToString("MM")))
                        {
                            User.Birth.IsNotValid = false;
                        }
                        else if (int.Parse(thisDay.ToString("MM")) == int.Parse(myDate.ToString("MM")))
                        {
                            if (int.Parse(thisDay.ToString("dd")) >= int.Parse(myDate.ToString("dd")))
                            {
                                User.Birth.IsNotValid = false;
                            }
                            else
                            {
                                User.Birth.NotValidMessageError = "To register you must be 18";
                                User.Birth.IsNotValid = true;
                            }
                        }
                        else
                        {
                            User.Birth.NotValidMessageError = "To register you must be 18";
                            User.Birth.IsNotValid = true;
                        }
                    }
                    else if (((int.Parse(thisDay.ToString("yyyy"))) - (int.Parse(myDate.ToString("yyyy")))) < 18)
                    {
                        User.Birth.NotValidMessageError = "To register you must be 18";
                        User.Birth.IsNotValid = true;
                    }
                }

               

                if ((User.FirstName.IsNotValid == false) & (User.LastName.IsNotValid == false) & (User.Email.IsNotValid == false) & (User.Password.IsNotValid == false) &
                (User.ConfirmPassword.IsNotValid == false) & (User.Birth.IsNotValid == false))
                {
                    string nome = User.FirstName.Name;
                    string cognome = User.LastName.Name;
                    string email = User.Email.Name;
                    string password = User.Password.Name;
                    DateTime dateOnly = DateTime.ParseExact(User.Birth.Name, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);                    
                    string date = dateOnly.ToString("MM") + "/" + dateOnly.ToString("dd") + "/" + dateOnly.ToString("yyyy");
                    string sesso = User.Sex.Name;
                    
                    SignupPage.inviaQeury(nome, cognome, email, password, date, sesso);
                }

            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
