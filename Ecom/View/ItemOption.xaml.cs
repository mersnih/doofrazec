using Ecom.DataModel;
using Ecom.Model;
using Ecom.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Ecom.View
{
    /// <summary>
    /// Logique d'interaction pour MeatChoice.xaml
    /// </summary>
    public partial class ItemOption : UserControl
    {
        ModelCezar db;

        ObservableCollection<ItemIngredient> lst = new ObservableCollection<ItemIngredient>();
        // Cette collection contiendra la liste de tous les ingrédients liée à l'article selectionné
        ObservableCollection<ItemIngredient> listIngredient = new ObservableCollection<ItemIngredient>();
        // Cette collection vontiendra la liste des ingrédients selectionnés 
        ObservableCollection<ItemIngredient> itemIngredientLocal = new ObservableCollection<ItemIngredient>();
        //Cette collection récuperera la liste des ingrédients selectionnées à partir de la caisse
        List<CATEGORY_INGREDIENT> catIngLocal = new List<CATEGORY_INGREDIENT>();

        // Mise en place de la carte virtuelle qui va être mise à jour à chaque ajout 
        CartViewModel cvm = new CartViewModel();
        // Mise en place du modele des articles 
        ITEM itemLocal = new ITEM();


        Cart _cart = new Cart();
        int indexLocal = -1;

        // Params d'initialisation
        int catIngLocalCount = 0;
        int counter = 0;
        double totalSupp = 0;

        static IQueryable<ItemIngredient> ingredients;


        // Cette méthode est appelée lorsque l'utilisateur veut modifier un article ajouter dans le panier
        public ItemOption(Cart list, int idItem, int index, List<CATEGORY_INGREDIENT> catIng,ObservableCollection<ItemIngredient> ingredients)
        {
            InitializeComponent();
            counter = 0;

            if (index > -1)
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

                var optionQuery = (from ing in db.INGREDIENT
                                   join ingCat in db.CATEGORY_INGREDIENT on ing.id_category_ingredient equals ingCat.id_category_ingredient
                                   select new ItemIngredient()
                                   {
                                       IdItem = idItem,
                                       IdIngredient = ing.id_ingredient,
                                       Ingredient_category_tutle = ingCat.category_ingredient_title,
                                       Item_title = list.ItemTitle,
                                       Ingredient_category_id = ingCat.id_category_ingredient,
                                       Ingredient_title = ing.ingredient_title,
                                       Ingredient_price = (double)ing.ingredient_price,
                                       Ingredient_quantity = 0

                                   });

                listIngredient = new ObservableCollection<ItemIngredient>(optionQuery.ToList());
                icItem.ItemsSource = listIngredient.Where(i => i.Ingredient_category_id == id);

                ItemIngredient ingrr = new ItemIngredient();

                for(int i = 0; i < listIngredient.Count; i++)
                {
                    ingrr = listIngredient[i] as ItemIngredient;
                    foreach (var itm in ingredients)
                    {
                        if (ingrr.IdIngredient == itm.IdIngredient)
                        {
                            itemIngredientLocal.Add(new ItemIngredient()
                            {
                                IdItem = itm.IdItem,
                                IdIngredient = itm.IdIngredient,
                                Item_title = itm.Item_title,
                                Ingredient_title = itm.Ingredient_title,
                                Ingredient_price = itm.Ingredient_category_id == 3 ? ingrr.Ingredient_price : 0,
                                Ingredient_quantity = itm.Ingredient_quantity
                            });
                            ingrr.Ingredient_quantity = itm.Ingredient_quantity;
                            break;
                        }
                 
                    }
                 
                }           

                #region COMMENT
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

                #endregion
            }
            //    lb_choixViande.SelectedIndex = lb_choixViande.Items.IndexOf(lst[0].Ingredient_title)
        }


        // Cette méthode est appelée lorsque l'utilisateur souhaite ajouter un article dans le panier
        public ItemOption(ITEM item, List<CATEGORY_INGREDIENT> catIng)
        {
            InitializeComponent();
            db = new ModelCezar();
            cvm.IngredientCounter = 0;
            /*
             catIng : la liste des catégories d'ingrédients liées à l'article
             item : l'article selectionné
             catIngLocalCount :  le nombre total des catégories d'ingrédients liées à l'article
             counter : compteur 
            */
            itemLocal = item;
            catIngLocal = catIng;
            catIngLocalCount = catIng.Count;
            counter = 0;

            CATEGORY_INGREDIENT ci = new CATEGORY_INGREDIENT();
            ci = catIng[counter];
            int id = catIng[counter].id_category_ingredient;
            //.Where(i => i.id_category_ingredient == id)
            var optionQuery = (from ing in db.INGREDIENT
                               join ingCat in db.CATEGORY_INGREDIENT on ing.id_category_ingredient equals ingCat.id_category_ingredient
                               select new ItemIngredient()
                               {
                                   IdItem = item.id_item,
                                   IdIngredient = ing.id_ingredient,
                                   Item_title = item.item_title,
                                   Ingredient_title = ing.ingredient_title,
                                   Ingredient_category_id = ingCat.id_category_ingredient,
                                   Ingredient_category_tutle = ingCat.category_ingredient_title,
                                   Ingredient_price = (double)ing.ingredient_price,
                                   Ingredient_quantity = 0
                               });
            listIngredient = new ObservableCollection<ItemIngredient>(optionQuery.ToList());
            //Affiche la première liste des ingrédients
            icItem.ItemsSource = listIngredient.Where(i => i.Ingredient_category_id == id);


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
        // Button next     ->
        private void Next(object sender, RoutedEventArgs e)
        {     
            counter = counter + 1;  
            if (counter <= catIngLocalCount - 1)
            {
                int id = catIngLocal[counter].id_category_ingredient;
                icItem.ItemsSource = listIngredient.Where(i => i.Ingredient_category_id == id);
                if (counter == catIngLocalCount - 1)
                {
                    bt_NextOption.Visibility = Visibility.Collapsed;
                }
                else
                {
                    bt_NextOption.Visibility = Visibility.Visible;
                }
                bt_BackOption.Visibility = Visibility.Visible;
            }
        }
        // Button back    <-
        private void Back(object sender, RoutedEventArgs e)
        {
            if (counter > 0)
            {
                counter = counter - 1;
                int id = catIngLocal[counter].id_category_ingredient;
                icItem.ItemsSource = listIngredient.Where(i => i.Ingredient_category_id == id);
                if (counter == 0)
                {
                    bt_BackOption.Visibility = Visibility.Collapsed;
                }
                else
                {
                    bt_BackOption.Visibility = Visibility.Visible;
                }
                bt_NextOption.Visibility = Visibility.Visible;
            }
        }

        // Button add +
        private void OnClickAddIngredient(object sender, RoutedEventArgs e)
        {

            ItemIngredient ingr = new ItemIngredient();
            //ingr = ((Button)sender).Content as ItemIngredient;

            Button bt  = sender as Button;
            int index = (int)bt.Tag;
            ingr = icItem.Items[index] as ItemIngredient;

            var content = ((Button)sender).Content;
            var item = itemIngredientLocal.FirstOrDefault(i => i.IdIngredient == ingr.IdIngredient);
            if (item != null)
            {
                item.Ingredient_quantity = item.Ingredient_quantity + 1;
                if (ingr.Ingredient_category_id == 3)
                {
                    item.Ingredient_price += item.Ingredient_price;
                }


                tb_value.Text = item.Ingredient_quantity.ToString();
                content = item.Ingredient_quantity.ToString();
                ingr.Ingredient_quantity = item.Ingredient_quantity;



            }

            else
            {
               
                    itemIngredientLocal.Add(new ItemIngredient()
                    {
                        IdItem = ingr.IdItem,

                        IdIngredient = ingr.IdIngredient,
                        Item_title = ingr.Item_title,
                        Ingredient_title = ingr.Ingredient_title,
                        Ingredient_price = ingr.Ingredient_category_id == 3 ? ingr.Ingredient_price : 0,
                        Ingredient_quantity = 1
                    });
                    ingr.Ingredient_quantity = 1;
               
            }
            // tb_value.Text = cvm.IngredientCounter.ToString();


        }

        // Button sub -
        private void OnClickSubstractIngredient(object sender, RoutedEventArgs e)
        {



            ItemIngredient ingr = new ItemIngredient();
            ingr = ((Button)sender).Tag as ItemIngredient;


            var item = itemIngredientLocal.FirstOrDefault(i => i.IdIngredient == ingr.IdIngredient);
            if (item != null)
            {
                if (item.Ingredient_quantity == 1)
                {
                    itemIngredientLocal.Remove(item);
                    ingr.Ingredient_quantity = 0;

                }
                else
                {
                    item.Ingredient_quantity = item.Ingredient_quantity - 1;
                    item.Ingredient_price -= item.Ingredient_price;
                    ingr.Ingredient_quantity = item.Ingredient_quantity;
                }

            }

        }


    }
}
