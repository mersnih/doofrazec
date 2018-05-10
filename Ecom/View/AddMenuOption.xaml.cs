using Ecom.DataModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddMenuOption.xaml
    /// </summary>
    public partial class AddMenuOption : UserControl
    {
        ModelCezar db;
        public AddMenuOption()
        {
            InitializeComponent();
            db = new ModelCezar();
            lv_items.ItemsSource = db.ITEM.ToList(); 
        }


        private void OnCLickAddMenuOption(object sender, RoutedEventArgs e)
        {
            OPTION_CHOIX_MENU ocm = new OPTION_CHOIX_MENU();
            var idItem = (lv_items.SelectedItems);
            int count = idItem.Count;

            ocm.option_choix_menu_title = tb_nameMenuOption.Text;
            db.OPTION_CHOIX_MENU.Add(ocm);
            for (int i = 0; i < count; i++)
            {
                var item = (ITEM)idItem[i];

                ITEM_OPTION_MENU iom = new ITEM_OPTION_MENU();
                iom.id_option_choix_menu = ocm.id_option_choix_menu;
                iom.id_item = item.id_item;
                iom.item_option_menu_quantity = 1;

                db.ITEM_OPTION_MENU.Add(iom);

            }
            db.SaveChanges();
        }
    }
}
