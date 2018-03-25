using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.ViewModel
{
    class ResultViewModel : INotifyPropertyChanged
    {

        private static bool result;
        private string resultMessage;
        public bool Result
        {
          get { return result; }
            set
            {
                result = value;
                NotifyPropertyChanged("Result");
            }

        }
        public string  Resultmessage
        {
            get { return resultMessage; }
            set
            {
                resultMessage = value;
                NotifyPropertyChanged("Resultmessage");
            }

        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}
