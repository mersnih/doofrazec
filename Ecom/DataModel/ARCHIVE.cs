using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataModel
{
    [Table("ARCHIVE")]
    public partial class ARCHIVE
    {
        [Key]
        public int id_archive { get; set; }

        [Required]
        public string archive_itemTitle { get; set; }

        public string archive_ingredient { get; set; }

        [Required]
        public string archive_itemPrice { get; set; }

        public int id_orders { get; set; }

        public virtual ORDERS ORDERS { get; set; }
    }
}
