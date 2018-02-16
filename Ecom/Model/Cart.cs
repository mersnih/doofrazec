using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Model
{
    public class Cart : INotifyPropertyChanged
    {
        private int orderId;
        public int OrderId
        {
            get { return orderId; }
            set
            {
                orderId = value;
                NotifyPropertyChanged("OrderId");
            }
        }

        private string orderNumber;
        public string OrderNumber
        {
            get { return orderNumber; }
            set
            {
                orderNumber = value;
                NotifyPropertyChanged("OrderNumber");
            }
        }

        private DateTime orderDate;

        public DateTime OrderDate
        {
            get { return orderDate; }
            set
            {
                orderDate = value;
                NotifyPropertyChanged("OrderDate");
            }
        }

        private string orderType;
        public string OrderType
        {
            get { return orderType; }
            set
            {
                orderType = value;
                NotifyPropertyChanged("OrderType");
            }
        }

        private int itemId;
        public int ItemId
        {
            get { return itemId; }
            set
            {
                itemId = value;
                NotifyPropertyChanged("ItemId");
            }

        }

        private string itemTitle;
        public string ItemTitle
        {
            get { return itemTitle; }
            set
            {
                itemTitle = value;
                NotifyPropertyChanged("ItemTitle");
            }

        }


        private double itemPriceWithoutSupp;
        public double ItemPriceWithoutSupp
        {
            get { return itemPriceWithoutSupp; }
            set
            {
                itemPriceWithoutSupp = value;
                NotifyPropertyChanged("ItemPriceWithoutSupp");
            }

        }
        private double suppPrice;
        public double SuppPrice
        {
            get { return suppPrice; }
            set
            {
                suppPrice = value;
                NotifyPropertyChanged("SuppPrice");
            }

        }

        private double itemPrice;
        public double ItemPrice
        {
            get { return ItemPriceWithoutSupp + SuppPrice; }
            set
            {
                itemPrice = value;
                NotifyPropertyChanged("ItemPrice");
            }

        }

        private string itemPriceTxt;
        public string ItemPriceTxt
        {
            get
            {
                if (string.IsNullOrEmpty(itemPriceTxt))
                {
                    return ItemPrice.ToString() + "€";
                }
                else
                {
                    return itemPriceTxt;
                }
            }
            set
            {
                itemPriceTxt = value;
                NotifyPropertyChanged("ItemPriceTxt");
            }
        }
        private string itemPriceRestTxt;
        public string ItemPriceRestTxt
        {
            get { return itemPriceRestTxt; }
            set
            {
                itemPriceRestTxt = value;
                NotifyPropertyChanged("ItemPriceRestTxt");
            }
        }


        private int itemQuantity;
        public int ItemQuantity
        {
            get { return itemQuantity; }
            set
            {
                itemQuantity = value;
                NotifyPropertyChanged("ItemQuantity");
            }
        }

        private ObservableCollection<ItemIngredient> selectedIngredients;
        public ObservableCollection<ItemIngredient> SelectedIngredients
        {
            get { return selectedIngredients; }
            set
            {
                selectedIngredients = value;
                NotifyPropertyChanged("SelectedIngredients");
            }

        }
        
        
        // Pour les menus 
        private List<int> selectedItems;
        public List<int> SelectedItems
        {
            get { return selectedItems; }
            set
            {
                selectedItems = value;
                NotifyPropertyChanged("SelectedItems");
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
