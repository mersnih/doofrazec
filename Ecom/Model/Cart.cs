using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Model
{
    class Cart : INotifyPropertyChanged
    {
        private int itemId;
        private string itemTitle;
        private double itemPrice;
        private string itemPriceTxt;
        private int itemQuantity;

        public event PropertyChangedEventHandler PropertyChanged;

        public int ItemId
        {
            get { return itemId; }
            set
            {
                itemId = value;
                NotifyPropertyChanged("ItemId");
            }

        }
        public string ItemTitle
        {
            get { return itemTitle; }
            set
            {
                itemTitle = value;
                NotifyPropertyChanged("ItemTitle");
            }

        }
        public double ItemPrice
        {
            get { return itemPrice; }
            set
            {
                itemPrice = value;
                NotifyPropertyChanged("ItemPrice");
            }

        }

        public string ItemPriceTxt
        {
            get { return itemPriceTxt; }
            set
            {
                itemPriceTxt = value;
                NotifyPropertyChanged("ItemPriceTxt");
            }

        }
        public int ItemQuantity
        {
            get { return itemQuantity; }
            set
            {
                itemQuantity = value;
                NotifyPropertyChanged("ItemQuantity");
            }

        }

        private void NotifyPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}
