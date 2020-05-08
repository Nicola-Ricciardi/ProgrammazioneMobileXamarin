using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BikeSharing
{
    public class DatePickerValidatorBehavior : Behavior<CustomDatePicker>
    {
        CustomDatePicker control;

        protected override void OnAttachedTo(CustomDatePicker bindable)
        {            
            bindable.PropertyChanged += OnPropertyChanged;
            control = bindable;
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                ((CustomDatePicker)sender).IsBorderErrorVisible = false;
            }
        }

        protected override void OnDetachingFrom(CustomDatePicker bindable)
        {
            bindable.PropertyChanged -= OnPropertyChanged;
        }

        void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == CustomDatePicker.IsBorderErrorVisibleProperty.PropertyName && control != null)
            {
                if (control.IsBorderErrorVisible)
                {
                    control.Placeholder = control.ErrorText;
                }
            }
        }
    }
}
