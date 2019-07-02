using Bit.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace XamApp.Models
{
   
    public class ServiceItems : Bindable , INotifyPropertyChanged
    {

        public String Name { get; set; }
        public ImageSource Images { get; set; }

        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
