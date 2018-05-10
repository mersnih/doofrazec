using Ecom.DataModel;
using Ecom.Model;
using Ecom.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.ViewModel
{
    class CommandesViewModel
    {

        ModelCezar db;
        bool BddOk = false;

        public CommandesViewModel()
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

        public ObservableCollection<Cart> GetOrderDetail(int id)
        {

            if (BddOk)
            {
                using (ModelCezar db = new ModelCezar())
                {

                    //var orderDetailQuery = (from itmSel in db.item_selection
                    //                        join itm in db.ITEM on itmSel.id_item equals itm.id_item
                    //                        join ing in db.INGREDIENT on itmSel.id_ingredient equals ing.id_ingredient
                    //                        where itmSel.id_orders == id

                    //                        select new Cart()
                    //                        {
                    //                            ItemId = itm.id_item,
                    //                            ItemTitle = itm.item_title,
                    //                            ItemQuantity = (int)(itm.item_quantity == null ? 1 : itm.item_quantity)



                    //                        });
                    ObservableCollection<ItemIngredient> ingredients = new ObservableCollection<ItemIngredient>();
                    ObservableCollection<Cart> cart = new ObservableCollection<Cart>();
                    ItemIngredient itg = new ItemIngredient();

                    List<int> idItem = new List<int>();
                    //var res = (from selection in db.item_selection where selection.id_orders == id select selection).ToList();
                    var res = ( 
                                  from itmSel in db.item_selection
                                  join itm in db.ITEM on itmSel.id_item equals itm.id_item
                                  join ing in db.INGREDIENT on itmSel.id_ingredient equals ing.id_ingredient into ingredient
                                  from x in ingredient.DefaultIfEmpty()
                                  where itmSel.id_orders == id

                                  select new
                                  {
                                      itmSel

                                  }).ToList();
                    var test = res;
                    foreach (var var in res.GroupBy(x => x.itmSel.ITEM.id_item).Select(s => s.First()).ToList())
                    {

                        var ingred = test.Where(z => z.itmSel.id_item == var.itmSel.id_item).ToList();
                        if (ingred != null)
                        {
                           
                            foreach (var i in ingred)
                            {
                                if(i.itmSel.INGREDIENT != null)
                                {
                                     ingredients.Add(new ItemIngredient()
                                    {
                                        IdIngredient = i.itmSel.INGREDIENT.id_ingredient,
                                        Ingredient_title = i.itmSel.INGREDIENT.ingredient_title
                                    });
                                }
                      
                            }
                            cart.Add(new Cart()
                            {
                                ItemId = var.itmSel.id_item,
                                ItemTitle = var.itmSel.ITEM.item_title,
                                ItemQuantity = (int)(var.itmSel.item_selection_quantity == null ? 1 : var.itmSel.item_selection_quantity),
                                SelectedIngredients = ingredients
                            });
                        }

                        else
                        {
                            cart.Add(new Cart()
                            {
                                ItemId = var.itmSel.id_item,
                                ItemTitle = var.itmSel.ITEM.item_title,
                                ItemQuantity = (int)(var.itmSel.item_selection_quantity == null ? 1 : var.itmSel.item_selection_quantity),

                            });
                        }
                        ingredients = new ObservableCollection<ItemIngredient>();

                    }




                    //var result = (from order in db.ORDERS
                    //              from itmSel in order.item_selection  
                    //              join itm in db.ITEM on itmSel.id_item equals itm.id_item
                    //              join ing in db.INGREDIENT.DefaultIfEmpty() on itmSel.id_ingredient equals ing.id_ingredient

                    //              where order.id_orders == id

                    //              select new
                    //              {
                    //                  itmSel
                    //              }).ToList();


                    //var orderDetailQuery = (from itmSel in db.item_selection
                    //                        join order in db.ORDERS on itmSel.id_orders equals order.id_orders
                    //                        join itm in db.ITEM on itmSel.id_item equals itm.id_item
                    //                        join ing in db.INGREDIENT.DefaultIfEmpty() on itmSel.id_ingredient equals ing.id_ingredient

                    //                        where order.id_orders == id

                    //                        select new
                    //                        {
                    //                            itmSel
                    //                        })
                    //                        .ToList();


                    //foreach (var item in result)
                    //{


                    //    //GroupBy(x => x.itmSel.ITEM.id_item).Select(s => s.First()).ToList()

                    //    if (item.itmSel.INGREDIENT.id_ingredient > 0)
                    //    {
                    //        ingredients.Add(new ItemIngredient()
                    //        {
                    //            IdIngredient = item.itmSel.INGREDIENT.id_ingredient,
                    //            Ingredient_title = item.itmSel.INGREDIENT.ingredient_title


                    //        });

                    //        cart.Add(new Cart()
                    //        {
                    //            ItemId = item.itmSel.ITEM.id_item,
                    //            ItemTitle = item.itmSel.ITEM.item_title,
                    //            SelectedIngredients = ingredients

                    //        });

                    //    }
                    //    else
                    //    {
                    //        cart.Add(new Cart()
                    //        {
                    //            ItemId = item.itmSel.ITEM.id_item,
                    //            ItemTitle = item.itmSel.ITEM.item_title,
                    //        });


                    //    }




                    //}



                    return cart;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
