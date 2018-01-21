namespace Ecom.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CATEGORY_INGREDIENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORY_INGREDIENT()
        {
            INGREDIENT = new HashSet<INGREDIENT>();
        }

        [Key]
        public int id_category_ingredient { get; set; }

        [Required]
        [StringLength(25)]
        public string category_ingredient_title { get; set; }

        [StringLength(500)]
        public string category_ingredient_description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INGREDIENT> INGREDIENT { get; set; }
    }
}
