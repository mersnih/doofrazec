using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Model
{
    class ItemIngredient : INotifyPropertyChanged
    {

        private int idItem;
        private int idIngredient;
        private string item_title;
        private string ingredient_title;
        private int ingredient_quantity;

        public event PropertyChangedEventHandler PropertyChanged;

        public int IdItem
        {
            get { return idItem; }
            set
            {
                idItem = value;
                NotifyPropertyChanged("IdItem");
            }
        }
        public int IdIngredient
        {
            get { return idIngredient; }
            set
            {
                idIngredient = value;
                NotifyPropertyChanged("IdIngredient");
            }
        }
        public string Item_title
        {
            get { return item_title; }
            set
            {
                item_title = value;
                NotifyPropertyChanged("Item_title");
            }
        }
        public string Ingredient_title
        {
            get { return ingredient_title; }
            set
            {
                ingredient_title = value;
                NotifyPropertyChanged("Ingredient_title");
            }
        }

        public int Ingredient_quantity
        {
            get { return ingredient_quantity; }
            set
            {
                ingredient_quantity = value;
                NotifyPropertyChanged("Ingredient_quantity");
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
