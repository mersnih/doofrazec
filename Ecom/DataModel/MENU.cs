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
            menu_selection = new HashSet<menu_selection>();
            ITEM = new HashSet<ITEM>();
        }

        [Key]
        public int id_menu { get; set; }

        [Required]
        [StringLength(25)]
        public string menu_title { get; set; }

        [StringLength(255)]
        public string menu_description { get; set; }

        public decimal menu_price { get; set; }

        public decimal? menu_promotion_price { get; set; }

        public bool actif { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<menu_selection> menu_selection { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITEM> ITEM { get; set; }
    }
}
