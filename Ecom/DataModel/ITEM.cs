namespace Ecom.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITEM")]
    public partial class ITEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ITEM()
        {
            ADVICE = new HashSet<ADVICE>();
            item_selection = new HashSet<item_selection>();
            MENU = new HashSet<MENU>();
            menu_selection = new HashSet<menu_selection>();
            MENU1 = new HashSet<MENU>();
            INGREDIENT = new HashSet<INGREDIENT>();
        }

        [Key]
        public int id_item { get; set; }

        [Required]
        [StringLength(25)]
        public string item_title { get; set; }

        [StringLength(255)]
        public string item_decription { get; set; }

        [StringLength(50)]
        public string item_image { get; set; }

        public int? item_quantity { get; set; }

        public decimal item_price { get; set; }

        public decimal? item_promotion_price { get; set; }

        [StringLength(50)]
        public string item_button_color { get; set; }

        public bool actif { get; set; }

        public int id_category { get; set; }

        public int? id_tag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ADVICE> ADVICE { get; set; }

        public virtual CATEGORY CATEGORY { get; set; }

        public virtual TAG TAG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<item_selection> item_selection { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENU> MENU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<menu_selection> menu_selection { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENU> MENU1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INGREDIENT> INGREDIENT { get; set; }
    }
}
