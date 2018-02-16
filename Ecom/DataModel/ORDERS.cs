namespace Ecom.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ORDERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDERS()
        {
            item_selection = new HashSet<item_selection>();
            menu_selection = new HashSet<menu_selection>();
            PAYEMENT_DETAIL = new HashSet<PAYEMENT_DETAIL>();
        }

        [Key]
        public int id_orders { get; set; }

        [Required]
        [StringLength(25)]
        public string orders_number { get; set; }

        public decimal orders_price { get; set; }

        public decimal? orders_leftToPay { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime orders_date { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? orders_delay_date { get; set; }

        [StringLength(100)]
        public string id_user { get; set; }

        public int id_orders_type { get; set; }

        public int id_orders_status { get; set; }

        public int? id_address { get; set; }

        public virtual ADDRESS ADDRESS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<item_selection> item_selection { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<menu_selection> menu_selection { get; set; }

        public virtual ORDERS_STATUS ORDERS_STATUS { get; set; }

        public virtual ORDERS_TYPE ORDERS_TYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAYEMENT_DETAIL> PAYEMENT_DETAIL { get; set; }
    }
}
