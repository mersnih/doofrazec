using Ecom.DataModel;
using Ecom.Model;
using Ecom.ViewModel;
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
    /// Logique d'interaction pour Test.xaml
    /// </summary>
    public partial class Commandes : UserControl
    {
        ModelCezar db;
        ObservableCollection<Cart> orderList = new ObservableCollection<Cart>();

        CartViewModel cvm = new CartViewModel();
        public Commandes()
        {
            InitializeComponent();
            db = new ModelCezar();
            OrderList oList = new OrderList();
            lv_OrdersList.ItemsSource =  oList.GetOrderList();

            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            OrderList oList = new OrderList();
            lv_OrdersList.ItemsSource = oList.GetOrderList();
        }
    }
}
