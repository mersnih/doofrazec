using Ecom.DataModel;
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

namespace Ecom.View
{
    /// <summary>
    /// Logique d'interaction pour MeatChoice.xaml
    /// </summary>
    public partial class MeatChoice : UserControl
    {
        ModelCezar db;
        ObservableCollection<ItemIngredient> reqIngredient = new ObservableCollection<ItemIngredient>();
        public MeatChoice(int id)
        {
        
            InitializeComponent();
            db = new ModelCezar();
            var req = (from ing in db.INGREDIENT.Where(i => i.ITEM.Any() && i.id_category_ingredient == 1)
                       from itm in db.ITEM.Where(it => it.INGREDIENT.Contains(ing) && it.id_item == id)
                       select new ItemIngredient()
                           {
                               IdItem = itm.id_item,
                               IdIngredient = ing.id_ingredient,
                               Item_title = itm.item_title,
                               Ingredient_title = ing.ingredient_title,
                               Ingredient_quantity = 0
                           }                           
                      );
            reqIngredient = new ObservableCollection<ItemIngredient>(req.ToList());

            lb_choixViande.ItemsSource = reqIngredient;
       }

        private void addMeat(object sender, RoutedEventArgs e)
        {
            //var item = ((ListBoxItem)lb_choixViande.ContainerFromElement((Button)sender));
            ItemIngredient kk = lb_choixViande.SelectedItems as ItemIngredient;

          //  ItemIngredient Items = kk;
            foreach (ItemIngredient ii in lb_choixViande.SelectedItems)
            {

                ii.Ingredient_quantity = kk.Ingredient_quantity;
                //ii.Item_title = Items.Item_title;
                //ii.Ingredient_quantity = Items.Ingredient_quantity;
                MessageBox.Show(ii.Ingredient_title + " - " + ii.Ingredient_quantity);
            }
        }
    }
}
