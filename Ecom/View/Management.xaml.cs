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
    /// Logique d'interaction pour Management.xaml
    /// </summary>
    public partial class Management : UserControl
    {
        ManagementModel mg;

        public Management()
        {
            InitializeComponent();
            mg = new ManagementModel();
            
            lv_itemsCategory.ItemsSource = mg.GetAllCategory();
            lv_ingredientCategory.ItemsSource = mg.GetAllIngredientCat();

        }

        private void showItemsOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mg = new ManagementModel();
            var liste = (CategoryModel)lv_itemsCategory.SelectedItem;
            if (liste != null)
            {
                int id = liste.Id;
                lv_items.ItemsSource = mg.GetItemsByCat(id);                    
            }
        }

        private void showItemsOptionsOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mg = new ManagementModel();
            var liste = (ItemModel)lv_items.SelectedItem;
            if (liste != null)
            {
                int id = liste.Id;
                lv_itemsOptions.ItemsSource = mg.GetItemsOptionsByItem(id);
            }

        }

        private void showIngredientsOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mg = new ManagementModel();
            var liste = (ItemsCategoryModel)lv_ingredientCategory.SelectedItem;
            if (liste != null)
            {
                int id = liste.Id;
                //     lv.ItemsSource = mg.GetItemsOptionsByItem(id);
                lv_ingredient.ItemsSource = mg.GetIngredientByCat(id);
            }
        }

        private void OnClickAddItem(object sender, RoutedEventArgs e)
        {
            DialogHost.Show(new CUItem(), "RootDialog");
        }
    }
}
