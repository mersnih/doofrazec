using Ecom.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using Ecom.ViewModel;
using Ecom.DataModel;
using Ecom.Tools;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;

using System.Windows.Documents;
using System.Windows;
using System.Printing;
using System.Management;

namespace Ecom.View
{
    /// <summary>
    /// Logique d'interaction pour Test.xaml
    /// </summary>
    public partial class OrderSend : UserControl
    {
        ModelCezar db = new ModelCezar();
        CartViewModel cvm = new CartViewModel();

        ObservableCollection<Cart> cartList = new ObservableCollection<Cart>();
        OrderViewModel ovm;
        double totalPrice = 0;
        double totalRestPrice = 0;
        private int _currentPrintPage;
        private int _maxPage;

        public OrderSend(Object cl, double total, double totalRest)
        {
            InitializeComponent();
            cartList = cl as ObservableCollection<Cart>;
            totalPrice = total;
            totalRestPrice = totalRest;
            ovm = new OrderViewModel();
        }


        private void eatin(object sender, RoutedEventArgs e)
        {
            ORDERS orderModel = new ORDERS();
            item_selection itemSelection = new item_selection();
            var testValue = db.ORDERS.OrderByDescending(p => p.orders_number).Where(p => p.id_orders_type == 1).Select(q => q.orders_number).FirstOrDefault();
         

            orderModel.orders_number = Service.GetNextCode("SPL", testValue);
            orderModel.id_orders_status = 1;
            orderModel.id_orders_type = Convert.ToInt32(((Button)sender).Tag);
            orderModel.orders_date = DateTime.Today;
            orderModel.orders_delay_date = null;
            orderModel.orders_price = (decimal)totalPrice; // total commande
            orderModel.orders_leftToPay = (decimal)totalRestPrice; // reste à payer 
                       
            db.ORDERS.Add(orderModel);
            db.SaveChanges();

            int idOrder = orderModel.id_orders;

            foreach(var item in cartList)
            {
                itemSelection = new item_selection();

      

                if(item.SelectedIngredients!= null && item.SelectedIngredients.Count > 0)
                {
                    foreach (var subItem in item.SelectedIngredients)
                    {
                        itemSelection.id_item = item.ItemId;
                        itemSelection.id_orders = idOrder;
                        itemSelection.id_ingredient = subItem.IdIngredient;
                        itemSelection.item_selection_quantity = item.ItemQuantity;
                        db.item_selection.Add(itemSelection);
                        db.SaveChanges();
                    }

                }
                else
                {
                    itemSelection.id_item = item.ItemId;
                    itemSelection.id_orders = idOrder;
                    itemSelection.item_selection_quantity = item.ItemQuantity;
                    db.item_selection.Add(itemSelection);
                    db.SaveChanges();
                }          
            }   
                   
     
            cvm.Payement = new ObservableCollection<Payement>();
            cvm.TotalCart = null;
            cvm.TotalRest = null;
            new Commandes();
            #region PRINT
            // Show Print Dialog
            PrintDialog printDialog = new PrintDialog();
          
            FlowDocument document = new FlowDocument();
            System.Windows.Documents.Paragraph par = new System.Windows.Documents.Paragraph();
            par.FontFamily = new System.Windows.Media.FontFamily("Times");
            System.Windows.Documents.Paragraph subPar = new System.Windows.Documents.Paragraph(); 
            document.ColumnWidth = printDialog.PrintableAreaWidth;
            document.PagePadding = new Thickness(25);
            Span s = new Span();
            s = new Span(new Run("Le Cezar food"));           
            s.Inlines.Add(new LineBreak());//Line break is used for next line.  
            par.Inlines.Add(s);// Add the span content into paragraph.


            par.Inlines.Add(new Span(new Run("Ticket fabrication")));
            par.Inlines.Add(new LineBreak());//Line break is used for next line. 
            par.Inlines.Add(new Span(new Run("Sur place")));
            par.Inlines.Add(new LineBreak());//Line break is used for next line. 
            par.Inlines.Add(new Span(new Run("Commande n° "+ orderModel.orders_number)));
            par.Inlines.Add(new LineBreak());//Line break is used for next line. 
            par.Inlines.Add(new Span(new Run("-------------------------------------")));
            document.Blocks.Add(par);

            foreach (var item in cartList.Where(c => c.Cooked == true))
            {

                par = new System.Windows.Documents.Paragraph(new Run(item.ItemQuantity.ToString()+" x "+  item.ItemTitle.ToString()));
                par.FontSize = 14;
                par.TextAlignment = TextAlignment.Left;
                document.Blocks.Add(par);
                if (item.SelectedIngredients != null)
                {
                    subPar = new System.Windows.Documents.Paragraph();
                    foreach (var subItem in item.SelectedIngredients)
                    {
                        subPar.Inlines.Add(new Span(new Run(subItem.Ingredient_quantity+" x "+  subItem.Ingredient_title.ToString())));
                        subPar.Inlines.Add( new Span(new Run("   ")));
                        subPar.FontSize = 12;
                        subPar.TextAlignment = TextAlignment.Center;
                        document.Blocks.Add(subPar);
                    }
                }
            }
            System.Windows.Documents.Paragraph par1 = new System.Windows.Documents.Paragraph();

            par1.Inlines.Add(new LineBreak());//Line break is used for next line. 
            par1.Inlines.Add(new Span(new Run("-------------------------------------")));
   
            document.Blocks.Add(par1);
            foreach (var item in cartList.Where(c => c.Cooked == false))
            {

                par1 = new System.Windows.Documents.Paragraph(new Run(item.ItemQuantity.ToString() + " x " + item.ItemTitle.ToString()));
                par1.FontSize = 14;
                par1.TextAlignment = TextAlignment.Left;
                document.Blocks.Add(par1);
               
            }


            //Config printer
            //var query = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
            //var printers = query.Get();
            //string printerName = Properties.Settings.Default.printerName;

            //foreach (ManagementObject p in printers)
            //{
            //    if (p["name"].ToString() == printerName.ToString())
            //    {
            //        p.InvokeMethod("SetDefaultPrinter", null, null);
            //    }
            //}


            //document.Blocks.Add(par);
            //  fdViewer.Document = document;





            IDocumentPaginatorSource idpSource = document;
            printDialog.PrintDocument(idpSource.DocumentPaginator, "Receipt");
            //Give style and formatting to paragraph content.  
            //par.FontSize = 14;
            //par.FontStyle = FontStyles.Normal;
            //par.TextAlignment = TextAlignment.Left;
            //document.Blocks.Add(par);
            //  DoThePrint(document);

            #endregion
            //ExportDataTableToPdf(cartList, @"C:\Users\Wave\Documents\Visual Studio 2015\Projects\Le cezar food caisse\CezarCaisse_v.0.1\Ecom\Resources\test.pdf", "Friend List");
            cartList.Clear();
        }

        private void takeout(object sender, RoutedEventArgs e)
        {
       
            ORDERS orderModel = new ORDERS();
            item_selection itemSelection = new item_selection();
            var testValue = db.ORDERS.OrderByDescending(p => p.orders_number).Where(p => p.id_orders_type == 2).Select(q => q.orders_number).FirstOrDefault();


            orderModel.orders_number = Service.GetNextCode("EMP", testValue);
            orderModel.id_orders_status = 1;
            orderModel.id_orders_type = Convert.ToInt32(((Button)sender).Tag);
            orderModel.orders_date = DateTime.Today;
            orderModel.orders_delay_date = null;
            orderModel.orders_price = (decimal)totalPrice;
            orderModel.orders_leftToPay = (decimal)totalRestPrice;

            db.ORDERS.Add(orderModel);
            db.SaveChanges();

            int idOrder = orderModel.id_orders;

            foreach (var item in cartList)
            {
                itemSelection = new item_selection();

                itemSelection.id_item = item.ItemId;
                itemSelection.id_orders = idOrder;

                if (item.SelectedIngredients!= null &&  item.SelectedIngredients.Count > 0)
                {
                    foreach (var subItem in item.SelectedIngredients)
                    {
                        itemSelection.id_ingredient = subItem.IdIngredient;

                        db.item_selection.Add(itemSelection);
                        db.SaveChanges();
                    }
                }
                else
                {
                    db.item_selection.Add(itemSelection);
                    db.SaveChanges();
                }
            }

            #region PRINT
            // Show Print Dialog
            PrintDialog printDialog = new PrintDialog();

            FlowDocument document = new FlowDocument();
            System.Windows.Documents.Paragraph par = new System.Windows.Documents.Paragraph();
            par.FontFamily = new System.Windows.Media.FontFamily("Times");
            System.Windows.Documents.Paragraph subPar = new System.Windows.Documents.Paragraph();
            document.ColumnWidth = printDialog.PrintableAreaWidth;
            document.PagePadding = new Thickness(25);
            Span s = new Span();
            s = new Span(new Run("Le Cezar food"));
            s.Inlines.Add(new LineBreak());//Line break is used for next line.  
            par.Inlines.Add(s);// Add the span content into paragraph.


            par.Inlines.Add(new Span(new Run("Ticket fabrication")));
            par.Inlines.Add(new LineBreak());//Line break is used for next line. 
            par.Inlines.Add(new Span(new Run("A Emporté")));
            par.Inlines.Add(new LineBreak());//Line break is used for next line. 
            par.Inlines.Add(new Span(new Run("Commande n° " + orderModel.orders_number)));
            par.Inlines.Add(new LineBreak());//Line break is used for next line. 
            par.Inlines.Add(new Span(new Run("-------------------------------------")));
            document.Blocks.Add(par);

            foreach (var item in cartList.Where(c => c.Cooked == true))
            {

                par = new System.Windows.Documents.Paragraph(new Run(item.ItemQuantity.ToString() + " x " + item.ItemTitle.ToString()));
                par.FontSize = 14;
                par.TextAlignment = TextAlignment.Left;
                document.Blocks.Add(par);
                if (item.SelectedIngredients != null)
                {
                    subPar = new System.Windows.Documents.Paragraph();
                    foreach (var subItem in item.SelectedIngredients)
                    {
                        subPar.Inlines.Add(new Span(new Run(subItem.Ingredient_quantity + " x " + subItem.Ingredient_title.ToString())));
                        subPar.Inlines.Add(new Span(new Run("   ")));
                        subPar.FontSize = 12;
                        subPar.TextAlignment = TextAlignment.Center;
                        document.Blocks.Add(subPar);
                    }
                }
            }
            System.Windows.Documents.Paragraph par1 = new System.Windows.Documents.Paragraph();

            par1.Inlines.Add(new LineBreak());//Line break is used for next line. 
            par1.Inlines.Add(new Span(new Run("-------------------------------------")));

            document.Blocks.Add(par1);
            foreach (var item in cartList.Where(c => c.Cooked == false))
            {

                par1 = new System.Windows.Documents.Paragraph(new Run(item.ItemQuantity.ToString() + " x " + item.ItemTitle.ToString()));
                par1.FontSize = 14;
                par1.TextAlignment = TextAlignment.Left;
                document.Blocks.Add(par1);

            }


            //Config printer
            //var query = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
            //var printers = query.Get();
            //string printerName = Properties.Settings.Default.printerName;

            //foreach (ManagementObject p in printers)
            //{
            //    if (p["name"].ToString() == printerName.ToString())
            //    {
            //        p.InvokeMethod("SetDefaultPrinter", null, null);
            //    }
            //}


            //document.Blocks.Add(par);
            //  fdViewer.Document = document;





            IDocumentPaginatorSource idpSource = document;
            printDialog.PrintDocument(idpSource.DocumentPaginator, "Receipt");
            //Give style and formatting to paragraph content.  
            //par.FontSize = 14;
            //par.FontStyle = FontStyles.Normal;
            //par.TextAlignment = TextAlignment.Left;
            //document.Blocks.Add(par);
            //  DoThePrint(document);

            #endregion



            cartList.Clear();
            cvm.Payement = new ObservableCollection<Payement>();
            cvm.TotalCart = null;
            cvm.TotalRest = null;
            new MainWindowViewModel();
        }
        //void ExportDataTableToPdf(ObservableCollection<Cart> dtblTable, String strPdfPath, string strHeader)
        //{
        //    System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
        //    Document document = new Document();
        //    document.SetPageSize(iTextSharp.text.PageSize.A4);
        //    PdfWriter writer = PdfWriter.GetInstance(document, fs);
        //    document.Open();

        //    //Report Header
        //    BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //    Font fntHead = new Font(bfntHead, 16, 1, BaseColor.GRAY);
        //    Paragraph prgHeading = new Paragraph();
        //    prgHeading.Alignment = Element.ALIGN_CENTER;
        //    prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
        //    document.Add(prgHeading);

        //    //Author
        //    Paragraph prgAuthor = new Paragraph();
        //    BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //    Font fntAuthor = new Font(btnAuthor, 8, 2, BaseColor.GRAY);
        //    prgAuthor.Alignment = Element.ALIGN_RIGHT;
        //    prgAuthor.Add(new Chunk("Author : Dotnet Mob", fntAuthor));
        //    prgAuthor.Add(new Chunk("\nRun Date : " + DateTime.Now.ToShortDateString(), fntAuthor));
        //    document.Add(prgAuthor);

        //    //Add a line seperation
        //    Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
        //    document.Add(p);

        //    //Add line break
        //    document.Add(new Chunk("\n", fntHead));

        //    //Write the table
        //    PdfPTable table = new PdfPTable(1);
        //    //Table header
        //    BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //    Font fntColumnHeader = new Font(btnColumnHeader, 10, 1, BaseColor.GRAY);
        //    //for (int i = 0; i < dtblTable.Count; i++)
        //    //{
        //    //    PdfPCell cell = new PdfPCell();
        //    //    cell.BackgroundColor = Color.GRAY;
        //    //    cell.AddElement(new Chunk(dtblTable[i].ItemTitle.ToUpper(), fntColumnHeader));
        //    //    table.AddCell(cell);
        //    //}
        //    //table Data
        //   foreach(var item in dtblTable)
        //    { 

        //            document.Add( new Paragraph( item.ItemTitle.ToUpper().ToString()));

        //    }

        //    document.Add(table);
        //    document.Close();
        //    writer.Close();
        //    fs.Close();
        //    PrintDialog pDialog = new PrintDialog();
        //    pDialog.PageRangeSelection = PageRangeSelection.AllPages;
        //    pDialog.UserPageRangeEnabled = true;

        //    // Display the dialog. This returns true if the user presses the Print button.
        //    Nullable<Boolean> print = pDialog.ShowDialog();
        //    if (print == true)
        //    {
        //        System.Xml.XmlDocument xpsDocument = new System.Xml.Linq.XDocument("C:\\FixedDocumentSequence.xps", FileAccess.ReadWrite);
        //        FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();
        //        pDialog.PrintDocument(document, "Test print job");
        //    }
        //}


        private void DoThePrint(System.Windows.Documents.FlowDocument document)
        {
            // Clone the source document's content into a new FlowDocument.
            // This is because the pagination for the printer needs to be
            // done differently than the pagination for the displayed page.
            // We print the copy, rather that the original FlowDocument.
            System.IO.MemoryStream s = new System.IO.MemoryStream();
            TextRange source = new TextRange(document.ContentStart, document.ContentEnd);
            source.Save(s, DataFormats.Xaml);
            FlowDocument copy = new FlowDocument();
            TextRange dest = new TextRange(copy.ContentStart, copy.ContentEnd);
            dest.Load(s, DataFormats.Xaml);

            // Create a XpsDocumentWriter object, implicitly opening a Windows common print dialog,
            // and allowing the user to select a printer.

            // get information about the dimensions of the seleted printer+media.
            System.Printing.PrintDocumentImageableArea ia = null;
            System.Windows.Xps.XpsDocumentWriter docWriter = System.Printing.PrintQueue.CreateXpsDocumentWriter(ref ia);

            if (docWriter != null && ia != null)
            {
                DocumentPaginator paginator = ((IDocumentPaginatorSource)copy).DocumentPaginator;

                // Change the PageSize and PagePadding for the document to match the CanvasSize for the printer device.
                paginator.PageSize = new Size(ia.MediaSizeWidth, ia.MediaSizeHeight);
                Thickness t = new Thickness(72);  // copy.PagePadding;
                copy.PagePadding = new Thickness(
                                 Math.Max(ia.OriginWidth, t.Left),
                                   Math.Max(ia.OriginHeight, t.Top),
                                   Math.Max(ia.MediaSizeWidth - (ia.OriginWidth + ia.ExtentWidth), t.Right),
                                   Math.Max(ia.MediaSizeHeight - (ia.OriginHeight + ia.ExtentHeight), t.Bottom));

                copy.ColumnWidth = double.PositiveInfinity;
                //copy.PageWidth = 528; // allow the page to be the natural with of the output device

                // Send content to the printer.
                docWriter.Write(paginator);
            }

        }


    }
}
