using SofthinkCore.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace VerticalArchip3l
{
    class IslandControls
    {
        Island Island;
        int[] Position;
        Canvas Canvas;

        //Widgets
        public TouchListView MainListView;
        private TouchListView MinorListView;

        private List<TouchButton> MainListViewButtonList;
        private List<TouchButton> MinorListViewButtonList;

        //private TouchButton NewBuildingButton;
        //private TouchButton DeleteBuildingButton;
       
        public IslandControls(Island island, Canvas canvas, int posX, int posY)
        {
            this.Island = island;
            this.Canvas = canvas;
            this.Position = new int[2];
            this.Position[0] = posX;
            this.Position[1] = posY;
            this.MainListViewButtonList = new List<TouchButton>();
            this.MinorListViewButtonList = new List<TouchButton>();
            this.MainListView = new TouchListView();
            this.Canvas.Children.Add(this.MainListView);
            this.MinorListView = new TouchListView();

            this.show();
        }
        private void show()
        {
            Canvas.SetTop(this.MainListView, this.Position[1]);
            Canvas.SetLeft(this.MainListView, this.Position[0]);
            this.MainListView.Width = 300;

            this.MainListViewButtonList.Add(new TouchButton { Content = "Nouveau bâtiment", Background = Brushes.Red });
            this.MainListViewButtonList[0].Width = 260;
            this.MainListViewButtonList[0].ButtonTap += NewBuildingButton_ButtonTap;
            this.MainListView.Items.Add(this.MainListViewButtonList[0]);

            this.MainListViewButtonList.Add(new TouchButton { Content = "Detruire un bâtiment", Background = Brushes.Black });
            this.MainListViewButtonList[1].Width = 260;
            this.MainListViewButtonList[1].ButtonTap += DeleteBuildingButton_ButtonTap;
            this.MainListView.Items.Add(this.MainListViewButtonList[1]);
        }

        //Event functions
        private void NewBuildingButton_ButtonTap(object sender, System.Windows.RoutedEventArgs e)
        {
            //this.MinorListView.Items.Clear();
            Canvas.SetTop(this.MinorListView, this.Position[1]);
            Canvas.SetLeft(this.MinorListView, this.Position[0] + 300);
            this.Canvas.Children.Add(this.MinorListView);
            this.MinorListView.Width = 300;

            this.MinorListViewButtonList.Add(new TouchButton { Content = "Scierie", Background = Brushes.Red });
            this.MinorListViewButtonList[0].Width = 260;
            this.MinorListViewButtonList[0].ButtonTap += IslandControlsNewBuildingSelection_ButtonTap;
            this.MinorListView.Items.Add(this.MinorListViewButtonList[0]);

            this.MinorListViewButtonList.Add(new TouchButton { Content = "Mine", Background = Brushes.Black });
            this.MinorListViewButtonList[1].Width = 260;
            this.MinorListViewButtonList[0].ButtonTap += IslandControlsNewBuildingSelection_ButtonTap;
            this.MinorListView.Items.Add(this.MinorListViewButtonList[1]);
        }

        private void DeleteBuildingButton_ButtonTap(object sender, System.Windows.RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void IslandControlsNewBuildingSelection_ButtonTap(object sender, System.Windows.RoutedEventArgs e)
        {
            this.MinorListView.Items.Clear();
            this.Canvas.Children.Remove(this.MinorListView);
            TouchButton senderButton = (TouchButton)sender;
            switch((string)senderButton.Content)
            {
                case "Scierie":
                    //create building with BuildingType enum Scierie
                    Console.WriteLine("scierie creation");
                    break;
                case "Mine":
                    //same ..
                    Console.WriteLine("Mine creation");
                    break;
                default:
                    Console.WriteLine("Button content error : creation building");
                    break;
            }
        }
    }
}
