using Ecom.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Model
{
    class ManagementModel
    {
        #region FIELDS
        ModelCezar db;
        ObservableCollection<CATEGORY> listCategory;
        ObservableCollection<ItemModel> listItems;

        #endregion

        #region METHODS

        public ObservableCollection<CategoryModel> GetAllCategory()
        {
            db = new ModelCezar();
            var categoryQuery = db.CATEGORY.Select(c => new CategoryModel
            {
                Id = c.id_category,
                Title = c.category_title
            });
            return new ObservableCollection<CategoryModel>(categoryQuery.ToList());
        }



        public ObservableCollection<ItemModel> GetItemsByCat(int id)
        {
            db = new ModelCezar();
            var itemQuery = db.ITEM.Where(i => i.id_category == id).Select(i => new ItemModel
            {
                Id = i.id_item,
                Title = i.item_title,
                Price = (double)i.item_price,
                Actif = i.actif,
                Color = i.item_button_color
            });
            return new ObservableCollection<ItemModel>(itemQuery.ToList());
        }

        public ObservableCollection<ItemsCategoryModel> GetItemsOptionsByItem(int id)
        {
            db = new ModelCezar();


            var itemOptionQuery = (from itm in db.ITEM.Where(c => c.CATEGORY_INGREDIENT.Any() && c.id_item == id)
                                   from cIng in db.CATEGORY_INGREDIENT.Where(ci => ci.ITEM.Contains(itm))
                                   select new ItemsCategoryModel()
                                   {
                                       Title = cIng.category_ingredient_title
                                   });
            return new ObservableCollection<ItemsCategoryModel>(itemOptionQuery.ToList());
        }

        // Get all ingredient categories 
        public ObservableCollection<ItemsCategoryModel> GetAllIngredientCat()
        {
            db = new ModelCezar();
            var allIngredientQuery =
                                   (from cIng in db.CATEGORY_INGREDIENT
                                    select new ItemsCategoryModel()
                                    {
                                        Id = cIng.id_category_ingredient,
                                        Title = cIng.category_ingredient_title
                                    });
            return new ObservableCollection<ItemsCategoryModel>(allIngredientQuery.ToList());
        }

        public ObservableCollection<IngredientModel> GetIngredientByCat(int id)
        {
            db = new ModelCezar();
            var IngredientByCatQuery = (from ing in db.INGREDIENT
                                        where ing.id_category_ingredient == id
                                        select new IngredientModel()
                                        {
                                            Id= ing.id_ingredient,
                                            Title = ing.ingredient_title
                                        });

            return new ObservableCollection<IngredientModel>(IngredientByCatQuery.ToList());

        }


        #endregion
    }

    public class GeneralItem : INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }
    }

    public class ItemModel : GeneralItem
    {
        private double price;
        private bool actif;
        private string color;

        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        public bool Actif
        {
            get { return actif; }
            set
            {
                actif = value;
                OnPropertyChanged("Actif");
            }
        }
        public string Color
        {
            get { return color; }
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }
    }
    public class CategoryModel : GeneralItem
    {

    }
    public class ItemsCategoryModel : GeneralItem
    {
   
    }
    public class IngredientModel : GeneralItem
    {
    }
     
}
