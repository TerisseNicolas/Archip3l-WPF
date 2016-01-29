using SofthinkCore.UI;
using SofthinkCore.UI.ContextMenu;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Text;


namespace VerticalArchip3l
{
    class PlayingGameWindow
    {
        Game Game;
        MainWindow MainWindow;

        public PlayingGameWindow(Game game, MainWindow mainWindow)
        {
            this.Game = game;
            this.MainWindow = mainWindow;
        }
        public void show()
        {
            //Grid=================================================================
            Grid grid = new Grid();
            this.MainWindow.Content = grid;
            grid.Background = Brushes.Aqua;
            grid.ShowGridLines = true;

            RowDefinition UpperRow = new RowDefinition();
            RowDefinition MiddleRow = new RowDefinition();
            RowDefinition MainRow = new RowDefinition();
            UpperRow.Height = new GridLength(200);
            MiddleRow.Height = new GridLength(200);
            grid.RowDefinitions.Add(UpperRow);
            grid.RowDefinitions.Add(MiddleRow);
            grid.RowDefinitions.Add(MainRow);

            //Canvas================================================================
            Canvas UpperCanvas = new Canvas();
            UpperCanvas.Background = Brushes.Ivory;
            Canvas MiddleCanvas = new Canvas();
            MiddleCanvas.Background = Brushes.GreenYellow;
            Canvas MainCanvas = new Canvas();

            Grid.SetRow(UpperCanvas, 0);
            Grid.SetRow(MiddleCanvas, 1);
            Grid.SetRow(MainCanvas, 2);
            grid.Children.Add(UpperCanvas);
            grid.Children.Add(MiddleCanvas);
            grid.Children.Add(MainCanvas);     

            //UpperCanvas=================================================================
            //Trophies
            ScaleTransform trophyScaleTransform = new ScaleTransform(0.5, 0.5, 0, 0);
            foreach (Trophy t in this.Game.Trophies)
            {
                //scaling
                t.Image.RenderTransform = trophyScaleTransform;
                //positioning
                UpperCanvas.Children.Add(t.Image);
                Canvas.SetLeft(t.Image, t.PosX);
                Canvas.SetTop(t.Image, t.PosY);
            }

            //Timer
            Label timerLabel = new Label { Name = "TextBlockRemainingTime", FontSize = 60, Content = "Temps restant : 00:00", };
            UpperCanvas.Children.Add(timerLabel);
            Canvas.SetTop(timerLabel, 15);
            Canvas.SetRight(timerLabel, 20);

            //Score
            Label scoreLabel = new Label { Name = "ScoreLabel", FontSize = 60, Content = "Score actuel : 0", };
            UpperCanvas.Children.Add(scoreLabel);
            Canvas.SetTop(scoreLabel, 100);
            Canvas.SetRight(scoreLabel, 20);

            //MiddleCanvas=================================================================


            //MainCanvas===================================================================

            //Tests
            UbiContextMenu contextMenu = new UbiContextMenu();
            contextMenu.Placement = UbiContextMenu.PlacementMode.GestureCenter;
            //contextMenu.Template = 
            Control control = new Control();
            ////UpperCanvas.Children.Add(contextMenu);

            //***
            ListBox lb = new ListBox();
            ListBoxItem item1 = new ListBoxItem();
            ListBoxItem item2 = new ListBoxItem();
            item1.Content = "item1";
            item2.Content = "item2";
            lb.Items.Add(item1);
            lb.Items.Add(item2);
            MainCanvas.Children.Add(lb);
        }
    }
}
