using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Model
{
    class Cashing : INotifyPropertyChanged
    {
        private double sumPriceAllItemCart;
        private double remainingToPay;

        public double SumPriceAllItemCart
        {
            get { return sumPriceAllItemCart; }
            set
            {
                sumPriceAllItemCart = value;
                NotifyPropertyChanged("SumPriceAllItemCart");
            }

        }
        public double RemainingToPay
        {
            get { return remainingToPay; }
            set
            {
                remainingToPay = value;
                NotifyPropertyChanged("RemainingToPay");
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}
