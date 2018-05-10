namespace Ecom.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MENU")]
    public partial class MENU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MENU()
        {
            item_selection = new HashSet<item_selection>();
            OPTION_CHOIX_MENU = new HashSet<OPTION_CHOIX_MENU>();
        }

        [Key]
        public int id_menu { get; set; }

        [Required]
        public string menu_title { get; set; }

        public string menu_description { get; set; }

        public decimal menu_price { get; set; }

        public decimal? menu_promotion_price { get; set; }

        public bool actif { get; set; }

        public int id_item { get; set; }

        public virtual ITEM ITEM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<item_selection> item_selection { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OPTION_CHOIX_MENU> OPTION_CHOIX_MENU { get; set; }
    }
}
