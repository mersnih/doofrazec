using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Model
{
    public class ItemModel: INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }

        }


        private string statusColor;
        public string StatusColor
        {
            get { return statusColor; }
            set
            {
                statusColor = value;
                OnPropertyChanged("StatusColor");
            }
        }

        private bool actif;
        public bool Actif
        {
            get { return actif; }
            set
            {
                actif = value;
                OnPropertyChanged("Actif");
            }
        }

        private bool cooked;
        public bool Cooked
        {
            get { return cooked; }
            set
            {
                cooked = value;
                OnPropertyChanged("Cooked");
            }
        }

        private string color;
        public string Color
        {
            get { return color; }
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }
    }
}
