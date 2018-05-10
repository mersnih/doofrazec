using Ecom.DataModel;
using Ecom.Model;
using Ecom.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;


namespace Ecom.View
{
    /// <summary>
    /// Logique d'interaction pour Test.xaml
    /// </summary>
    public partial class Commandes : UserControl
    {
        ModelCezar db;
        CommandesViewModel cmd;
        ObservableCollection<Cart> orderList = new ObservableCollection<Cart>();
        ObservableCollection<Cart> commandDetailList = new ObservableCollection<Cart>();

        CartViewModel cvm = new CartViewModel();
        public Commandes()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            db = new ModelCezar();
            OrderList oList = new OrderList();
            lv_OrdersList.ItemsSource = oList.GetNotPayedOrderList();    
        }

        private void BackToCaisse(object sender, RoutedEventArgs e)
        {
            try
            {
            var ViewModel = (NavigationViewModel)DataContext;
   
            if (ViewModel.ListeCommand.CanExecute(null))
                ViewModel.ListeCommand.Execute(null);
            }
            catch
            {

            }

        }

        private void OnSelectionCommand(object sender, SelectionChangedEventArgs e)
        {

            cmd = new CommandesViewModel();
            var liste = (Cart)lv_OrdersList.SelectedItem;
            if (liste != null)
            {
                int id  = liste.OrderId;

                lv_commandDetail.ItemsSource = cmd.GetOrderDetail(id);
     
            }
        }

        private void lv_commandDetail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           
        }
    }
}
