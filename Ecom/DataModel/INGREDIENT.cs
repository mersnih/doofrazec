namespace Ecom.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INGREDIENT")]
    public partial class INGREDIENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INGREDIENT()
        {
            item_selection = new HashSet<item_selection>();
            menu_selection = new HashSet<menu_selection>();
        }

        [Key]
        public int id_ingredient { get; set; }

        [Required]
        [StringLength(50)]
        public string ingredient_title { get; set; }

        [StringLength(255)]
        public string ingredient_description { get; set; }

        [StringLength(50)]
        public string ingredient_image { get; set; }

        public decimal ingredient_price { get; set; }

        public bool actif { get; set; }

        public int id_category_ingredient { get; set; }

        public virtual CATEGORY_INGREDIENT CATEGORY_INGREDIENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<item_selection> item_selection { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<menu_selection> menu_selection { get; set; }
    }
}
