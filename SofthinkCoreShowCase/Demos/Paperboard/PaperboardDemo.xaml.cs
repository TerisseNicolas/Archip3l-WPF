using SofthinkCore.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
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
using System.Windows.Xps.Packaging;
using System.Windows.Xps.Serialization;

namespace SofthinkCoreShowCase.Demos.Paperboard
{
    /// <summary>
    /// Interaction logic for PaperboardDemo.xaml
    /// </summary>
    [SofthinkCoreShowCase.DemoManager.Demo(Name = "Paperboard")]
    public partial class PaperboardDemo : UserControl
    {
        public PaperboardDemo()
        {
            InitializeComponent();

            editor.Pages = new SofthinkCore.UI.Controls.PaperboardDocument() { PagePadding = new Thickness(30) };

            for(int p =0; p < 10 ; p++)
            {

                FlowDocument flowDoc = new FlowDocument();

                Paragraph pr = new Paragraph(new Run("Page " + p) { FontSize = 30 });
                flowDoc.Blocks.Add(pr);

                for(int i =0; i < 3 ; i++)
                {
                    pr = new Paragraph(new Run(RandomHelper.GetRandomString()));
                    flowDoc.Blocks.Add(pr);
                    pr = new Paragraph(new Run(RandomHelper.GetRandomString()));
                    flowDoc.Blocks.Add(pr);
                    pr = new Paragraph(new Run(RandomHelper.GetRandomString()));
                    flowDoc.Blocks.Add(pr);
                    pr = new Paragraph(new Run(RandomHelper.GetRandomString()));
                    Floater f = new Floater(new BlockUIContainer(//new Rectangle{ Fill = Brushes.Red, Width = 100, Height = 100 }));
                        new Image() { Width = 200 , Source = new BitmapImage(new Uri("pack://application:,,,/Resources/logo300.png")) } ));
                    pr.Inlines.Add(f);
                    flowDoc.Blocks.Add(pr);
                
                }

                editor.Pages.Add(flowDoc);
            }
            
            


        }

        private void button_plus_ButtonTap(object sender, RoutedEventArgs e)
        {
            editor.CurrentPage++;
        }

        private void button_minus_ButtonTap(object sender, RoutedEventArgs e)
        {
            editor.CurrentPage--;
        }

        private void TouchButton_ButtonTap(object sender, RoutedEventArgs e)
        {
            //editor.SaveToPDF();

            var Document = editor.Pages.AssemblePages();

            /*TextRange sourceDocument = new
            TextRange(Document.ContentStart,
            Document.ContentEnd);
            MemoryStream mstream = new MemoryStream();
            sourceDocument.Save(mstream, DataFormats.XamlPackage);*/

            // Clone the source document's content into a new FlowDocument.
            /*FlowDocument flowDocumentCopy = new FlowDocument();
            TextRange copyDocumentRange = new TextRange(flowDocumentCopy.ContentStart,
            flowDocumentCopy.ContentEnd);
            copyDocumentRange.Load(mstream, DataFormats.XamlPackage);*/

            //if (File.Exists("ExportXPS.xps"))
            //    File.Delete("ExportXPS.xps");
            using (MemoryStream stream = new MemoryStream()/*("ExportXPS.xps", FileMode.OpenOrCreate)*/)
            {
                using (Package package = Package.Open(stream, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (XpsDocument xpsDoc = new XpsDocument(package, CompressionOption.Maximum))
                    {
                        XpsSerializationManager rsm = new XpsSerializationManager(new XpsPackagingPolicy(xpsDoc) , false);
                        //flowDocumentCopy.PagePadding = PagePadding;
                        DocumentPaginator paginator = ((IDocumentPaginatorSource)Document).DocumentPaginator; 
                        var conv = new LengthConverter();
                        paginator.PageSize = new Size((double)conv.ConvertFrom("21cm"), (double)conv.ConvertFrom("29cm"));
                        paginator.ComputePageCount();
                        rsm.SaveAsXaml(paginator);
                        rsm.Commit();
                    }
                }

                var pdfXpsDoc = PdfSharp.Xps.XpsModel.XpsDocument.Open(stream);
                PdfSharp.Xps.XpsConverter.Convert(pdfXpsDoc, "ExportPdf.pdf", 0);
            }
        }
    }
}
