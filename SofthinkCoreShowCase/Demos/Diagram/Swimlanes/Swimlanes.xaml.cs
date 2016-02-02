using DemoCommon.Model;
using SofthinkCore.UI.Diagram;
using SofthinkCore.Utils;
using SofthinkCoreShowCase.DemoCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace SofthinkCoreShowCase.Demos.Diagram.Swimlanes
{
    /// <summary>
    /// Interaction logic for Swimlanes.xaml
    /// </summary>
    [SofthinkCoreShowCase.DemoManager.Demo(Name = "Swimlanes", Category = "UbiDiagram")]
    public partial class Swimlanes : UserControl
    {
        public Swimlanes()
        {
            InitializeComponent();

            for (int i = 0; i < 4; i++)
            {
                var coll = new PostitCollection() { Color = new SolidColorBrush(ColorHelper.ColorFromHSL(RandomHelper.GetRandomDouble(0, 360), RandomHelper.GetRandomDouble(0.5, 0.8), RandomHelper.GetRandomDouble(0.6, 0.8)))
                    , Text = RandomHelper.GetRandomSmallerThan(20) };
                diagram.Items.Add(coll);

                //var w = new QuoteWorker(coll,Dispatcher);
                //w.Finished += (e,o) => 
                //{ Dispatcher.Invoke(new Action( () => item.Text = e as string) ) ;};
                //ThreadPool.QueueUserWorkItem(w.ThreadPoolCallback);

                for (int p = 0; p < 8; p++)
                {
                    var item = new PostitViewModel { Position = new Point(p * 100, p * 205) , Text = RandomHelper.GetRandomSmallerThan(30) };
                    coll.Add(item); //Text = RandomHelper.GetRandomSmallerThan(20)});
                   
                }
            }

            for( int i = 0; i < diagram.Items.Count - 1 ;i++ )
            {
                PostitCollection col1 = diagram.Items[i] as PostitCollection;
                PostitCollection col2 = diagram.Items[i + 1] as PostitCollection;

                for(int l = 0; l < 5; l++)
                {
                    var p1 = col1[RandomHelper.GetRandomInt(0, col1.Count)];
                    var p2 = col2[RandomHelper.GetRandomInt(0, col2.Count)];

                    diagram.Links.Add(new LinkModel { SourceModel = p1, SinkModel = p2 });
                }
                
            }
        }
        public delegate void MyDelegate(PostitViewModel m, string txt);

        class QuoteWorker
        {
            PostitCollection coll;
            Dispatcher di;

            public QuoteWorker(PostitCollection c,Dispatcher d)
            {
                coll = c;
                di = d;
            }

            public void ThreadPoolCallback(Object threadContext)
            {
                for(int i = 0; i < coll.Count; i++)
                {
                    var txt = RandomHelper.GetRandomQuoteFromInterWeb();
                    di.BeginInvoke(new MyDelegate(AddText), new object[2] { coll[i], txt });
                }
               
            }

            private void AddText(PostitViewModel m,string txt)
            {
                m.Text = txt;
            }


        }       
       
    }
}
