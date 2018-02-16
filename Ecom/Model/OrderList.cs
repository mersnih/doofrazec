﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.DataModel;
using System.Data.Entity;

namespace Ecom.Model
{
    class OrderList
    {
        ModelCezar db;
        ObservableCollection<Cart> orderList ;
        public OrderList()
        {
            db = new ModelCezar();
            orderList = new ObservableCollection<Cart>();
        }

        public  ObservableCollection<Cart> GetOrderList()
        {
            try
            {
                var queryGenerated = from orders in db.ORDERS

                                     join ot in db.ORDERS_TYPE on orders.id_orders_type equals ot.id_orders_type

                                     select new Cart
                                     {
                                         OrderNumber = orders.orders_number,
                                         OrderDate = orders.orders_date,
                                         OrderType = ot.orders_type_title,
                                  
                                         ItemPriceTxt = orders.orders_price.ToString() + "€",
                                         ItemPriceRestTxt = orders.orders_leftToPay.ToString() + "€"
                                     };
                return new ObservableCollection<Cart>( queryGenerated.ToList());
            }
            catch
            {
                return null;
            }
        }

    }
}
