using Ecom.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Ecom.ViewModel;
using Ecom.DataModel;
using Ecom.Tools;

namespace Ecom.View
{
    /// <summary>
    /// Logique d'interaction pour Test.xaml
    /// </summary>
    public partial class OrderSend : UserControl
    {
        ModelCezar db = new ModelCezar();
        CartViewModel cvm = new CartViewModel();

        ObservableCollection<Cart> cartList = new ObservableCollection<Cart>();
        OrderViewModel ovm;
        double totalPrice = 0;
        double totalRestPrice = 0;
        public OrderSend(Object cl, double total, double totalRest)
        {
            InitializeComponent();
            cartList = cl as ObservableCollection<Cart>;
            totalPrice = total;
            totalRestPrice = totalRest;
            ovm = new OrderViewModel();
        }

        private void eatin(object sender, RoutedEventArgs e)
        {
            ORDERS orderModel = new ORDERS();
            item_selection itemSelection = new item_selection();
            var testValue = db.ORDERS.OrderByDescending(p => p.orders_number).Where(p => p.id_orders_type == 1).Select(q => q.orders_number).FirstOrDefault();
         

            orderModel.orders_number = Service.GetNextCode("SPL", testValue);
            orderModel.id_orders_status = 1;
            orderModel.id_orders_type = Convert.ToInt32(((Button)sender).Tag);
            orderModel.orders_date = DateTime.Today;
            orderModel.orders_delay_date = null;
            orderModel.orders_price = (decimal)totalPrice; // total commande
            orderModel.orders_leftToPay = (decimal)totalRestPrice; // reste à payer 
                       
            db.ORDERS.Add(orderModel);
            db.SaveChanges();

            int idOrder = orderModel.id_orders;

            foreach(var item in cartList)
            {
                itemSelection = new item_selection();

                itemSelection.id_item = item.ItemId;
                itemSelection.id_orders = idOrder;

                if(item.SelectedIngredients!= null && item.SelectedIngredients.Count > 0)
                {
                    foreach (var subItem in item.SelectedIngredients)
                    {
                        itemSelection.id_ingredient = subItem.IdIngredient;

                        db.item_selection.Add(itemSelection);
                        db.SaveChanges();
                    }
                }
                else
                {
                    db.item_selection.Add(itemSelection);
                    db.SaveChanges();
                }          
            }   
                   
            cartList.Clear();
            cvm.Payement = new ObservableCollection<Payement>();
            cvm.TotalCart = null;
            cvm.TotalRest = null;
            new Commandes();     
        }

        private void takeout(object sender, RoutedEventArgs e)
        {
       
            ORDERS orderModel = new ORDERS();
            item_selection itemSelection = new item_selection();
            var testValue = db.ORDERS.OrderByDescending(p => p.orders_number).Where(p => p.id_orders_type == 2).Select(q => q.orders_number).FirstOrDefault();


            orderModel.orders_number = Service.GetNextCode("EMP", testValue);
            orderModel.id_orders_status = 1;
            orderModel.id_orders_type = Convert.ToInt32(((Button)sender).Tag);
            orderModel.orders_date = DateTime.Today;
            orderModel.orders_delay_date = null;
            orderModel.orders_price = (decimal)totalPrice;
            orderModel.orders_leftToPay = (decimal)totalRestPrice;

            db.ORDERS.Add(orderModel);
            db.SaveChanges();

            int idOrder = orderModel.id_orders;

            foreach (var item in cartList)
            {
                itemSelection = new item_selection();

                itemSelection.id_item = item.ItemId;
                itemSelection.id_orders = idOrder;

                if (item.SelectedIngredients!= null &&  item.SelectedIngredients.Count > 0)
                {
                    foreach (var subItem in item.SelectedIngredients)
                    {
                        itemSelection.id_ingredient = subItem.IdIngredient;

                        db.item_selection.Add(itemSelection);
                        db.SaveChanges();
                    }
                }
                else
                {
                    db.item_selection.Add(itemSelection);
                    db.SaveChanges();
                }
            }

            cartList.Clear();
            cvm.Payement = new ObservableCollection<Payement>();
            cvm.TotalCart = null;
            cvm.TotalRest = null;
            new MainWindowViewModel();
        }
    }
}
