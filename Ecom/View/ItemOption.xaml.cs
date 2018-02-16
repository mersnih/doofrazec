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
        double totalSupp = 0;

        public ItemOption(Cart list, int idItem, int index)
        {
            InitializeComponent();
            if(index > -1)
            {
                indexLocal = index;
                db = new ModelCezar();
                _cart = list;
                lst = list.SelectedIngredients;

                itemLocal.id_item = list.ItemId;
                itemLocal.item_price = (decimal)list.ItemPriceWithoutSupp;
                itemLocal.item_title = list.ItemTitle;


                var reqForMeat = (from ing in db.INGREDIENT.Where(i => i.ITEM.Any() && i.id_category_ingredient == 1)
                                  from itm in db.ITEM.Where(it => it.INGREDIENT.Contains(ing) && it.id_item == idItem)
                                  select new ItemIngredient()
                                  {
                                      IdItem = itm.id_item,
                                      IdIngredient = ing.id_ingredient,
                                      Item_title = itm.item_title,
                                      Ingredient_title = ing.ingredient_title,
                                      Ingredient_quantity = 0
                                  }
              );
                tb_optionTitle.Text = "Options " + itemLocal.item_title;
                var reqForSauce = (from ing in db.INGREDIENT.Where(i => i.ITEM.Any() && i.id_category_ingredient == 2)
                                   from itm in db.ITEM.Where(it => it.INGREDIENT.Contains(ing) && it.id_item == idItem)
                                   select new ItemIngredient()
                                   {
                                       IdItem = itm.id_item,
                                       IdIngredient = ing.id_ingredient,
                                       Item_title = itm.item_title,
                                       Ingredient_title = ing.ingredient_title,
                                       Ingredient_quantity = 0
                                   }
              );
                var reqForSupp = (from ing in db.INGREDIENT.Where(i => i.ITEM.Any() && i.id_category_ingredient == 3)
                                  from itm in db.ITEM.Where(it => it.INGREDIENT.Contains(ing) && it.id_item == idItem)
                                  select new ItemIngredient()
                                  {
                                      IdItem = itm.id_item,
                                      IdIngredient = ing.id_ingredient,
                                      Item_title = itm.item_title,
                                      Ingredient_title = ing.ingredient_title,
                                      Ingredient_price = (double)ing.ingredient_price,
                                      Ingredient_quantity = 0
                                  }
              );


                lb_choixViande.ItemsSource = new ObservableCollection<ItemIngredient>(reqForMeat.ToList());
                lb_choixSauce.ItemsSource = new ObservableCollection<ItemIngredient>(reqForSauce.ToList());
                lb_choixSupp.ItemsSource = new ObservableCollection<ItemIngredient>(reqForSupp.ToList());


                
            }
  
       
        //    lb_choixViande.SelectedIndex = lb_choixViande.Items.IndexOf(lst[0].Ingredient_title);

        }



        public ItemOption(ITEM item)
        {
            InitializeComponent();
            db = new ModelCezar();
            itemLocal = item;
   


            var reqForMeat = (from ing in db.INGREDIENT.Where(i => i.ITEM.Any() && i.id_category_ingredient == 1)
                       from itm in db.ITEM.Where(it => it.INGREDIENT.Contains(ing) && it.id_item == item.id_item)
                       select new ItemIngredient()
                           {
                               IdItem = itm.id_item,
                               IdIngredient = ing.id_ingredient,
                               Item_title = itm.item_title,
                               Ingredient_title = ing.ingredient_title,
                               Ingredient_quantity = 0
                           }                           
                      );
            tb_optionTitle.Text = "Options " + itemLocal.item_title;
            var reqForSauce = (from ing in db.INGREDIENT.Where(i => i.ITEM.Any() && i.id_category_ingredient == 2)
                              from itm in db.ITEM.Where(it => it.INGREDIENT.Contains(ing) && it.id_item == item.id_item)
                              select new ItemIngredient()
                              {
                                  IdItem = itm.id_item,
                                  IdIngredient = ing.id_ingredient,
                                  Item_title = itm.item_title,
                                  Ingredient_title = ing.ingredient_title,
                                  Ingredient_quantity = 0
                              }
          );
            var reqForSupp = (from ing in db.INGREDIENT.Where(i => i.ITEM.Any() && i.id_category_ingredient == 3)
                               from itm in db.ITEM.Where(it => it.INGREDIENT.Contains(ing) && it.id_item == item.id_item)
                               select new ItemIngredient()
                               {
                                   IdItem = itm.id_item,
                                   IdIngredient = ing.id_ingredient,
                                   Item_title = itm.item_title,
                                   Ingredient_title = ing.ingredient_title,
                                   Ingredient_price = (double)ing.ingredient_price,
                                   Ingredient_quantity = 0
                               }
          );
            // reqIngredient = new ObservableCollection<ItemIngredient>(req.ToList());

            lb_choixViande.ItemsSource = new ObservableCollection<ItemIngredient>(reqForMeat.ToList());       
            lb_choixSauce.ItemsSource = new ObservableCollection<ItemIngredient>(reqForSauce.ToList());
            lb_choixSupp.ItemsSource = new ObservableCollection<ItemIngredient>(reqForSupp.ToList());
        }

        private void addMeat(object sender, RoutedEventArgs e)
        {
           
            //var item = ((ListBoxItem)lb_choixViande.ContainerFromElement((Button)sender));
            //ItemIngredient kk = lb_choixViande.SelectedItems as ItemIngredient;

            //var lbi = this.lb_choixViande.ItemContainerGenerator.ContainerFromItem(this.lb_choixViande.SelectedItem);
            //  ItemIngredient Items = kk;
            foreach (ItemIngredient ii in lb_choixViande.SelectedItems)
            {
                itemIngredientLocal.Add(new ItemIngredient()
                {
                    IdItem = ii.IdItem,
                    IdIngredient = ii.IdIngredient,
                    Item_title = ii.Item_title,
                    Ingredient_title = ii.Ingredient_title,
                    Ingredient_quantity = 1
                });
            }
            foreach (ItemIngredient ii in lb_choixSauce.SelectedItems)
            {
                itemIngredientLocal.Add(new ItemIngredient()
                {
                    IdItem = ii.IdItem,
                    IdIngredient = ii.IdIngredient,
                    Item_title = ii.Item_title,
                    Ingredient_title = ii.Ingredient_title,
                    Ingredient_quantity = 1
                });
            }
            foreach (ItemIngredient ii in lb_choixSupp.SelectedItems)
            {
                itemIngredientLocal.Add(new ItemIngredient()
                {
                    IdItem = ii.IdItem,
                    IdIngredient = ii.IdIngredient,
                    Item_title = ii.Item_title,
                    Ingredient_title = ii.Ingredient_title,
                    Ingredient_price = ii.Ingredient_price,
                    Ingredient_quantity = 1
                });
            }
            foreach(var par in itemIngredientLocal)
            {
                totalSupp = totalSupp + par.Ingredient_price;
           
            }
            if(indexLocal < 0)
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
            

         //   cvm.Cart.Remove(_cart);

        

        }
    }
}
