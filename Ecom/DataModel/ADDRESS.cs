namespace Ecom.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADDRESS")]
    public partial class ADDRESS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ADDRESS()
        {
            ORDERS = new HashSet<ORDERS>();
        }

        [Key]
        public int id_address { get; set; }

        [Required]
        [StringLength(25)]
        public string address_title { get; set; }

        public int street_number { get; set; }

        [Required]
        [StringLength(50)]
        public string street_name { get; set; }

        public int zip_code { get; set; }

        [Required]
        [StringLength(25)]
        public string city { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERS> ORDERS { get; set; }
    }
}
