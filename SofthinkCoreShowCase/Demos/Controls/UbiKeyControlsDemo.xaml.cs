using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Printing;
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
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using System.Windows.Xps.Serialization;
using Microsoft.Ink;

namespace SofthinkCoreShowCase.Demos.Controls
{
    /// <summary>
    /// Interaction logic for UbiKeyControlsDemo.xaml
    /// </summary>
    [SofthinkCoreShowCase.DemoManager.Demo(Name = "Controls")]
    public partial class UbiKeyControlsDemo : UserControl
    {
        public UbiKeyControlsDemo()
        {
            InitializeComponent();
        }

        private void TouchButton_ButtonTap(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("ExportRTF.rtf", FileMode.Create))
            {
                var txt = new TextRange(richbox.Document.ContentStart,richbox.Document.ContentEnd);
                txt.Save(fs,DataFormats.Rtf);
            }
         
        }

        private void TouchButton_ButtonTap_1(object sender, RoutedEventArgs e)
        {
            /*if (File.Exists("ExportXPS.xps"))
                File.Delete("ExportXPS.xps");
            using (FileStream stream = new FileStream("ExportXPS.xps", FileMode.OpenOrCreate))
            {
                using (Package package = Package.Open(stream, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (XpsDocument xpsDoc = new XpsDocument(package, CompressionOption.Maximum))
                    {
                        XpsSerializationManager rsm = new XpsSerializationManager(new XpsPackagingPolicy(xpsDoc) , false);
                        DocumentPaginator paginator = ((IDocumentPaginatorSource)richbox.Document).DocumentPaginator; 
                        var conv = new LengthConverter();
                        paginator.
                        paginator.PageSize = new Size((double)conv.ConvertFrom("21cm"), (double)conv.ConvertFrom("29cm"));
                        rsm.SaveAsXaml(paginator);
                        rsm.Commit();
                    }
                }

                var pdfXpsDoc = PdfSharp.Xps.XpsModel.XpsDocument.Open(stream);
                PdfSharp.Xps.XpsConverter.Convert(pdfXpsDoc, "ExportPdf.pdf", 0);
            }*/

            TextRange sourceDocument = new TextRange(richbox.Document.ContentStart, richbox.Document.ContentEnd);
            MemoryStream stream = new MemoryStream();
            sourceDocument.Save(stream, DataFormats.XamlPackage);

            // Clone the source document's content into a new FlowDocument.
            FlowDocument flowDocumentCopy = new FlowDocument();
            TextRange copyDocumentRange = new TextRange(flowDocumentCopy.ContentStart, flowDocumentCopy.ContentEnd);
            copyDocumentRange.Load(stream, DataFormats.XamlPackage);

            // Create a XpsDocumentWriter object, open a Windows common print dialog.
            // This methods returns a ref parameter that represents information about the dimensions of the printer media.
            PrintDocumentImageableArea ia = null;
            XpsDocumentWriter docWriter = PrintQueue.CreateXpsDocumentWriter(ref ia);

            if (docWriter != null && ia != null)
            {
                DocumentPaginator paginator = ((IDocumentPaginatorSource)flowDocumentCopy).DocumentPaginator;


                var p =paginator.GetPage(0);
               
               

                // Change the PageSize and PagePadding for the document to match the CanvasSize for the printer device.
                paginator.PageSize = new Size(ia.MediaSizeWidth, ia.MediaSizeHeight);
                Thickness pagePadding = flowDocumentCopy.PagePadding;
                flowDocumentCopy.PagePadding = new Thickness(
                        Math.Max(ia.OriginWidth, pagePadding.Left),
                        Math.Max(ia.OriginHeight, pagePadding.Top),
                        Math.Max(ia.MediaSizeWidth - (ia.OriginWidth + ia.ExtentWidth), pagePadding.Right),
                        Math.Max(ia.MediaSizeHeight - (ia.OriginHeight + ia.ExtentHeight), pagePadding.Bottom));
                //flowDocumentCopy.ColumnWidth = double.PositiveInfinity;

                // Send DocumentPaginator to the printer.
                docWriter.Write(paginator);
            }
        }      
           
    }
           
}
