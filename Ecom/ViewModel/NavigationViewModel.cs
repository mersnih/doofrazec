using Ecom.Model;
using Ecom.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ecom.ViewModel
{
    class NavigationViewModel : INotifyPropertyChanged
    {
        public ICommand GenCommand { get; set; }
        public ICommand ListeCommand { get; set; }
        public ItemList[] Items { get; set; }
        private bool isVisibleCaisseList;
        public bool IsVisibleCaisseList
        {
            get { return isVisibleCaisseList; }
            set { isVisibleCaisseList = value; OnPropertyChanged("IsVisibleCaisseList"); }

        }

        private object selectedViewModel;
        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }
        public NavigationViewModel()
        {
            GenCommand = new BaseCommand(OpenOrderPlusOneView);
            ListeCommand = new BaseCommand(OpenCaisseView);
            IsVisibleCaisseList = true;
          

        }

        private void OpenCaisseView(object obj)
        {
            SelectedViewModel = new Caisse();
            IsVisibleCaisseList = true;
        }

        private void OpenOrderPlusOneView(object obj)
        {
            SelectedViewModel = new Commandes();
            IsVisibleCaisseList = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

    }
    public class BaseCommand : ICommand
    {
        private Predicate<object> _canExecute;
        private Action<object> _method;
        public event EventHandler CanExecuteChanged;

        public BaseCommand(Action<object> method)
            : this(method, null)
        {
        }

        public BaseCommand(Action<object> method, Predicate<object> canExecute)
        {
            _method = method;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _method.Invoke(parameter);
        }
    }
}
