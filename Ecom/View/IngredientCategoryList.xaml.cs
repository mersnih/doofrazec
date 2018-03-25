using Ecom.DataModel;
using Ecom.Model;
using Ecom.ViewModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections;
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
    /// Interaction logic for IngredientCategoryList.xaml
    /// </summary>
    public partial class IngredientCategoryList : UserControl
    {
        int IdItem;
        ResultViewModel rvm = new ResultViewModel();
        public IngredientCategoryList(int idItem)
        {
            InitializeComponent();
            IdItem = idItem;
            ManagementModel mg = new ManagementModel();

            lv_ingredientCategoryList.ItemsSource = mg.GetAllIngredientCat();
        }

        private void OnClickAffect(object sender, RoutedEventArgs e)
        {
            int count = 0;
            //  var idCat = ((ItemsCategoryModel)lv_ingredientCategoryList.SelectedItem).Id;
            var idCatList = (lv_ingredientCategoryList.SelectedItems);

            count = lv_ingredientCategoryList.SelectedItems.Count;
            using (var db = new ModelCezar())
            {
                try
                {
                    ITEM item = new ITEM { id_item = IdItem };
                    db.ITEM.Add(item);
                    db.ITEM.Attach(item);
                    for (int i = 0; i < count; i++)
                    {
                        var result = (ItemsCategoryModel)idCatList[i];

                        CATEGORY_INGREDIENT catIng = new CATEGORY_INGREDIENT { id_category_ingredient = result.Id };
                        db.CATEGORY_INGREDIENT.Add(catIng);
                        db.CATEGORY_INGREDIENT.Attach(catIng);

                        item.CATEGORY_INGREDIENT.Add(catIng);
                        db.SaveChanges();
                        rvm.Result = true;
                        rvm.Resultmessage = "Validé";
                     
                    }
                }
                catch (Exception ex)
                {
                    rvm.Resultmessage = "Erreur " + ex.InnerException;
                    rvm.Result = false;
                }
            }
        }
    }
}
