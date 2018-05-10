using Ecom.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.ViewModel
{
    class CartViewModel : INotifyPropertyChanged
    {
        static ObservableCollection<Cart> cart = new ObservableCollection<Cart>();
        public ObservableCollection<Cart> Cart
        {
            get { return cart; }
            set
            {
                cart = value;
                NotifyPropertyChanged("Cart");
            }
        }

        static ObservableCollection<Payement> payement = new ObservableCollection<Payement>();
        public ObservableCollection<Payement> Payement
        {
            get { return payement; }
            set
            {
                payement = value;
                NotifyPropertyChanged("Payement");
            }
        }

        private static string totalCart;
        public string TotalCart
        {
            get { return totalCart; }
            set
            {
                totalCart = value;
                NotifyPropertyChanged("TotalCart");
            }

        }

        private static string totalRest;
        public string TotalRest
        {
            get { return totalRest; }
            set
            {
                totalRest = value;
                NotifyPropertyChanged("TotalRest");
            }

        }

        private static int ingredientCounter;
        public int IngredientCounter
        {
            get { return ingredientCounter; }
            set
            {
                ingredientCounter = value;
                NotifyPropertyChanged("IngredientCounter");
            }

        }





        private double totalPayed;
        public double TotalPayed
        {
            get { return totalPayed; }
            set
            {
                totalPayed = value;
                NotifyPropertyChanged("TotalPayed");
            }
        }


        private double totalPrice;
        private double totalRestPrice;
        public double TotalPrice
        {
            get { return totalPrice; }
            set
            {
                totalPrice = value;
                NotifyPropertyChanged("TotalPrice");
            }

        }
        public double TotalRestPrice
        {
            get { return totalRestPrice; }
            set
            {
                totalRestPrice = value;
                NotifyPropertyChanged("TotalRestPrice");
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
