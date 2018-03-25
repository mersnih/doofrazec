using Ecom.Model;
using Ecom.Tools;
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
  
        public ItemList[] Items { get; }
        public MainWindowViewModel()
        {         
            Items = new[] { new ItemList("ViewQuilt", "#505f89", "Caisse", new Caisse()), new ItemList("PlusOne", "#505f89", "Commandes", new Commandes()), new ItemList("settings", "#E55050", "Gestion produit", new Management()), new Model.ItemList("chartLine", "#63A06D", "Statistiques",null) };
              // new Liste();    
        }
    }
}
