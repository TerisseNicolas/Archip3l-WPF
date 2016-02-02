using Microsoft.Ink;
using SofthinkCore.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace SofthinkCoreShowCase.DemoCommon.Controls
{
    /// <summary>
    /// Interaction logic for InkCanvas.xaml
    /// </summary>
    public partial class InkCanvas : UserControl
    {
        public InkCanvas()
        {
            InitializeComponent();
        }

        private void analyseButton_ButtonTap(object sender, RoutedEventArgs e)
        {
            if (inkCanvas.Strokes.Count == 0)
                return;

            var analyser = new System.Windows.Ink.InkAnalyzer();

            using (MemoryStream ms = new MemoryStream())
            {
                this.inkCanvas.Strokes.Save(ms);
                var myInkCollector = new InkCollector();
                var ink = new Ink();
                ink.Load(ms.ToArray());
                //analyser.SetStrokesLanguageId(ink.Strokes,Languages)
                using (RecognizerContext myRecoContext = new RecognizerContext())
                {
                    RecognitionStatus status; myRecoContext.Strokes = ink.Strokes;
                    var recoResult = myRecoContext.Recognize(out status);
                    if (status == RecognitionStatus.NoError)
                    {
                        this.inkResult.Text = recoResult.TopString;
                        //inkCanvas.Strokes.Clear();
                    }
                    else
                    {
                        MessageBox.Show("ERROR: " + status.ToString());
                    }
                }
            }
        }

        private void clear_ButtonTap(object sender, RoutedEventArgs e)
        {
            inkCanvas.Strokes.Clear();
        }

        private void ColorButtonTap(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = ((SolidColorBrush)((TouchButton)sender).Background).Color;  
        }
    }
}
