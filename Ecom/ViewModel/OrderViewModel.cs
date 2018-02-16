using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.DataModel;

namespace Ecom.ViewModel
{
    public class OrderViewModel
    {
        public ORDERS orders { get; set; }
        public item_selection itemSelection { get; set; }

        public OrderViewModel()
        {
            orders = new ORDERS();
            itemSelection = new item_selection();
        }
    }
}
