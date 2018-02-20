using Ecom.DataModel;
using Ecom.Model;
using Ecom.ViewModel;
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
        ObservableCollection<ItemIngredient> reqIngredient = new ObservableCollection<ItemIngredient>();
        ObservableCollection<Payement> listPayement = new ObservableCollection<Payement>();
        List<int> selectedIngredient = new List<int>();
        // Static collections objects 
        CartViewModel cvm { get; set; }

        ITEM itemTest;

        public Caisse()
        {
            InitializeComponent();
            db = new ModelCezar();
            cvm = new CartViewModel();
            cvm.TotalPrice = 0.00;
            cvm.TotalRestPrice = 0.00;
            cvm.TotalPayed = 0.00;

            lv_cartItems.ItemsSource = cartList;
            lb_payement.ItemsSource = listPayement;

            var categoryQuery = db.CATEGORY.ToList();
            foreach (CATEGORY cat in categoryQuery)
            {
                listCategories.Add(new CATEGORY
                {
                    id_category = cat.id_category,
                    category_title = cat.category_title,
                    category_description = cat.category_description,
                    category_button_color = cat.category_button_color
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
                var itemQuery = db.ITEM.Where(i => i.id_category== cat.id_category && i.actif == true).ToList();
                foreach (ITEM item in itemQuery)
                {
                    listItems.Add(new ITEM
                    {
                        id_item = item.id_item,
                        item_title = item.item_title,
                        item_price = item.item_price,
                        item_button_color = item.item_button_color
                    });
                }
                icItem.ItemsSource = listItems;
            }

        }

        // Ajout d'un article au panier
        private void addToCart(object sender, RoutedEventArgs e)
        {
            ITEM item = new ITEM();    
            item = ((Button)sender).Tag as ITEM;

            itemTest = item;
            var queryIngCat = (from cat in db.CATEGORY_INGREDIENT.Where(ci => ci.ITEM.Any())
                               from itm in db.ITEM.Where(i => i.CATEGORY_INGREDIENT.Contains(cat) && i.id_item == item.id_item)
                               select cat).ToList() ;
            if(queryIngCat.Count > 0)
            {
               DialogHost.Show(new ItemOption(item, queryIngCat), "RootDialog", onCLosingDialog);

            }
            else
            {             
                cvm.Cart.Add(new Cart
                {
                    ItemQuantity = 1,
                    ItemId = item.id_item,
                    ItemTitle = item.item_title,
                    ItemPriceWithoutSupp = (double)item.item_price,
                    SuppPrice = 0,
                });

                double totalCartLocal = 0.00;
                cartList = cvm.Cart;
                foreach (Cart itm in cartList)
                {
                    totalCartLocal = totalCartLocal + itm.ItemPrice;
                }
                cvm.TotalPrice = totalCartLocal;
                cvm.TotalRestPrice = cvm.TotalPrice - cvm.TotalPayed;
                tb_total.Text = cvm.TotalPrice + "€";
                tb_totalRest.Text = cvm.TotalRestPrice + "€";
                lv_cartItems.ItemsSource = cvm.Cart;
            }


            //foreach (CATEGORY_INGREDIENT list in queryIngCat)
            //{
            //    int id = list.id_category_ingredient;
            //    DialogHost.Show(new ItemOption(item, id), "RootDialog", onCLosingDialog);
            //}
        }

        private void onCLosingDialog(object sender, DialogClosingEventArgs eventArgs)
        {

            double totalCartLocal = 0.00;
            cartList = cvm.Cart;
            foreach (Cart itm in cartList)
            {
                totalCartLocal = totalCartLocal + itm.ItemPrice;
            }
            cvm.TotalPrice = totalCartLocal;
            cvm.TotalRestPrice = cvm.TotalPrice - cvm.TotalPayed;
            tb_total.Text = cvm.TotalPrice + "€";
            tb_totalRest.Text = cvm.TotalRestPrice + "€";
            lv_cartItems.ItemsSource = cvm.Cart;
        }

        //Suppression d'un article du panier 
        private void deleteItemFromCart(object sender, RoutedEventArgs e)
        {
            var item = ((ListViewItem)lv_cartItems.ContainerFromElement((Button)sender)).Content;
            Cart cart = (Cart)item;

            cvm.TotalPrice = cvm.TotalPrice - cart.ItemPrice;
            cvm.TotalRestPrice = cvm.TotalPrice - cvm.TotalPayed;
    
            tb_total.Text = cvm.TotalPrice + "€";
            tb_totalRest.Text = cvm.TotalRestPrice + "€";

            cartList.Remove(cart);
        }

        //sendOrder ouvre une fenetre de choix ( sur place, à emporter, livraison)
        private void sendOrder(object sender, RoutedEventArgs e)
        {
            // Si la liste des articles n'est pas vide
            if (cartList.Count > 0)
            {
                DialogHost.Show(new OrderSend(cartList, cvm.TotalPrice, cvm.TotalRestPrice), "RootDialog", onCLosingSenderOrderDialog);
            }
            else
            {
                DialogHost.Show(new Message()
                {
                    message_tb = { Text = "La liste est vide"}
                }, "RootDialog", onCLosingDialog);
            }
            
        }

        private void onCLosingSenderOrderDialog(object sender, DialogClosingEventArgs eventArgs)
        {
       
            cvm.TotalPrice = 0;
            cvm.TotalRestPrice = 0;
            cvm.TotalPayed = 0;

            listPayement = cvm.Payement;
            lb_payement.ItemsSource = listPayement;
            foreach (Payement p in listPayement)
            {
                cvm.TotalPayed += p.PayementValue;
            }
            tb_totalRest.Text = cvm.TotalPrice - cvm.TotalPayed + "€";
            tb_total.Text = cvm.TotalPrice + "€";
        }

        private void cashingOrder(object sender, RoutedEventArgs e)
        {
            DialogHost.Show(new Cashing(listPayement, cvm.TotalRestPrice), "RootDialog", onCLosingCashingOrderDialog);
        }

            private void onCLosingCashingOrderDialog(object sender, DialogClosingEventArgs eventArgs)
            {
                double tempCashingClose = 0;      
                listPayement = cvm.Payement;
                lb_payement.ItemsSource = listPayement;
                foreach(Payement p in listPayement)
                {
                     tempCashingClose += p.PayementValue;
                }
               cvm.TotalPayed = tempCashingClose;
                cvm.TotalRestPrice = cvm.TotalPrice - cvm.TotalPayed;
                tb_totalRest.Text = cvm.TotalRestPrice + "€";

             }

        private void discountOrder(object sender, RoutedEventArgs e)
        {

        }

        private void deleteItemFromPayement(object sender, RoutedEventArgs e)
        {
            double tempDelete = 0;
           
            var item = ((ListBoxItem)lb_payement.ContainerFromElement((Button)sender)).Content;
            Payement payement = (Payement)item;
         
             listPayement.Remove(payement);
            foreach (Payement p in listPayement)
            {
                tempDelete += p.PayementValue;
            }
            cvm.TotalPayed = tempDelete;
            cvm.TotalRestPrice = cvm.TotalPrice - cvm.TotalPayed;
            tb_totalRest.Text = cvm.TotalRestPrice + "€";
          
            //   tb_total.Text = totalPrice + "€";
        }

        //private void onSelectedItem(object sender, RoutedEventArgs e)
        //{
        //    Cart item = (Cart)(sender as ListView).SelectedItem;
        //    int index = lv_cartItems.SelectedIndex;
        //    if (item != null)
        //    {
        //        int idItem = item.ItemId;
        //        DialogHost.Show(new ItemOption(item, idItem, index), "RootDialog", onCLosingDialog);
        //    }
          
        //}

        private void editItemFromCart(object sender, RoutedEventArgs e)
        {
            var item = ((ListViewItem)lv_cartItems.ContainerFromElement((Button)sender)).Content;
            int index = lv_cartItems.Items.IndexOf(item);
            Cart cart = (Cart)item;



           // ITEM item = new ITEM();
           // item = ((Button)sender).Tag as ITEM;

           // itemTest = item;
    


            // Cart item = (Cart)(sender as ListView).SelectedItem;

            if (cart != null)
            {
                int idItem = cart.ItemId;
                var queryIngCat = (from cat in db.CATEGORY_INGREDIENT.Where(ci => ci.ITEM.Any())
                                   from itm in db.ITEM.Where(i => i.CATEGORY_INGREDIENT.Contains(cat) && i.id_item == idItem)
                                   select cat).ToList();
                if (queryIngCat.Count > 0)
                {
                    DialogHost.Show(new ItemOption(cart, idItem, index, queryIngCat), "RootDialog", onCLosingDialog);

                }
           //     DialogHost.Show(new ItemOption(cart, idItem, index), "RootDialog", onCLosingDialog);
            }
        }
    }
}
