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
    /// Interaction logic for CUCat.xaml
    /// </summary>
    public partial class CUCat : UserControl
    {
        ModelCezar db;
        int IDSource = 0;
        public CUCat(int source)
        {
            InitializeComponent();
            db = new ModelCezar();
            IDSource = source;
        }

        private void OnCLickAddNewCat(object sender, RoutedEventArgs e)
        {
            try
            {
                if(IDSource == 2)
                {
                    CATEGORY_INGREDIENT ci = new CATEGORY_INGREDIENT();
                    if (!string.IsNullOrEmpty(tb_nameCat.Text))
                    {
                        ci.category_ingredient_title = tb_nameCat.Text.ToString();
                        db.CATEGORY_INGREDIENT.Add(ci);
                        db.SaveChanges();
                    }
                }
                if(IDSource == 1)
                {
                    CATEGORY c = new CATEGORY();
                    if (!string.IsNullOrEmpty(tb_nameCat.Text))
                    {
                        c.category_title = tb_nameCat.Text.ToString();
                        c.category_description = "";

                        c.category_button_color = "#9b59b6";
                        db.CATEGORY.Add(c);
                        db.SaveChanges();

                    }
                }

            }
            catch(Exception ex)
            {

            }

        }
    }
}
