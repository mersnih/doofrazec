using Ecom.DataModel;
using Ecom.Model;
using Ecom.ViewModel;
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
        ModelCezar db = new ModelCezar();
        ResultViewModel rvm = new ResultViewModel();
        ManagementModel mg;
        int idItemCat = 0;
        int idItem = 0;
        string nameItemCat;
        #region CONSTRUCTEURS
        public Management()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(ManagementLoaded);
        }

        private void ManagementLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                mg = new ManagementModel();
                lv_itemsCategory.ItemsSource = mg.GetAllCategory();
                lv_ingredientCategory.ItemsSource = mg.GetAllIngredientCat();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion


        // On select category show list of items 
        private void showItemsOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mg = new ManagementModel();
            var liste = (CategoryModel)lv_itemsCategory.SelectedItem;
            if (liste != null)
            {
                idItemCat = liste.Id;
                nameItemCat = liste.Title;
                lv_items.ItemsSource = mg.GetItemsByCat(idItemCat);
                lv_itemsOptions.ItemsSource = null;
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
        #region ITEMS
        /// <summary>
        /// Ajout d'un nouvel article
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void OnClickAddItem(object sender, RoutedEventArgs e)
        {
            if (idItemCat > 0)
            {
                DialogHost.Show(new CUItem(idItemCat, nameItemCat, 1), "RootDialog", OnClosingAddItem);
            }
            else
            {
                DialogHost.Show(new Message()
                {
                    message_tb = { Text = "Veuillez selectionner une catégorie d'abord" }
                }, "RootDialog");
            }
        }

        private void OnClosingAddItem(object sender, DialogClosingEventArgs eventArgs)
        {
            if (rvm.Result)
            {
                try
                {
                    var liste = (CategoryModel)lv_itemsCategory.SelectedItem;
                    if (liste != null)
                        lv_items.ItemsSource = mg.GetItemsByCat(liste.Id);
                }
                catch
                {

                }

            }
        }

        /// <summary>
        /// Modification de l'article
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void OnClickEditItem(object sender, RoutedEventArgs e)
        {
            // le Sender est un bouton
            var item = (ItemModel)((ListViewItem)lv_items.ContainerFromElement((Button)sender)).Content;
            if (item != null)
            {

                DialogHost.Show(new CUItem(item), "RootDialog", OnClosingEditItem);
            }
        }
        private void OnClosingEditItem(object sender, DialogClosingEventArgs eventArgs)
        {
            if (rvm.Result)
            {
                try
                {
                    var liste = (CategoryModel)lv_itemsCategory.SelectedItem;
                    if (liste != null)
                        lv_items.ItemsSource = mg.GetItemsByCat(liste.Id);
                }
                catch
                {

                }

            }
        }




        /// <summary>
        /// Suppression del'article
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickDeleteItem(object sender, RoutedEventArgs e)
        {
            // the sender is a button

            try
            {
                var item = (ItemModel)((ListViewItem)lv_items.ContainerFromElement((Button)sender)).Content;
                var it = db.ITEM.FirstOrDefault(i => i.id_item == item.Id);
                db.ITEM.Remove(it);
                db.SaveChanges();
                try
                {
                    var liste = (CategoryModel)lv_itemsCategory.SelectedItem;
                    if (liste != null)
                        lv_items.ItemsSource = mg.GetItemsByCat(liste.Id);
                }
                catch
                {

                }
            }
            catch (Exception ex)
            {
                DialogHost.Show(new Message()
                {
                    message_tb = { Text = "Supression impossible, vérifiez les affectations" }
                }, "RootDialog");
            }
        }
        #endregion

        private void OnClickAffectOptionToItem(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = (ItemModel)lv_items.SelectedItem;
                if (item != null)
                {
                    DialogHost.Show(new IngredientCategoryList(item.Id), "RootDialog", OnClosingAffectOptionToItem);
                }
                else
                {
                    DialogHost.Show(new Message()
                    {
                        message_tb = { Text = "Veuillez selectionner un article" }
                    }, "RootDialog");
                }
            }
            catch
            {

            }
        }

        private  void OnClosingAffectOptionToItem(object sender, DialogClosingEventArgs eventArgs)
        {
            if (rvm.Result)
            {
                try
                {
                    var liste = (ItemModel)lv_items.SelectedItem;
                    if (liste != null)
                        lv_itemsOptions.ItemsSource = mg.GetItemsOptionsByItem(liste.Id);

                }
                catch(Exception ex)
                {
                  
                }        
            }
        }


        private void OnClickEditIngCat(object sender, RoutedEventArgs e)
        {

        }

        private void OnClickDeleteIngCat(object sender, RoutedEventArgs e)
        {

            try
            {
                var item = (ItemsCategoryModel)((ListViewItem)lv_ingredientCategory.ContainerFromElement((Button)sender)).Content;
                var it = db.CATEGORY_INGREDIENT.Where(i => i.id_category_ingredient == item.Id).Single();
                db.CATEGORY_INGREDIENT.Remove(it);
                db.SaveChanges();
                mg = new ManagementModel();
                lv_ingredientCategory.ItemsSource = mg.GetAllIngredientCat();
                DialogHost.Show(new Message()
                {
                    message_tb = { Text = "Catégorie supprimée avec succès" }
                }, "RootDialog");

            }
            catch (Exception ex)
            {
                DialogHost.Show(new Message()
                {
                    message_tb = { Text = "Impossible de supprimer la catégorie " + ex.Message }
                }, "RootDialog");
            }
        }

        private void OnClickAddIngCat(object sender, RoutedEventArgs e)
        {
            mg = new ManagementModel();

            DialogHost.Show(new CUCat(2), "RootDialog", null, OnCloseAddIngCat);

        }

        private void OnCloseAddIngCat(object sender, DialogClosingEventArgs eventArgs)
        {
            lv_ingredientCategory.ItemsSource = mg.GetAllIngredientCat();
        }
        // Suppression d'une option
        private void OnClickDeleteOption(object sender, RoutedEventArgs e)
        {
            try
            {
                mg = new ManagementModel();
                ModelCezar db = new ModelCezar();
                var itm = (ItemModel)lv_items.SelectedItem;
                var selectedOption = (ItemsCategoryModel)((ListViewItem)lv_itemsOptions.ContainerFromElement((Button)sender)).Content;
                var item = db.ITEM.FirstOrDefault(it => it.id_item == idItem);
                var categoryIngredient = db.CATEGORY_INGREDIENT.FirstOrDefault(c => c.id_category_ingredient == selectedOption.Id);

                item.CATEGORY_INGREDIENT.Remove(categoryIngredient);
                db.SaveChanges();

                lv_itemsOptions.ItemsSource = mg.GetItemsOptionsByItem(itm.Id);


            }
            catch (Exception ex)
            {
                DialogHost.Show(new Message()
                {
                    message_tb = { Text = "Suppression impossible" }
                }, "RootDialog");
            }

        }

        private void OnClickAddIngredientItem(object sender, RoutedEventArgs e)
        {
            try
            {
                var selecetdIngredientCat = (ItemsCategoryModel)lv_ingredientCategory.SelectedItem;
                if (selecetdIngredientCat != null)
                {
                    // Appel de l'interface d'ajout - identique à l'interface des articles 
                    DialogHost.Show(new CUItem(selecetdIngredientCat.Id, selecetdIngredientCat.Title, 2), "RootDialog", OnClosingAddIngredientItem);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void OnClosingAddIngredientItem(object sender, DialogClosingEventArgs eventArgs)
        {
            if (rvm.Result)
            {
                try
                {
                    var liste = (ItemsCategoryModel)lv_ingredientCategory.SelectedItem;
                    if (liste != null)
                        lv_ingredient.ItemsSource = mg.GetIngredientByCat(liste.Id);

                }
                catch (Exception ex)
                {

                }
            }
        }

        private void OnClickAddItemCat(object sender, RoutedEventArgs e)
        {
            DialogHost.Show(new CUCat(1), "RootDialog", null, OnCloseAddItemCat);
        }

        private void OnCloseAddItemCat(object sender, DialogClosingEventArgs eventArgs)
        {
            mg = new ManagementModel();
            lv_itemsCategory.ItemsSource = mg.GetAllCategory();
        }

        // Supprimer une catégorie de produit/article
        private void OnClickDeleteItemCat(object sender, RoutedEventArgs e)
        {
            try
            {
                mg = new ManagementModel();

                var itemCat = (CategoryModel)((ListViewItem)lv_itemsCategory.ContainerFromElement((Button)sender)).Content;
                var it = db.CATEGORY.FirstOrDefault(i => i.id_category == itemCat.Id);
                db.CATEGORY.Remove(it);
                db.SaveChanges();

                lv_itemsCategory.ItemsSource = mg.GetAllCategory();
                DialogHost.Show(new Message()
                {
                    message_tb = { Text = "Catégorie supprimée avec succès" }
                }, "RootDialog");

            }
            catch (Exception ex)
            {
                DialogHost.Show(new Message()
                {
                    message_tb = { Text = "Impossible de supprimer la catégorie " + ex.Message }
                }, "RootDialog");
            }

        }

        private void OnClickDeleteIng(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = (IngredientModel)((ListViewItem)lv_ingredient.ContainerFromElement((Button)sender)).Content;
                var it = db.INGREDIENT.FirstOrDefault(i => i.id_ingredient == item.Id);
                db.INGREDIENT.Remove(it);
                db.SaveChanges();
                try
                {
                    var liste = (ItemsCategoryModel)lv_ingredientCategory.SelectedItem;
                    if (liste != null)
                        lv_ingredient.ItemsSource = mg.GetIngredientByCat(liste.Id);
                }
                catch
                {

                }
            }
            catch (Exception ex)
            {
                DialogHost.Show(new Message()
                {
                    message_tb = { Text = "Supression impossible, vérifiez les affectations" }
                }, "RootDialog");
            }
        }
    }
}
