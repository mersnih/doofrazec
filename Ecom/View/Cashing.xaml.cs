using Ecom.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ecom.View
{
    /// <summary>
    /// Logique d'interaction pour Cashing.xaml
    /// </summary>
    public partial class Cashing : UserControl
    {
        CartViewModel cvm = new CartViewModel();
        double temp = 0.00;
        double totalPrice = 0.00;
        public Cashing(Object pl, double total)
        {
            InitializeComponent();
            totalPrice = total;
            tb_total.Text = "Total dû : " + totalPrice.ToString()+"€";
         
          
        }
        // Foreach key pad number click, this event method is called 
        private void buttonNumberClick(object sender, RoutedEventArgs e)
        {
            //Get number entred 
            double number = Math.Round(Double.Parse(((sender as Button).Content).ToString()),2);
   
            if (number > 0)
            {
                temp = Math.Round((temp * 10 + (number / 100.00)), 2);
            }
            else
            {
                temp = Math.Round((temp * 10),2);
            }
                     
            tb_number.Text = temp.ToString("0.00") + "€";

            if((totalPrice - temp) > 0)
              tb_totalRest.Text = "/Reste: " + Math.Round((totalPrice - temp),2).ToString() + "€";
            else
              tb_totalRest.Text = "/Trop perçu : " + Math.Round((temp - totalPrice),2).ToString() + "€";
        }

        private void buttonDeleteClick(object sender, RoutedEventArgs e)
        {
            temp = 0.00;
            tb_number.Text = temp.ToString("0.00");
            tb_totalRest.Text = "";
        }

        private void buttonCashClick(object sender, RoutedEventArgs e)
        {
            if(lb_cash.SelectedItem != null)
            {
             //   cvm.TotalRest = (totalPrice - temp).ToString();
                cvm.Payement.Add(new Model.Payement
                {
                    PayementType = tb_payementType.Text.ToString(),
                    PayementValue = temp
                });
            //    totalPrice = Double.Parse(cvm.TotalRest);
            }                     
        }
    }
}
