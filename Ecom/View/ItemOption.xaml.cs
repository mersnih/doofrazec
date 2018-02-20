using Ecom.DataModel;
using Ecom.Model;
using Ecom.ViewModel;
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
    public partial class ItemOption : UserControl
    {
        ModelCezar db;

        ObservableCollection<Cart> cart = new ObservableCollection<Cart>();
        ObservableCollection<Cart> cartList = new ObservableCollection<Cart>();    
        ObservableCollection<ItemIngredient> lst = new ObservableCollection<ItemIngredient>();
        ObservableCollection<ItemIngredient> itemIngredientLocal = new ObservableCollection<ItemIngredient>();

        Cart _cart = new Cart();
        int indexLocal =-1;
        CartViewModel cvm = new CartViewModel();

        ITEM itemLocal = new ITEM();
        List<CATEGORY_INGREDIENT> catIngLocal = new List<CATEGORY_INGREDIENT>();


        int catIngLocalCount = 0;
        int counter = 0;
        double totalSupp = 0;

        public ItemOption(Cart list, int idItem, int index, List<CATEGORY_INGREDIENT> catIng)
        {
            InitializeComponent();
            counter = 0;
           
            if(index > -1)
            {
                indexLocal = index;
                db = new ModelCezar();
                _cart = list;
                lst = list.SelectedIngredients;

                itemLocal.id_item = list.ItemId;
                itemLocal.item_price = (decimal)list.ItemPriceWithoutSupp;
                itemLocal.item_title = list.ItemTitle;
                catIngLocalCount = catIng.Count;
                catIngLocal = catIng;
                CATEGORY_INGREDIENT ci = new CATEGORY_INGREDIENT();
                ci = catIng[counter];
                int id = catIng[counter].id_category_ingredient;
                var optionQuery = (from ing in db.INGREDIENT.Where(i => i.id_category_ingredient == id)
                                   select new ItemIngredient()
                                   {
                                       IdItem = idItem,
                                       IdIngredient = ing.id_ingredient,
                                       Item_title = list.ItemTitle,
                                       Ingredient_title = ing.ingredient_title,
                                       Ingredient_price = (double)ing.ingredient_price,
                                       Ingredient_quantity = 0

                                   });
                lb_itemOptions.ItemsSource = new ObservableCollection<ItemIngredient>(optionQuery.ToList());
                foreach(ItemIngredient ii in list.SelectedIngredients)
                {
                    lb_itemOptions.SelectedIndex = ii.IngredientSelectedIndex;
                }
             

                //var reqForMeat = (from ing in db.INGREDIENT.Where(i => i.ITEM.Any() && i.id_category_ingredient == 1)
                //                  from itm in db.ITEM.Where(it => it.INGREDIENT.Contains(ing) && it.id_item == idItem)
                //                  select new ItemIngredient()
                //                  {
                //                      IdItem = itm.id_item,
                //                      IdIngredient = ing.id_ingredient,
                //                      Item_title = itm.item_title,
                //                      Ingredient_title = ing.ingredient_title,
                //                      Ingredient_quantity = 0
                //                  });

                //  var reqForMeat = (from ing in db.INGREDIENT.Where(i => i.ITEM.Any() && i.id_category_ingredient == 1)
                //                    from itm in db.ITEM.Where(it => it.INGREDIENT.Contains(ing) && it.id_item == idItem)
                //                    select new ItemIngredient()
                //                    {
                //                        IdItem = itm.id_item,
                //                        IdIngredient = ing.id_ingredient,
                //                        Item_title = itm.item_title,
                //                        Ingredient_title = ing.ingredient_title,
                //                        Ingredient_quantity = 0
                //                    }
                //);
                //  tb_optionTitle.Text = "Options " + itemLocal.item_title;
                //  var reqForSauce = (from ing in db.INGREDIENT.Where(i => i.ITEM.Any() && i.id_category_ingredient == 2)
                //                     from itm in db.ITEM.Where(it => it.INGREDIENT.Contains(ing) && it.id_item == idItem)
                //                     select new ItemIngredient()
                //                     {
                //                         IdItem = itm.id_item,
                //                         IdIngredient = ing.id_ingredient,
                //                         Item_title = itm.item_title,
                //                         Ingredient_title = ing.ingredient_title,
                //                         Ingredient_quantity = 0
                //                     }
                //);
                //  var reqForSupp = (from ing in db.INGREDIENT.Where(i => i.ITEM.Any() && i.id_category_ingredient == 3)
                //                    from itm in db.ITEM.Where(it => it.INGREDIENT.Contains(ing) && it.id_item == idItem)
                //                    select new ItemIngredient()
                //                    {
                //                        IdItem = itm.id_item,
                //                        IdIngredient = ing.id_ingredient,
                //                        Item_title = itm.item_title,
                //                        Ingredient_title = ing.ingredient_title,
                //                        Ingredient_price = (double)ing.ingredient_price,
                //                        Ingredient_quantity = 0
                //                    }
                //);


                //  lb_choixViande.ItemsSource = new ObservableCollection<ItemIngredient>(reqForMeat.ToList());
                //  lb_choixSauce.ItemsSource = new ObservableCollection<ItemIngredient>(reqForSauce.ToList());
                //  lb_choixSupp.ItemsSource = new ObservableCollection<ItemIngredient>(reqForSupp.ToList());



            }
  
       
        //    lb_choixViande.SelectedIndex = lb_choixViande.Items.IndexOf(lst[0].Ingredient_title);

        }



        public ItemOption(ITEM item, List<CATEGORY_INGREDIENT> catIng)
        {
            InitializeComponent();
            db = new ModelCezar();


            itemLocal = item;
            catIngLocal = catIng;
            catIngLocalCount = catIng.Count;
            counter = 0;

            CATEGORY_INGREDIENT ci = new CATEGORY_INGREDIENT();
            ci = catIng[counter];
            int id = catIng[counter].id_category_ingredient;
            var optionQuery = (from ing in db.INGREDIENT.Where(i => i.id_category_ingredient == id)
                               select new ItemIngredient()
                               {
                                   IdItem = item.id_item,
                                   IdIngredient = ing.id_ingredient,
                                   Item_title = item.item_title,
                                   Ingredient_title = ing.ingredient_title,
                                   Ingredient_price = (double)ing.ingredient_price,
                                   Ingredient_quantity = 0

                               });
            lb_itemOptions.ItemsSource = new ObservableCollection<ItemIngredient>(optionQuery.ToList());


            //foreach (CATEGORY_INGREDIENT list in catIng)
            //{
            //    int id = list.id_category_ingredient;
            //    var optionQuery = (from ing in db.INGREDIENT.Where(i => i.id_category_ingredient == id)
            //                      select new ItemIngredient()
            //                      {
            //                          IdItem = item.id_item,
            //                          IdIngredient = ing.id_ingredient,
            //                          Item_title = item.item_title,
            //                          Ingredient_title = ing.ingredient_title,
            //                          Ingredient_quantity = 0
            //                      });



            //}





            //  var reqForMeat = (from ing in db.INGREDIENT.Where(i => i.ITEM.Any() && i.id_category_ingredient == 1)
            //                    from itm in db.ITEM.Where(it => it.INGREDIENT.Contains(ing) && it.id_item == item.id_item)
            //                    select new ItemIngredient()
            //                    {
            //                        IdItem = itm.id_item,
            //                        IdIngredient = ing.id_ingredient,
            //                        Item_title = itm.item_title,
            //                        Ingredient_title = ing.ingredient_title,
            //                        Ingredient_quantity = 0
            //                    }
            //            );
            //  tb_optionTitle.Text = "Options " + itemLocal.item_title;
            //  var reqForSauce = (from ing in db.INGREDIENT.Where(i => i.ITEM.Any() && i.id_category_ingredient == 2)
            //                     from itm in db.ITEM.Where(it => it.INGREDIENT.Contains(ing) && it.id_item == item.id_item)
            //                     select new ItemIngredient()
            //                     {
            //                         IdItem = itm.id_item,
            //                         IdIngredient = ing.id_ingredient,
            //                         Item_title = itm.item_title,
            //                         Ingredient_title = ing.ingredient_title,
            //                         Ingredient_quantity = 0
            //                     }
            //);
            //  var reqForSupp = (from ing in db.INGREDIENT.Where(i => i.ITEM.Any() && i.id_category_ingredient == 3)
            //                    from itm in db.ITEM.Where(it => it.INGREDIENT.Contains(ing) && it.id_item == item.id_item)
            //                    select new ItemIngredient()
            //                    {
            //                        IdItem = itm.id_item,
            //                        IdIngredient = ing.id_ingredient,
            //                        Item_title = itm.item_title,
            //                        Ingredient_title = ing.ingredient_title,
            //                        Ingredient_price = (double)ing.ingredient_price,
            //                        Ingredient_quantity = 0
            //                    }
            //);
            // reqIngredient = new ObservableCollection<ItemIngredient>(req.ToList());


            //lb_choixSauce.ItemsSource = new ObservableCollection<ItemIngredient>(reqForSauce.ToList());
            //lb_choixSupp.ItemsSource = new ObservableCollection<ItemIngredient>(reqForSupp.ToList());
        }

        private void addMeat(object sender, RoutedEventArgs e)
        {
            //foreach (ItemIngredient ii in lb_choixViande.SelectedItems)
            //{
            //    itemIngredientLocal.Add(new ItemIngredient()
            //    {
            //        IdItem = ii.IdItem,
            //        IdIngredient = ii.IdIngredient,
            //        Item_title = ii.Item_title,
            //        Ingredient_title = ii.Ingredient_title,
            //        Ingredient_quantity = 1
            //    });
            //}
            //foreach (ItemIngredient ii in lb_choixSauce.SelectedItems)
            //{
            //    itemIngredientLocal.Add(new ItemIngredient()
            //    {
            //        IdItem = ii.IdItem,
            //        IdIngredient = ii.IdIngredient,
            //        Item_title = ii.Item_title,
            //        Ingredient_title = ii.Ingredient_title,
            //        Ingredient_quantity = 1
            //    });
            //}
            //foreach (ItemIngredient ii in lb_choixSupp.SelectedItems)
            //{
            //    itemIngredientLocal.Add(new ItemIngredient()
            //    {
            //        IdItem = ii.IdItem,
            //        IdIngredient = ii.IdIngredient,
            //        Item_title = ii.Item_title,
            //        Ingredient_title = ii.Ingredient_title,
            //        Ingredient_price = ii.Ingredient_price,
            //        Ingredient_quantity = 1
            //    });
            //}
            //foreach(var par in itemIngredientLocal)
            //{
            //    totalSupp = totalSupp + par.Ingredient_price;

            //}
            foreach (var par in itemIngredientLocal)
            {
                totalSupp = totalSupp + par.Ingredient_price;

            }

            if (indexLocal < 0)
            {
                cvm.Cart.Add(new Cart
                {
                    ItemQuantity = 1,
                    ItemId = itemLocal.id_item,
                    ItemTitle = itemLocal.item_title,
                    ItemPriceWithoutSupp = (double)itemLocal.item_price,
                    SuppPrice = totalSupp,

                    SelectedIngredients = itemIngredientLocal

                });
            }
            else
            {
                cvm.Cart[indexLocal] = new Cart
                {
                    ItemQuantity = 1,
                    ItemId = itemLocal.id_item,
                    ItemTitle = itemLocal.item_title,
                    ItemPriceWithoutSupp = (double)itemLocal.item_price,
                    SuppPrice = totalSupp,


                    SelectedIngredients = itemIngredientLocal

                };
            }
        }

        private void test(object sender, RoutedEventArgs e)
        {
            // first count = 0
            // 1 - add selected items 
            // 2 - populate next view 

            if (counter < catIngLocalCount)
            {
                foreach (ItemIngredient ii in lb_itemOptions.SelectedItems)
                {
                   

                    itemIngredientLocal.Add(new ItemIngredient()
                    {
                        IdItem = ii.IdItem,                      
                        IngredientSelectedIndex = lb_itemOptions.SelectedIndex,
                        IdIngredient = ii.IdIngredient,
                        Item_title = ii.Item_title,
                        Ingredient_title = ii.Ingredient_title,
                        Ingredient_price = ii.Ingredient_price,
                        Ingredient_quantity = 1
                    });
                }
                counter = counter + 1;
            }

       
            if(counter <= catIngLocalCount - 1)
            { 
                int id = catIngLocal[counter].id_category_ingredient;
                var optionQuery = (from ing in db.INGREDIENT.Where(i => i.id_category_ingredient == id)
                                    select new ItemIngredient()
                                    {
                                        IdItem = itemLocal.id_item,
                                        IdIngredient = ing.id_ingredient,
                                        Item_title = itemLocal.item_title,
                                        Ingredient_title = ing.ingredient_title,
                                        Ingredient_price = (double)ing.ingredient_price,
                                        Ingredient_quantity = 0
                                    });
                lb_itemOptions.ItemsSource = new ObservableCollection<ItemIngredient>(optionQuery.ToList());
                if(_cart.SelectedIngredients != null && _cart.SelectedIngredients.Count > 0)
                {
                    foreach (ItemIngredient ii in _cart.SelectedIngredients)
                    {
                        lb_itemOptions.SelectedIndex = ii.IngredientSelectedIndex;
                    }
                }


            }
            else
            {
                bt_NextOption.Visibility = Visibility.Collapsed;
            }
        }
    }
}
