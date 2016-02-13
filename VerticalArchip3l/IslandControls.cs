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
        bool MinorWindowVisible;

        //Widgets
        public TouchListView MainListView;
        private TouchListView MinorListView;

        private List<TouchButton> MainListViewButtonList;
        private List<TouchButton> MinorListViewButtonList;
       
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
            this.MinorWindowVisible = false;

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
        private void hideMinorWindow()
        {
            if(this.MinorWindowVisible)
            {
                this.Canvas.Children.Remove(this.MinorListView);
                this.MinorListView.Items.Clear();
                this.MinorListViewButtonList.Clear();
                this.MinorWindowVisible = false;
            }
        }
        //Event functions
        private void NewBuildingButton_ButtonTap(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.MinorWindowVisible == false)
            {
                this.MinorWindowVisible = true;
            }
            else
            {
                this.Canvas.Children.Remove(this.MinorListView);
                this.MinorListView.Items.Clear();
                this.MinorListViewButtonList.Clear();
            }

            Canvas.SetTop(this.MinorListView, this.Position[1]);
            Canvas.SetLeft(this.MinorListView, this.Position[0] + 300);
            this.Canvas.Children.Add(this.MinorListView);
            this.MinorListView.Width = 300;

            //List possible buildings to be created
            this.MinorListViewButtonList.Add(new IslandConrolsBuildingTouchButton { Content = "Scierie", BuildingType = BuildingType.Scierie, Background = Brushes.Red });
            this.MinorListViewButtonList[0].Width = 260;
            this.MinorListViewButtonList[0].ButtonTap += IslandControlsNewBuildingSelection_ButtonTap;
            this.MinorListView.Items.Add(this.MinorListViewButtonList[0]);

            this.MinorListViewButtonList.Add(new IslandConrolsBuildingTouchButton { Content = "Mine", BuildingType = BuildingType.Mine, Background = Brushes.Black });
            this.MinorListViewButtonList[1].Width = 260;
            this.MinorListViewButtonList[1].ButtonTap += IslandControlsNewBuildingSelection_ButtonTap;
            this.MinorListView.Items.Add(this.MinorListViewButtonList[1]);            
        }
        private void DeleteBuildingButton_ButtonTap(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.MinorWindowVisible == false)
            {
                this.MinorWindowVisible = true;
            }
            else
            {
                this.Canvas.Children.Remove(this.MinorListView);
                this.MinorListView.Items.Clear();
                this.MinorListViewButtonList.Clear();
            }

            Canvas.SetTop(this.MinorListView, this.Position[1]);
            Canvas.SetLeft(this.MinorListView, this.Position[0] + 300);
            this.Canvas.Children.Add(this.MinorListView);
            this.MinorListView.Width = 300;

            this.MinorListViewButtonList.Add(new IslandConrolsBuildingTouchButton { Content = "Scierie", BuildingType = BuildingType.Scierie, Background = Brushes.Red });
            this.MinorListViewButtonList[0].Width = 260;
            this.MinorListViewButtonList[0].ButtonTap += IslandControlsDeleteBuildingSelection_ButtonTap;
            this.MinorListView.Items.Add(this.MinorListViewButtonList[0]);

            this.MinorListViewButtonList.Add(new IslandConrolsBuildingTouchButton { Content = "Mine", BuildingType = BuildingType.Mine, Background = Brushes.Black });
            this.MinorListViewButtonList[1].Width = 260;
            this.MinorListViewButtonList[0].ButtonTap += IslandControlsDeleteBuildingSelection_ButtonTap;
            this.MinorListView.Items.Add(this.MinorListViewButtonList[1]);
        }
        private void IslandControlsNewBuildingSelection_ButtonTap(object sender, System.Windows.RoutedEventArgs e)
        {
            this.hideMinorWindow();
            IslandConrolsBuildingTouchButton senderButton = (IslandConrolsBuildingTouchButton)sender;
            switch(senderButton.BuildingType)
            {
                case BuildingType.Scierie:
                    //create building with BuildingType enum Scierie
                    //this.Island.BuildingManager.createBuilding(senderButton.BuildingType);
                    Console.WriteLine("scierie creation");
                    break;
                case BuildingType.Mine:
                    //same ..
                    Console.WriteLine("Mine creation");
                    break;
                default:
                    Console.WriteLine("Button content error : creation building");
                    break;
            }
        }
        private void IslandControlsDeleteBuildingSelection_ButtonTap(object sender, System.Windows.RoutedEventArgs e)
        {
            this.hideMinorWindow();
            IslandConrolsBuildingTouchButton senderButton = (IslandConrolsBuildingTouchButton)sender;
            //this.Island.BuildingManager.destroyBuilding(senderButton.BuildingType); //caution Building list empty (buttons manually added)
        }
    }
}
