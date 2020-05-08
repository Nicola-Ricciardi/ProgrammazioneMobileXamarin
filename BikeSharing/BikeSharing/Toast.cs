using System;
using System.Collections.Generic;
using System.Text;

namespace BikeSharing
{
    public interface IToast
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
