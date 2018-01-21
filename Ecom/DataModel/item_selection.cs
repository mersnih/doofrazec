namespace Ecom.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class item_selection
    {
        public int? item_selection_quantity { get; set; }

        [StringLength(500)]
        public string item_selection_note { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_ingredient { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_item { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_orders { get; set; }

        public virtual INGREDIENT INGREDIENT { get; set; }

        public virtual ITEM ITEM { get; set; }

        public virtual ORDERS ORDERS { get; set; }
    }
}
