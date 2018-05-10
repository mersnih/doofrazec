using Ecom.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
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
    /// Logique d'interaction pour Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        List<Printer> printerList;
        ManagementObjectSearcher query;


        public Settings()
        {
            InitializeComponent();
            printerList = new List<Printer>();
            query = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
            var printers = query.Get();

            foreach (ManagementObject p in printers)
            {
                printerList.Add(new Printer
                {
                    Name = p["name"].ToString()
                });
           
            }
            comboBoxPrinter.ItemsSource = printerList;
            if (Properties.Settings.Default.printerName != null && Properties.Settings.Default.printerName != "")
            {
                comboBoxPrinter.SelectedValue = Properties.Settings.Default.printerName;
            }
           
        }

        private void SavePrinter(object sender, RoutedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.printerName = comboBoxPrinter.SelectedValue.ToString();
                Properties.Settings.Default.Save();
                var printers = query.Get();
                foreach (ManagementObject p in printers)
                {
                    if (p["name"].ToString() == Properties.Settings.Default.printerName.ToString())
                    {
                        p.InvokeMethod("SetDefaultPrinter", null, null);
                    }
                }
                MessageBox.Show(comboBoxPrinter.SelectedValue.ToString()+ " enregitrée avec succès !");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
