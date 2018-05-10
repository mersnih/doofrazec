namespace Ecom.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PAYEMENT_DETAIL
    {
        [Key]
        public int id_payement_detail { get; set; }

        [Required]
        public string way { get; set; }

        public decimal payement_detail_price { get; set; }

        public int id_orders { get; set; }

        public virtual ORDERS ORDERS { get; set; }
    }
}
