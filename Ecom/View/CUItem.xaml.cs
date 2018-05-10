using Ecom.DataModel;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Ecom.Tools;
using System.Threading;
using Ecom.Model;
using Ecom.ViewModel;

namespace Ecom.View
{
    /// <summary>
    /// Logique d'interaction pour CUItem.xaml
    /// </summary>
    public partial class CUItem : UserControl
    {
        ModelCezar db;
        ResultViewModel rvm = new ResultViewModel();
        ItemModel itemModelLocal;
        Object color;
        int IDCat = 0;
        string TitleCat;
        int IDItem = 0;
        int IDSource = 0;

        private int _noOfErrorsOnScreen;
        private Errors _errors;

        //Constructeur paramétré, id est l'id de la catégorie et le title est le bom de la catégorie
        public CUItem(int idCat, string titleCat, int source)
        {
            // source : 1 = Produit, 2 = Ingrédient
            InitializeComponent();
            db = new ModelCezar();
            // Initialisation des erreurs
            _errors = new Errors();
            _noOfErrorsOnScreen = 0;
            gridForms.DataContext = _errors;

            // Recuperer l'id de la catégorie dans une variable globale
            IDCat = idCat;
            TitleCat = titleCat;
            IDSource = source;

            //Publication de la collection dans la vue 
            tb_messageItem.Visibility = Visibility.Visible;
            tb_messageItem.Text = "Ajouter " + TitleCat;
            if(source == 1)
            icColorsPalette.ItemsSource = GetPalette();
            
          
        }
        public CUItem(ItemModel itemModel, int source) //  For update
        {
            InitializeComponent();
            IDSource = source;
            db = new ModelCezar();
            // Initialisation des erreurs
            itemModelLocal = itemModel;
            _noOfErrorsOnScreen = 0;
            this.Loaded += new RoutedEventHandler(CUItem_Loaded);
            _errors = new Errors();
            gridForms.DataContext = _errors;
        }

        private void CUItem_Loaded(object sender, RoutedEventArgs e)
        {
            //Recuperer l'id de l'article 
            IDItem = itemModelLocal.Id;
            //tb_name.Text = itemModel.Title.ToString();
            tb_name.Text = itemModelLocal.Title;
            if (itemModelLocal.Description != null)
            {
                tb_name.Text = itemModelLocal.Description.ToString();
            }

            tb_price.Text = itemModelLocal.Price.ToString();
            tg_actif.IsChecked = itemModelLocal.Actif;

            tg_cooked.IsChecked = itemModelLocal.Cooked;

            //
            icColorsPalette.ItemsSource = GetPalette();
            //int count = icColorsPalette.Items.Count;
            foreach (Object itm in icColorsPalette.Items)
            {

                ToggleButton tb = FindItemControl(icColorsPalette, "bt_color", itm) as ToggleButton;
                string[] color = itemModelLocal.Color.Split('#');
                string colorString = color[1].ToUpper();
                if (tb.Background.ToString().Contains(colorString))
                {
                    tb.IsChecked = true;
                }
                else
                {
                    tb.IsChecked = false;
                }
            }

            // foreach(var item in icColorsPalette.Items)
            //{


            //}


            bt_addItem.Content = "Modifier";
        }



        //

        private object FindItemControl(ItemsControl itemsControl, string controlName, object item)
        {
            ContentPresenter container = itemsControl.ItemContainerGenerator.ContainerFromItem(item) as ContentPresenter;
            container.ApplyTemplate();
            return container.ContentTemplate.FindName(controlName, container);
        }


        //



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

        //Ajout/Modification d'un article 
        private async void OnCLickAddNewItem(object sender, RoutedEventArgs e)
        {
            // A chaque "Click" sur le bouton ajouter, j'initialise les message 
            tb_messageItem.Text = "";
            string message = ""; // Message de resultat 
            string infoMessage = "";

            if (IDSource == 1) //  Produit
            {
                try
                {
                    ITEM item = new ITEM();
                    // If update
                    if (IDItem > 0)
                    {
                        infoMessage = "modification";
                        ITEM itm = (from it in db.ITEM where it.id_item == IDItem select it).Single();

                        itm.item_title = tb_name.Text;
                        itm.item_decription = tb_description.Text;
                        
                        if (!string.IsNullOrEmpty(tb_price.Text))
                        {
                            itm.item_price = Decimal.Parse(tb_price.Text);
                        }
                        if (!string.IsNullOrEmpty(tb_pricePromo.Text))
                        {
                            itm.item_promotion_price = Decimal.Parse(tb_pricePromo.Text);
                        }
                        if (color != null)
                        {
                            itm.item_button_color = color.ToString();
                        }
                        itm.actif = (bool)tg_actif.IsChecked;
                        itm.cooked = (bool)tg_cooked.IsChecked;
                        db.SaveChanges();


                        message = "Le produit a été ajouté avec succès ";
                        rvm.Result = true; 

                        _errors = new Errors();
                        gridForms.DataContext = _errors;

                        tb_messageItem.Visibility = Visibility.Visible;
                        icon_messageItem.Visibility = Visibility.Visible;
                        tb_messageItem.Text = message;
                        tb_messageItem.Foreground = Brushes.DarkGreen;
                        icon_messageItem.Kind = PackIconKind.CheckCircleOutline;
                        icon_messageItem.Foreground = Brushes.DarkGreen;

      
              
                    } 
                    else// If add 
                    {
                        infoMessage = "ajout";
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
                        if (!string.IsNullOrEmpty(tb_pricePromo.Text))
                        {
                            item.item_promotion_price = Decimal.Parse(tb_pricePromo.Text);
                        }
                        if (color != null)
                        {
                            item.item_button_color = color.ToString();
                        }
                        if(color == null)
                        {
                            item.item_button_color = "#9b59b6";
                        }
                        item.actif = (bool)tg_actif.IsChecked;
                        item.cooked = (bool)tg_cooked.IsChecked;
                        item.id_category = IDCat;
                        db.ITEM.Add(item);
                        db.SaveChanges();
       

                        _errors = new Errors();
                        gridForms.DataContext = _errors;

                        tb_messageItem.Visibility = Visibility.Visible;
                        icon_messageItem.Visibility = Visibility.Visible;
                        tb_messageItem.Text = message;
                        tb_messageItem.Foreground = Brushes.DarkGreen;
                        icon_messageItem.Kind = PackIconKind.CheckCircleOutline;
                        icon_messageItem.Foreground = Brushes.DarkGreen;

                        message = "Le produit a été ajouté avec succès ";
                        rvm.Result = true;
                    }
                }
                catch (Exception ex)
                {

                    tb_messageItem.Visibility = Visibility.Visible;
                    icon_messageItem.Visibility = Visibility.Visible;
                    tb_messageItem.Text = "Echec " + infoMessage + " de l'article " + ex.Message;
                    tb_messageItem.Foreground = Brushes.DarkRed;
                    icon_messageItem.Kind = PackIconKind.AlertCircleOutline;
                    icon_messageItem.Foreground = Brushes.DarkRed;
                    rvm.Result = false;
                }

            }
            if (IDSource == 2) // INGREDIENT
            {
                try
                {
                    INGREDIENT item = new INGREDIENT();
                    // If update
                    if (IDItem > 0)
                    {
                        infoMessage = "modification";
                        INGREDIENT itm = (from it in db.INGREDIENT where it.id_ingredient == IDItem select it).Single();

                        itm.ingredient_title = tb_name.Text;
                        itm.ingredient_description = tb_description.Text;
                        if (!string.IsNullOrEmpty(tb_price.Text))
                        {
                            itm.ingredient_price = Decimal.Parse(tb_price.Text);
                        }

                        itm.actif = (bool)tg_actif.IsChecked;
                        db.SaveChanges();
                        message = "l'ingrédient a été modifié avec succès ";
                        rvm.Result = true;
                    } 
                    else// If add 
                    {
                        infoMessage = "ajout";
                        if (!string.IsNullOrEmpty(tb_name.Text)) // Obligatoire
                        {
                            item.ingredient_title = tb_name.Text;
                        }
                        else
                        {
                            return;
                        }
                        if (!string.IsNullOrEmpty(tb_description.Text))
                        {
                            item.ingredient_description = tb_description.Text;
                        }
                        if (!string.IsNullOrEmpty(tb_price.Text))// Obligatoire
                        {
                            item.ingredient_price = Decimal.Parse(tb_price.Text);
                        }
                        else
                        {
                            return;
                        }

                        item.actif = (bool)tg_actif.IsChecked;
                        item.id_category_ingredient = IDCat;
                        db.INGREDIENT.Add(item);
                        db.SaveChanges();
           

                        _errors = new Errors();
                        gridForms.DataContext = _errors;

                        tb_messageItem.Visibility = Visibility.Visible;
                        icon_messageItem.Visibility = Visibility.Visible;
                        tb_messageItem.Text = message;
                        tb_messageItem.Foreground = Brushes.DarkGreen;
                        icon_messageItem.Kind = PackIconKind.CheckCircleOutline;
                        icon_messageItem.Foreground = Brushes.DarkGreen;

                        message = "L'ingrédient a été ajouté avec succès ";
                        rvm.Result = true;
                    }
                }
                catch (Exception ex)
                {
            
                    tb_messageItem.Visibility = Visibility.Visible;
                    icon_messageItem.Visibility = Visibility.Visible;
                    tb_messageItem.Text = "Echec " + infoMessage + " de l'article " + ex.Message;
                    tb_messageItem.Foreground = Brushes.DarkRed;
                    icon_messageItem.Kind = PackIconKind.AlertCircleOutline;
                    icon_messageItem.Foreground = Brushes.DarkRed;
                    rvm.Result = false;
                }
            }

            //try
            //{
            //    // If update
            //    if (IDItem > 0)
            //    {
            //        infoMessage = "modification";
            //        ITEM itm = (from it in db.ITEM where it.id_item == IDItem select it).Single();

            //        itm.item_title = tb_name.Text;
            //        itm.item_decription = tb_description.Text;
            //        if (!string.IsNullOrEmpty(tb_price.Text))
            //        {
            //            itm.item_price = Decimal.Parse(tb_price.Text);
            //        }
            //        if (!string.IsNullOrEmpty(tb_pricePromo.Text))
            //        {
            //            itm.item_promotion_price = Decimal.Parse(tb_pricePromo.Text);
            //        }
            //        itm.item_button_color = color.ToString();
            //        itm.actif = (bool)tg_actif.IsChecked;
            //        db.SaveChanges();
            //        message = "l'article a été modifié avec succès ";
            //        rvm.Result = true;
            //    } // If add 
            //    else
            //    {

            //    }

            //    // OK => Init UI
            //    _errors = new Errors();
            //    gridForms.DataContext = _errors;

            //    tb_messageItem.Visibility = Visibility.Visible;
            //    icon_messageItem.Visibility = Visibility.Visible;
            //    tb_messageItem.Text = message;
            //    tb_messageItem.Foreground = Brushes.DarkGreen;
            //    icon_messageItem.Kind = PackIconKind.CheckCircleOutline;
            //    icon_messageItem.Foreground = Brushes.DarkGreen;
            //}
            //catch (Exception ex)
            //{
            //    tb_messageItem.Visibility = Visibility.Visible;
            //    icon_messageItem.Visibility = Visibility.Visible;
            //    tb_messageItem.Text = "Echec " + infoMessage + " de l'article " + ex.Message;
            //    tb_messageItem.Foreground = Brushes.DarkRed;
            //    icon_messageItem.Kind = PackIconKind.AlertCircleOutline;
            //    icon_messageItem.Foreground = Brushes.DarkRed;
            //    rvm.Result = false;
            //}

            await Task.Run(() =>
            {
                Thread.Sleep(2000);
            });


            icon_messageItem.Visibility = Visibility.Collapsed;
            tb_messageItem.Text = "Ajouter " + TitleCat;
            tb_messageItem.Foreground = Brushes.DarkGreen;
            icon_messageItem.Kind = PackIconKind.AccessPoint;
            icon_messageItem.Foreground = Brushes.DarkGreen;

        }

        private void OnSelectColor(object sender, RoutedEventArgs e)
        {
            color = ((ToggleButton)sender).Background;
        }
        #endregion

        #region METHODS 
        public static ObservableCollection<Color> GetPalette()
        {
            // Création d'une collection de couleur
            ObservableCollection<Color> colorList;
            colorList = new ObservableCollection<Color>();
            colorList.Add(new Color { Name = "Turquoise", Code = "#1abc9c" });
            colorList.Add(new Color { Name = "Nephritis", Code = "#27ae60" });
            colorList.Add(new Color { Name = "Belize Hole", Code = "#2980b9" });
            colorList.Add(new Color { Name = "Amethist", Code = "#9b59b6" });
            colorList.Add(new Color { Name = "Wet Asphalt", Code = "#34495e" });
            colorList.Add(new Color { Name = "Carrot", Code = "#e67e22" });
            colorList.Add(new Color { Name = "Alizarin", Code = "#e74c3c" });
            colorList.Add(new Color { Name = "Orange", Code = "#f39c12" });
            return colorList;
        }

        #endregion
    }
    public class Color
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
