using Ecom.DataModel;
using Ecom.Model;
using Ecom.Tools;
using Ecom.ViewModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

            this.Loaded += new RoutedEventHandler(PosLoaded);
            this.DataContext = new NavigationViewModel();
        }

        private void PosLoaded(object sender, RoutedEventArgs e)
        {
            if (Network.BddConnection())
            {
                try
                {
                    db = new ModelCezar();
                    cvm = new CartViewModel();
                    cvm.TotalPrice = 0.00;
                    cvm.TotalRestPrice = 0.00;
                    cvm.TotalPayed = 0.00;
                    listCategories.Clear();
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
                catch (Exception ex)
                {
                    DialogHost.Show(new Message()
                    {
                        message_tb = { Text = "Problème réseau " + ex.Message }
                    }, "RootDialog");
                }
            }
            else
            {
                DialogHost.Show(new Message()
                {
                    message_tb = { Text = "Connexion imossible" }
                }, "RootDialog");
            }           
        }

        // Affiche les articles par catégorie 
        private void getItemsByCatId(object sender, RoutedEventArgs e)
        {
            CATEGORY cat = new CATEGORY();
            listItems = new ObservableCollection<ITEM>();

            Button bt = sender as Button;
            int index = (int)bt.Tag;
            cat = icCat.Items[index] as CATEGORY;

           // cat = ((Button)sender).Tag as CATEGORY;
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
                        item_button_color = item.item_button_color,
                        cooked = item.cooked
                    });
                }
                icItem.ItemsSource = listItems;

                int count = 0;
                foreach (Object itm in icCat.Items)
                {

                    Button happyButton = FindItemControl(icCat, "getItemsBtn", itm) as Button;
                    Label happyLabel = FindItemControl(icCat, "lb_getItems", itm) as Label;
                    if (count != index)
                    {

                     
                         happyButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#BE90D4"));
                         happyButton.BorderBrush = Brushes.Transparent;
                         happyLabel.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                    }
                    else
                    {

                        happyButton.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#87D37C"));
                        happyButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9B59B6"));
                        happyLabel.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ffffff"));
                    }
                    count = count+ 1;

                }
            }

        }
        private object FindItemControl(ItemsControl itemsControl, string controlName, object item)
        {
            ContentPresenter container = itemsControl.ItemContainerGenerator.ContainerFromItem(item) as ContentPresenter;
            container.ApplyTemplate();
            return container.ContentTemplate.FindName(controlName, container);
        }
        // Ajout d'un article au panier
        private void  addToCart(object sender, RoutedEventArgs e)
        {
            ITEM item = new ITEM();    
            item = ((Button)sender).Tag as ITEM;
            itemTest = item;
            var queryIngCat = (from cat in db.CATEGORY_INGREDIENT.Where(ci => ci.ITEM.Any())
                               from itm in db.ITEM.Where(i => i.CATEGORY_INGREDIENT.Contains(cat) && i.id_item == item.id_item)
                               select cat).ToList();
            if(queryIngCat.Count > 0)
            {
               DialogHost.Show(new ItemOption(item, queryIngCat), "RootDialog", onCLosingDialog);
               
            }
            else
            {
                var it = cvm.Cart.FirstOrDefault(i => i.ItemId == item.id_item);
                if(it != null)
                {                   
                    it.ItemQuantity = it.ItemQuantity + 1;
                  //  it.ItemPriceWithoutSupp = it.ItemPriceWithoutSupp + it.ItemPrice;
                  //  it.ItemPrice += it.ItemPrice;
                }
                else
                {
                    cvm.Cart.Add(new Cart
                    {
                        ItemQuantity = 1,
                        ItemId = item.id_item,
                        ItemTitle = item.item_title,
                        ItemPriceWithoutSupp = (double)item.item_price,
                        Cooked = item.cooked,
                        SuppPrice = 0,
                    });
                }
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

                //Detect menu
              

            }

         
            //foreach (CATEGORY_INGREDIENT list in queryIngCat)
            //{
            //    int id = list.id_category_ingredient;
            //    DialogHost.Show(new ItemOption(item, id), "RootDialog", onCLosingDialog);
            //}
        }

        private void DetectMenu()
        {
            // Il me faut un indice qui, grace a lui, je peux savoir que j'ai une composition de menu 
            // Le simple est de creer un boolén qui par defaut est actif
            // Il suffit q'une option ne contient pas un élément avec la quantité qu'il faut l'indice passe en inactif 


            bool indice = true;
            MENU detectedMenu = new MENU();
            // init tag in model cart
            foreach (var c in cvm.Cart)
            {
                c.Tag = false;
            }

            // Je recupere le panier 
            var cartList = cvm.Cart;

            // je recupère la liste des menus
            var menu = db.MENU.ToList();

            // Je parcoure la liste des menus // un par un 
            foreach(var menuItem in menu)
            {
                indice = true;
                detectedMenu = menuItem;
                // Je verifie si le produit principal du menu est présent sur la carte 
                bool contain = cartList.Where(c => c.Tag != true).Select(c => c.ItemId).Contains(menuItem.id_item);
                if (contain)
                {
                    var updateCartList = cartList.FirstOrDefault(i => i.ItemId == menuItem.id_item);
                    if (updateCartList != null)
                    {
                        updateCartList.Tag = true;
                        updateCartList.
                    }
                }
                else
                {
                    continue;
                }


                // Je recupère la liste des options 
                var option = menuItem.OPTION_CHOIX_MENU.ToList();
            
                // Je parcoure la liste des options 
                foreach (var optionItem in option)
                {
                    // Dans chaque option je vais chercher la liste des produits en  lien  avec le menu
                    var optionContainer = optionItem.ITEM_OPTION_MENU.ToList();
                   // optionContainer.Add(menuItem.ITEM);
                    HashSet<int> cartHash = new HashSet<int>(cartList.Where(c => c.Tag != true).Select(s => s.ItemId));
                    cartHash.Add(menuItem.id_item);
                    var results2 = optionContainer.Where(m => cartHash.Contains(m.id_item)).ToList();

                    // var cartIDs = cvm.Cart;
                    //  var results = optionContainer.Where(m => cartIDs.Any(z => z.ItemId == m.id_item) );

                    if (results2.Count() > 0)
                    {
                       foreach (var res in results2)
                        {
                            var updateCartList = cartList.FirstOrDefault(i => i.ItemId == res.id_item);
                            if (updateCartList != null)
                            {
                                updateCartList.Tag = true;
                            }  
                        }                             
                    }
                    else
                    {
                        indice = false;
                    }
              
                }
                // Ici je peux tester si indice est actif je recupère le menu en question dans une liste 
                if (indice)
                {
                    MessageBox.Show(detectedMenu.menu_title);
                }
               // Une fois le panier est parcourue entierrement j'affiche cette liste de menu :)
            }
            var test = cartList;
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
                }, "RootDialog");
            }
            
        }

        private void onCLosingSenderOrderDialog(object sender, DialogClosingEventArgs eventArgs)
        {
       
            if(cartList.Count == 0)
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
                cvm.TotalRestPrice = Math.Round((cvm.TotalPrice - cvm.TotalPayed),2);
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
                ObservableCollection<ItemIngredient> listIng = cart.SelectedIngredients;
                var queryIngCat = (from cat in db.CATEGORY_INGREDIENT.Where(ci => ci.ITEM.Any())
                                   from itm in db.ITEM.Where(i => i.CATEGORY_INGREDIENT.Contains(cat) && i.id_item == idItem)
                                   select cat).ToList();
                if (queryIngCat.Count > 0)
                {
                    DialogHost.Show(new ItemOption(cart, idItem, index, queryIngCat, listIng), "RootDialog", onCLosingDialog);

                }
           //     DialogHost.Show(new ItemOption(cart, idItem, index), "RootDialog", onCLosingDialog);
            }
        }

        private void commandPlusOne(object sender, RoutedEventArgs e)
        {
            var ViewModel = (NavigationViewModel)DataContext;

            if (ViewModel.GenCommand.CanExecute(null))
                ViewModel.GenCommand.Execute(null);
            // new Commandes();
        }

        private void DetectMenuClick(object sender, RoutedEventArgs e)
        {
            DetectMenu();
        }
    }
}
