using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Model
{
    class Payement : INotifyPropertyChanged
    {
        private string payementType;
        public string PayementType
        {
            get { return payementType; }
            set
            {
                payementType = value;
                NotifyPropertyChanged("PayementType");
            }
        }

        private void NotifyPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        private double payementValue;
        public double PayementValue
        {
            get { return payementValue; }
            set
            {
                payementValue = value;
                NotifyPropertyChanged("PayementValue");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
