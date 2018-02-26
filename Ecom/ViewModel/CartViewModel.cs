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
        static ObservableCollection<Payement> payement = new ObservableCollection<Payement>();
        private static string totalCart;
        private static string totalRest;
        private static int ingredientCounter;

        public string TotalCart
        {
            get { return totalCart; }
            set
            {
                totalCart = value;
                NotifyPropertyChanged("TotalCart");
            }

        }
        public string TotalRest
        {
            get { return totalRest; }
            set
            {
                totalRest = value;
                NotifyPropertyChanged("TotalRest");
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

        public int IngredientCounter
        {
            get { return ingredientCounter; }
            set
            {
                ingredientCounter = value;
                NotifyPropertyChanged("IngredientCounter");
            }

        }


        public ObservableCollection<Cart> Cart
        {
            get {return cart; }
            set
            {
                cart = value;
                NotifyPropertyChanged("Cart");
            }
        }
        public ObservableCollection<Payement> Payement
        {
            get { return payement; }
            set
            {
                payement = value;
                NotifyPropertyChanged("Payement");
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
