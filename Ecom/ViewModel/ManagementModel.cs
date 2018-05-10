using Ecom.DataModel;
using Ecom.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ecom.Model
{
    class ManagementModel
    {
        #region FIELDS
        ModelCezar db;
        bool BddOk = false;


        #endregion

        #region METHODS

        #region CONSTRUCTORS
        public ManagementModel()
        {
            if (Network.BddConnection())
            {
                BddOk = true;
            }
            else
            {
                BddOk = false;
            }
            NetworkChange.NetworkAddressChanged += new NetworkAddressChangedEventHandler(AdressChangedCallBack);
        }

        private void AdressChangedCallBack(object sender, EventArgs e)
        {
            if (Network.BddConnection())
            {
                BddOk = true;
            }
            else
            {
                BddOk = false;
            }
        }

        #endregion
        public ObservableCollection<CategoryModel> GetAllCategory()
        {
            if (BddOk)
            {
                using (ModelCezar db = new ModelCezar())
                {

                    var categoryQuery = db.CATEGORY.Select(c => new CategoryModel
                    {
                        Id = c.id_category,
                        Title = c.category_title
                    });
                    return new ObservableCollection<CategoryModel>(categoryQuery.ToList());
                }
            }
            else
            {
                return null;
            }
            //  db = new ModelCezar();


        }

        internal IEnumerable GetMenuOptions()
        {
            if (BddOk)
            {
                using (ModelCezar db = new ModelCezar())
                {

                    var menuOptionQuery = db.OPTION_CHOIX_MENU.Select(c => new MenuOptions
                    {
                        Id = c.id_option_choix_menu,
                        Title = c.option_choix_menu_title
                       
                    });
                    return new ObservableCollection<MenuOptions>(menuOptionQuery.ToList());
                }
            }
            else
            {
                return null;
            }
        }

        internal IEnumerable GetAllMenu()
        {
            if (BddOk)
            {
                using (ModelCezar db = new ModelCezar())
                {

                    var menuQuery = db.MENU.Select(c => new MenuModel
                    {
                        Id = c.id_menu,
                        Title = c.menu_title
                    });
                    return new ObservableCollection<MenuModel>(menuQuery.ToList());
                }
            }
            else
            {
                return null;
            }
        }

        public ObservableCollection<ItemModel> GetItemsByCat(int id)
        {
            if (BddOk)
            {
                db = new ModelCezar();
                var itemQuery = db.ITEM.Where(i => i.id_category == id).Select(i => new ItemModel
                {
                    Id = i.id_item,
                    Title = i.item_title,
                    Price = (double)i.item_price,
                    Actif = i.actif,
                    Color = i.item_button_color,
                    Cooked = i.cooked,
                    Status = i.actif ? "Actif" : "Inactif",
                    StatusColor = i.actif ? "#2ecc71" : "#e74c3c"
                });
                return new ObservableCollection<ItemModel>(itemQuery.ToList());
            }
            else
            {
                return null;
            }

        }

        public ObservableCollection<ItemsCategoryModel> GetItemsOptionsByItem(int id)
        {
            if (BddOk)
            {
                db = new ModelCezar();
                var itemOptionQuery = (from itm in db.ITEM.Where(c => c.CATEGORY_INGREDIENT.Any() && c.id_item == id)
                                       from cIng in db.CATEGORY_INGREDIENT.Where(ci => ci.ITEM.Contains(itm))
                                       select new ItemsCategoryModel()
                                       {
                                           Id = cIng.id_category_ingredient,
                                           Title = cIng.category_ingredient_title
                                       });
                return new ObservableCollection<ItemsCategoryModel>(itemOptionQuery.ToList());
            }
            else
            {
                return null;
            }

        }

        // Get all ingredient categories 
        public ObservableCollection<ItemsCategoryModel> GetAllIngredientCat()
        {
            if (BddOk)
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
            else
            {
                return null;
            }
        }

        public ObservableCollection<IngredientModel> GetIngredientByCat(int id)
        {
            if (BddOk)
            {
                db = new ModelCezar();
            var IngredientByCatQuery = (from ing in db.INGREDIENT
                                        where ing.id_category_ingredient == id
                                        select new IngredientModel()
                                        {
                                            Id = ing.id_ingredient,
                                            Title = ing.ingredient_title
                                        });

            return new ObservableCollection<IngredientModel>(IngredientByCatQuery.ToList());
            }
            else
            {
                return null;
            }

        }

        internal IEnumerable GetMenuSelectedOptions(int id)
        {
            if (BddOk)
            {
                db = new ModelCezar();
                var itemMenuSelectedOptionQuery = (from menu in db.MENU.Where(c => c.OPTION_CHOIX_MENU.Any() &&  c.id_menu == id)
                                                   from ocm in db.OPTION_CHOIX_MENU.Where(ci => ci.MENU.Contains(menu))

                                                   select new ItemsCategoryModel()
                                       {
                                           Id = ocm.id_option_choix_menu,
                                           Title = ocm.option_choix_menu_title
                                       });
                return new ObservableCollection<ItemsCategoryModel>(itemMenuSelectedOptionQuery.ToList());
            }
            else
            {
                return null;
            }
        }

        internal IEnumerable GetMenuItemsOptions(int id)
        {
            if (BddOk)
            {
                db = new ModelCezar();
                var itemMenuItemsOptionsQuery = (from menu in db.ITEM_OPTION_MENU.Where(c => c.id_option_choix_menu == id)
                                                   from itm in db.ITEM.Where(ci => ci.id_item == menu.id_item)

                                                   select new ItemsCategoryModel()
                                                   {
                                                       Id = itm.id_item,
                                                       Title = itm.item_title
                                                   });
                return new ObservableCollection<ItemsCategoryModel>(itemMenuItemsOptionsQuery.ToList());
            }
            else
            {
                return null;
            }
        }


        #endregion
    }


}
