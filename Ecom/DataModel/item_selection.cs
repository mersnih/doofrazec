namespace Ecom.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class item_selection
    {
        [Key]
        public int id_itemSelection { get; set; }

        public int? item_selection_quantity { get; set; }

        public string item_selection_note { get; set; }

        public int? id_ingredient { get; set; }

        public int id_item { get; set; }

        public int id_orders { get; set; }

        public int? id_menu { get; set; }

        public virtual INGREDIENT INGREDIENT { get; set; }

        public virtual ITEM ITEM { get; set; }

        public virtual MENU MENU { get; set; }

        public virtual ORDERS ORDERS { get; set; }
    }
}
