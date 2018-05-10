namespace Ecom.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADVICE")]
    public partial class ADVICE
    {
        [Key]
        public int id_advice { get; set; }

        [Column("advice")]
        public string advice1 { get; set; }

        public int? advice_note { get; set; }

        [Required]
        public string id_user { get; set; }

        public int id_item { get; set; }

        public virtual ITEM ITEM { get; set; }
    }
}
