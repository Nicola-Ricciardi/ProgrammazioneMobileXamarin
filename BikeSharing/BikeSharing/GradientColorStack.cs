using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace BikeSharing
{    
    public class GradientColorStack : StackLayout
    {
        public Color StartColor { get; set; }
        public Color EndColor { get; set; }
    }
}
