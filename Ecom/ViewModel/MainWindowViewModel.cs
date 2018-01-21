using Ecom.Model;
using Ecom.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.ViewModel
{
    class MainWindowViewModel
    {
        public Item[] Items { get; }
        public MainWindowViewModel()
        {
           
                Items = new[] { new Item("ViewQuilt", "#505f89", "Caisse", new Caisse()), new Item("settings", "#E55050", "Gestion produit", null), new Model.Item("chartLine", "#63A06D", "Statistiques",null) };
               // new Liste();
          
        }
    }
}
