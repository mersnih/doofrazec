namespace Ecom.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OPTION_CHOIX_MENU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OPTION_CHOIX_MENU()
        {
            ITEM_OPTION_MENU = new HashSet<ITEM_OPTION_MENU>();
            MENU = new HashSet<MENU>();
        }

        [Key]
        public int id_option_choix_menu { get; set; }

        [Required]
        public string option_choix_menu_title { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITEM_OPTION_MENU> ITEM_OPTION_MENU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENU> MENU { get; set; }
    }
}
