using Ecom.DataModel;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ecom.Tools;
using System.Globalization;
using System.Threading;

namespace Ecom.View
{
    /// <summary>
    /// Logique d'interaction pour CUItem.xaml
    /// </summary>
    public partial class CUItem : UserControl
    {
        ModelCezar db;
        ObservableCollection<Color> colorList;
        Object color;
        int ID;
        string Title;

        private int _noOfErrorsOnScreen;
        private Errors _errors;

        //Constructeur paramétré, id est l'id de l'id de la catégorie
        public CUItem(int id, string title)
        {
            InitializeComponent();
            db = new ModelCezar();
            // Initialisation des erreurs
             _errors = new Errors();
            _noOfErrorsOnScreen = 0;
            gridForms.DataContext = _errors;
    

            // Recuperer l'id de la catégorie dans une variable globale
            ID = id;
            Title = title;
            // Création d'une collection de couleur
            colorList = new ObservableCollection<Color>();
            colorList.Add(new Color { Name = "Turquoise", Code = "#1abc9c" });
            colorList.Add(new Color { Name = "Nephritis", Code = "#27ae60" });
            colorList.Add(new Color { Name = "Belize Hole", Code = "#2980b9" });
            colorList.Add(new Color { Name = "Amethist", Code = "#9b59b6" });
            colorList.Add(new Color { Name = "Wet Asphalt", Code = "#34495e" });
            colorList.Add(new Color { Name = "Carrot", Code = "#e67e22" });
            colorList.Add(new Color { Name = "Alizarin", Code = "#e74c3c" });
            colorList.Add(new Color { Name = "Orange", Code = "#f39c12" });

            //Publication de la collection dans la vue 
            tb_messageItem.Visibility = Visibility.Visible;
            tb_messageItem.Text = "Ajouter "+Title;
            icColorsPalette.ItemsSource = colorList;
           
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

        public class CommandHandler : ICommand
        {
            private System.Action _action;
            private bool _canExecute;
            public CommandHandler(System.Action action, bool canExecute)
            {
                _action = action;
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                _action();
            }
        }

        #endregion

       
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
        #region Actions
        // AJout d'une image
        private void OnClickLoadImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

 
        //Ajout d'un article 
        private async void OnCLickAddNewItem(object sender, RoutedEventArgs e)
        {
            // A chaque "Click" sur le bouton ajouter, j'initialise les message 
            tb_messageItem.Text = "";
           
                ITEM item = new ITEM();
            try
            {
                if (!string.IsNullOrEmpty(tb_name.Text)) // Obligatoire
                {
                    item.item_title = tb_name.Text;
                }
                else
                {
                    return;
                }
                if (!string.IsNullOrEmpty(tb_description.Text))
                {
                    item.item_decription = tb_description.Text;
                }
                if (!string.IsNullOrEmpty(tb_price.Text))// Obligatoire
                {
                    item.item_price = Decimal.Parse(tb_price.Text);
                }
                else
                {
                    return;
                }
                if(!string.IsNullOrEmpty(tb_pricePromo.Text))
                {
                   item.item_promotion_price = Decimal.Parse(tb_pricePromo.Text);
                }
                if (color != null)
                {
                    item.item_button_color = color.ToString();
                }
                item.actif = (bool)tg_actif.IsChecked;
                item.id_category = ID;
         
                    db.ITEM.Add(item);     
                    db.SaveChanges();
                    // OK => Init UI
                    _errors = new Errors();
                    gridForms.DataContext = _errors;

                tb_messageItem.Visibility = Visibility.Visible;
                icon_messageItem.Visibility = Visibility.Visible;
                tb_messageItem.Text = "l'article a été ajouté avec succès";
                tb_messageItem.Foreground = Brushes.DarkGreen;
                icon_messageItem.Kind = PackIconKind.CheckCircleOutline;
                icon_messageItem.Foreground = Brushes.DarkGreen;




            }
            catch(Exception ex)
            {
                tb_messageItem.Visibility = Visibility.Visible;
                icon_messageItem.Visibility = Visibility.Visible;
                tb_messageItem.Text = "Echec d'ajout de l'article " + ex.Message;
                tb_messageItem.Foreground = Brushes.DarkRed;
                icon_messageItem.Kind = PackIconKind.AlertCircleOutline;
                icon_messageItem.Foreground = Brushes.DarkRed;
            }

            await Task.Run(() =>
            {
                Thread.Sleep(5000);

            });

          
            icon_messageItem.Visibility = Visibility.Collapsed;
            tb_messageItem.Text = "Ajouter "+Title;
            tb_messageItem.Foreground = Brushes.DarkGreen;
            icon_messageItem.Kind = PackIconKind.AccessPoint;
            icon_messageItem.Foreground = Brushes.DarkGreen;

        }

        private void OnSelectColor(object sender, RoutedEventArgs e)
        {
            color = ((ToggleButton)sender).Tag;       
        }
        #endregion

    }
    public class Color
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
