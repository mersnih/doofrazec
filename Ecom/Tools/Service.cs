using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Tools
{
    class Service
    {
        public static string GetNextCode(string cmdType, string sLastCode)
        {
            // SPL0001
            // EMP0001

            if (String.IsNullOrEmpty(sLastCode) && cmdType == "SPL" || sLastCode == "SPL9999")
                return "SPL0001";
            if (String.IsNullOrEmpty(sLastCode) && cmdType == "EMP" || sLastCode == "EMPL9999")
                return "EMP0001";

            // Suivant
            string sNextCode = string.Empty;

            string prefixe = sLastCode.Substring(0, 3);
            string number = sLastCode.Substring(3);


            if(Convert.ToInt32(number) == 9999 )
            {
                sNextCode = prefixe + "0001";
            }
            else
            {
                sNextCode = prefixe + (Convert.ToInt32(number) + 1).ToString("0000");
            }



            // Fait attention aux bornes inf et supp
            //if (String.IsNullOrEmpty(sLastCode) || sLastCode == "Z9999")
            //    return "A0001";



            // Suivant
           // string sNextCode = string.Empty;

            //if (Convert.ToInt32(sLastCode.Substring(1, 4)) == 9999)
            //    sNextCode = (((char)((int)sLastCode[0]) == 'Z') ? 'A' : (char)((int)sLastCode[0] + 1)) + "0001";
            //else
            //    sNextCode = (char)((int)sLastCode[0]) + (Convert.ToInt32(sLastCode.Substring(1, 4)) + 1).ToString("0000");

            return sNextCode;
        }
    }
}
