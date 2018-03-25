namespace Ecom.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ITEM_OPTION_MENU
    {
        public int item_option_menu_quantity { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_item { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_option_choix_menu { get; set; }

        public virtual ITEM ITEM { get; set; }

        public virtual OPTION_CHOIX_MENU OPTION_CHOIX_MENU { get; set; }
    }
}
