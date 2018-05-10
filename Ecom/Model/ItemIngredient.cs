using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Model
{
    public class ItemIngredient : INotifyPropertyChanged
    {

        private int idItem;
        private int ingredientSelectedIndex;
        private int idIngredient;
        private string item_title;
        private string ingredient_title;
        private string ingredient_category_tutle;
        private double ingredient_price;
        private int ingredient_quantity;
        private int ingredient_category_id;

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
        public int IngredientSelectedIndex
        {
            get { return ingredientSelectedIndex; }
            set
            {
                ingredientSelectedIndex = value;
                NotifyPropertyChanged("IngredientSelectedIndex");
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
        public string Ingredient_category_tutle
        {
            get { return ingredient_category_tutle; }
            set
            {
                ingredient_category_tutle = value;
                NotifyPropertyChanged("Ingredient_category_tutle");
            }
        }
        public double Ingredient_price
        {
            get { return ingredient_price; }
            set
            {
                ingredient_price = value;
                NotifyPropertyChanged("Ingredient_price");
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
        public int Ingredient_category_id
        {
            get { return ingredient_category_id; }
            set
            {
                ingredient_category_id = value;
                NotifyPropertyChanged("Ingredient_category_id");
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
