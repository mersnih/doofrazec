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
            ITEM_OPTION_MENU = new HashSet<ITEM_OPTION_MENU>();
            item_selection = new HashSet<item_selection>();
            MENU = new HashSet<MENU>();
            CATEGORY_INGREDIENT = new HashSet<CATEGORY_INGREDIENT>();
        }

        [Key]
        public int id_item { get; set; }

        [Required]

        public string item_title { get; set; }


        public string item_decription { get; set; }


        public string item_image { get; set; }

        public int? item_quantity { get; set; }

        public decimal item_price { get; set; }

        public decimal? item_promotion_price { get; set; }

        [Required]
        public string item_button_color { get; set; }

        public bool actif { get; set; }

        public bool cooked { get; set; }

        public int id_category { get; set; }

        public int? id_tag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ADVICE> ADVICE { get; set; }

        public virtual CATEGORY CATEGORY { get; set; }

        public virtual TAG TAG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITEM_OPTION_MENU> ITEM_OPTION_MENU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<item_selection> item_selection { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENU> MENU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CATEGORY_INGREDIENT> CATEGORY_INGREDIENT { get; set; }
    }
}
