using Ecom.DataModel;
using Ecom.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ecom.View
{
    /// <summary>
    /// Interaction logic for Caisse.xaml
    /// </summary>
    public partial class Caisse : UserControl
    {
        ModelCezar db;
        // Liste des collections 
        ObservableCollection<ITEM> listItems = new ObservableCollection<ITEM>();
        ObservableCollection<CATEGORY> listCategories = new ObservableCollection<CATEGORY>();
        ObservableCollection<Cart> cartList = new ObservableCollection<Cart>();

        public double totalPrice;

        public Caisse()
        {
            InitializeComponent();
            db = new ModelCezar();
            totalPrice = 0;
            lv_cartItems.ItemsSource = cartList;
            
            var categoryQuery = db.CATEGORY.ToList();
            foreach (CATEGORY cat in categoryQuery)
            {
                listCategories.Add(new CATEGORY
                {
                    id_category = cat.id_category,
                    category_title = cat.category_title,
                    category_description = cat.category_description
                });
            }
            icCat.ItemsSource = listCategories;
        }
        // Affiche les articles par catégorie 
        private void getItemsByCatId(object sender, RoutedEventArgs e)
        {
            CATEGORY cat = new CATEGORY();
            listItems = new ObservableCollection<ITEM>();
            cat = ((Button)sender).Tag as CATEGORY;
            if(cat != null)
            {
                var itemQuery = db.ITEM.Where(i => i.id_category== cat.id_category).ToList();
                foreach (ITEM item in itemQuery)
                {
                    listItems.Add(new ITEM
                    {
                        id_item = item.id_item,
                        item_title = item.item_title,
                        item_price = item.item_price
                    });
                }
                icItem.ItemsSource = listItems;
            }
        }
        // Ajout d'un article au panier
        private void addToCart(object sender, RoutedEventArgs e)
        {
            ITEM item = new ITEM();
            double priceSum = 0;
            item = ((Button)sender).Tag as ITEM;

            DialogHost.Show(new MeatChoice(item.id_item), "RootDialog");


            cartList.Add(new Cart {

                ItemQuantity = 1,
                ItemId = item.id_item,
                ItemTitle = item.item_title,
                ItemPrice = (double)item.item_price,
                ItemPriceTxt = item.item_price + "€"

            });

            foreach(Cart itm in cartList)
            {
                priceSum = priceSum + itm.ItemPrice;         
            }
            totalPrice = priceSum;
            tb_total.Text = totalPrice + "€";
        }

        //Suppression d'un article du panier 
        private void deleteItemFromCart(object sender, RoutedEventArgs e)
        {
            var item = ((ListViewItem)lv_cartItems.ContainerFromElement((Button)sender)).Content;
            Cart cart = (Cart)item;
            totalPrice = totalPrice - cart.ItemPrice;
            cartList.Remove(cart);
            tb_total.Text = totalPrice + "€";        
        }
    }
}
