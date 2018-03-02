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
        int idItemCat = 0;
        int idItem = 0;
        string nameItemCat;
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
                idItemCat= liste.Id;
                nameItemCat = liste.Title;
                lv_items.ItemsSource = mg.GetItemsByCat(idItemCat);                    
            }
        }

        private void showItemsOptionsOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mg = new ManagementModel();
            var liste = (ItemModel)lv_items.SelectedItem;
            if (liste != null)
            {
                idItem = liste.Id;
                lv_itemsOptions.ItemsSource = mg.GetItemsOptionsByItem(idItem);
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
            if(idItemCat > 0)
            {
                DialogHost.Show(new CUItem(idItemCat, nameItemCat), "RootDialog");
            }
            else
            {
                DialogHost.Show(new Message()
                {
                    message_tb = { Text = "Veuillez selectionner une catégorie d'abord" }
                }, "RootDialog");
            }
 
        }
    }
}
