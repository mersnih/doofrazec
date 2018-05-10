using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Tools
{
    class Errors : IDataErrorInfo
    {
        public string tb_name { get; set; }
        public string tb_price { get; set; }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "tb_name")
                {
                    if (string.IsNullOrEmpty(tb_name))
                        result = "Le nom est obligatoire";
                }
                if (columnName == "tb_price")
                {
                    if (string.IsNullOrEmpty(tb_price))
                        result = "Le prix est obligatoire";
                }

                return result;
            }
           
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
            //get { return String.Empty; }
        }
    }
}
