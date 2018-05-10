using Ecom.DataModel;
using Ecom.Model;
using Ecom.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour CUMenu.xaml
    /// </summary>
    public partial class CUMenu : UserControl
    {


        private int _noOfErrorsOnScreen;
        private Errors _errors;
        ModelCezar db;

        public CUMenu()
        {
            InitializeComponent();
            db = new ModelCezar();
        
            _errors = new Errors();
            _noOfErrorsOnScreen = 0;
            gridMenuCrud.DataContext = _errors;

            lv_items.ItemsSource = db.ITEM.ToList();
            lv_options.ItemsSource = db.OPTION_CHOIX_MENU.ToList();
        }

        private void OnClickLoadMenuImage(object sender, RoutedEventArgs e)
        {

        }

        #region Validation du formulaire - vérification des erreurs

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {

            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;

        }


        // Can 
        private void _CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (_noOfErrorsOnScreen == 0)
            {
                e.CanExecute = true; /* _noOfErrorsOnScreen == 0;*/
                e.Handled = true;
            }
        }
        private void _Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Errors err = gridForms.DataContext as Errors;
            //// write code here to add Customer

            //// reset UI
            //_errors = new Errors();
            gridForms.DataContext = _errors;

            e.Handled = true;
        }

        private void CheckWiteSpace(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
        private void NumericCheck(object sender, TextCompositionEventArgs e)
        {
            // Autorise que la saisie des nombres, des nombre à virgules (10,00) 
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[,]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        #endregion

        private void OnCLickAddNewItem(object sender, RoutedEventArgs e)
        {
            if(lv_items.SelectedItem != null)
            {
                ITEM item = lv_items.SelectedItem  as ITEM;
                MENU menu = new MENU();

                menu.menu_title = tb_MenuName.Text;
                menu.menu_price = Decimal.Parse(tb_MenuPrice.Text);
                menu.actif = true;
                menu.id_item = item.id_item;

                var idOptionChoixMenu = lv_options.SelectedItems;
                int count = idOptionChoixMenu.Count;
                for (int i = 0; i< count; i++)
                {
                    var result = (OPTION_CHOIX_MENU)idOptionChoixMenu[i];
                    menu.OPTION_CHOIX_MENU.Add(result);        
                }
                db.MENU.Add(menu);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Selectionnez un article");
            }
        }
    }
}
