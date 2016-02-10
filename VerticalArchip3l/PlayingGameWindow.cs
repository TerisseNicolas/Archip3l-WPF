﻿using SofthinkCore.UI;
using SofthinkCore.UI.ContextMenu;
using SofthinkCore.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace VerticalArchip3l
{
    class PlayingGameWindow
    {
        public Game Game;
        public MainWindow MainWindow;

        //Event handlers

        //Important widgets
        private ScaleTransform MainScaleTransform;
        private Grid grid;
        private Label timerLabel;
        private Label scoreLabel;

        private Canvas MiddleCanvas;
        private List<Label> actionHistoryLabels;
        private List<Label> ressourcesSituationLabels;

        private Canvas MainCanvas;
        private TouchScrollViewer actionsScrollViewer;
        private StackPanel actionsStackPanel;

        public PlayingGameWindow(Game game, MainWindow mainWindow)
        {
            this.Game = game;
            this.Game.Timer.Dispatcher.Tick += Dispatcher_Tick;
            this.Game.Timer.FinalTick += Timer_FinalTick;
            this.Game.Scores.ScoreUpdate += Scores_ScoreUpdate;
            this.Game.ResourceManager.ResourceProduction += ResourceManager_ResourceProduction;
            this.Game.ResourceManager.ResourceStock += ResourceManager_ResourceStock;
            this.MainWindow = mainWindow;

            this.Game.State = GameState.Playing;
            this.Game.Sounds.playTheme();

            this.MainScaleTransform = new ScaleTransform(0.3, 0.3, 0, 0);

            //Widgets
            this.actionHistoryLabels = new List<Label>();
            this.ressourcesSituationLabels = new List<Label>();

            show();
        }

        public void show()
        {
            //Main Grid=================================================================
            this.grid = new Grid();
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

            //UpperCanvas=================================================================
            Canvas UpperCanvas = new Canvas();
            UpperCanvas.Background = Brushes.Ivory;
            Grid.SetRow(UpperCanvas, 0);
            grid.Children.Add(UpperCanvas);
            //Trophies
            ScaleTransform trophyScaleTransform = new ScaleTransform(0.5, 0.5, 0, 0);
            foreach (Trophy t in this.Game.Trophies.Trophies)
            {
                //scaling
                t.Image.RenderTransform = trophyScaleTransform;
                //positioning
                UpperCanvas.Children.Add(t.Image);
                Canvas.SetLeft(t.Image, t.PosX);
                Canvas.SetTop(t.Image, t.PosY);
            }

            //Timer
            this.timerLabel = new Label { Name = "TextBlockRemainingTime", FontSize = 60, Content = "Temps restant : 15:00" };
            UpperCanvas.Children.Add(this.timerLabel);
            Canvas.SetTop(timerLabel, 15);
            Canvas.SetRight(timerLabel, 20);

            //Score
            this.scoreLabel = new Label { Name = "ScoreLabel", FontSize = 60, Content = "Score actuel : 0", };
            UpperCanvas.Children.Add(this.scoreLabel);
            Canvas.SetTop(scoreLabel, 100);
            Canvas.SetRight(scoreLabel, 20);

            //MiddleCanvas=================================================================
            this.MiddleCanvas = new Canvas();
            MiddleCanvas.Background = Brushes.GreenYellow;
            Grid.SetRow(this.MiddleCanvas, 1);
            grid.Children.Add(this.MiddleCanvas);

            this.updateMiddleCanvas(3);

            //MainCanvas===================================================================
            this.MainCanvas = new Canvas();
            Grid.SetRow(MainCanvas, 2);
            grid.Children.Add(MainCanvas);


            //action scroll viewer
            this.actionsScrollViewer = new TouchScrollViewer();
            this.actionsScrollViewer.Height = 100;
            this.actionsScrollViewer.Width = 500;
            this.actionsScrollViewer.Background = Brushes.Fuchsia;
            this.actionsScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            this.actionsScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;

            this.actionsStackPanel = new StackPanel();
            this.actionsStackPanel.Orientation = Orientation.Horizontal;
            this.actionsStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
            this.actionsStackPanel.VerticalAlignment = VerticalAlignment.Top;

            this.actionsScrollViewer.Content = this.actionsStackPanel;
            Canvas.SetRight(this.actionsScrollViewer, 500);
            this.MainCanvas.Children.Add(this.actionsScrollViewer);

            this.updateActionScrollViewer();


            //Tests
            //UbiContextMenu contextMenu = new UbiContextMenu();
            //contextMenu.Placement = UbiContextMenu.PlacementMode.GestureCenter;
            ////contextMenu.Template = 
            //Control control = new Control();
            ////UpperCanvas.Children.Add(contextMenu);

            //***
            //ListBox lb = new ListBox();
            //ListBoxItem item1 = new ListBoxItem();
            //ListBoxItem item2 = new ListBoxItem();
            //item1.Content = "item1";
            //item2.Content = "item2";
            //lb.Items.Add(item1);
            //lb.Items.Add(item2);
            //MainCanvas.Children.Add(lb);

            //IslandControls class test
            IslandControls IslandControls2 = new IslandControls(null, this.MainCanvas, 0, 0);

            //To be removed
            Random random = new Random();
            this.Game.Scores.increaseScore(random.Next(1, 50));
            this.Game.ResourceManager.changeResourceProduction(this.Game.ResourceManager.Resources[1], 75);

        }

        //Event functions=============================================================
        //UpperCanvas
        private void Dispatcher_Tick(object sender, EventArgs e)
        {
            this.timerLabel.Content = "Temps restant : " + this.Game.Timer.ToString();
        }
        private async void Timer_FinalTick(object sender, FinalTickEventArgs e)
        {
            this.Game.finish();
            Image finishImage = new Image { Name = "finisheImage", Source = new BitmapImage(new Uri("C:/tempConcours/timeIsUp.png", UriKind.RelativeOrAbsolute)) };
            finishImage.RenderTransform = MainScaleTransform;
            this.MainCanvas.Children.Add(finishImage);
            Canvas.SetLeft(finishImage, 0);
            Canvas.SetTop(finishImage, 0);
            await Task.Delay(TimeSpan.FromSeconds(5));
            this.MainWindow.resultWindow();
        }
        private void Scores_ScoreUpdate(object sender, ScoreUpdateEventArgs e)
        {
            this.scoreLabel.Content = "Score actuel : " + e.newScore;
        }

        //MiddleCanvas
        private void ResourceManager_ResourceProduction(object sender, ResourceProductionEventArgs e)
        {
            this.updateMiddleCanvas(2);
        }
        private void ResourceManager_ResourceStock(object sender, ResourceStockEventArgs e)
        {
            this.updateMiddleCanvas(2);
        }
        private void updateMiddleCanvas(int block)
        {
            this.MiddleCanvas.Children.Clear();
            int posY = 0;
            if(block == 0 || block == 3)
            {
            }
            posY = 0;
            if(block == 1 || block == 3)
            {
                List<string> actionHistoryList = this.Game.ActionHistory.getLastActions(5);
                this.actionHistoryLabels.Clear();
                foreach (string elt in actionHistoryList)
                {
                    this.actionHistoryLabels.Add(new Label { Content = elt, FontSize = 20 });
                }
            }
            foreach(Label item in this.actionHistoryLabels)
            {
                this.MiddleCanvas.Children.Add(item);
                Canvas.SetTop(item, posY);
                Canvas.SetLeft(item, 600);
                posY += 30;
            }
            posY = 0;
            if (block == 2 || block == 3)
            {
                this.ressourcesSituationLabels.Clear();
                foreach (Resource item in this.Game.ResourceManager.Resources)
                {
                    //To be improved
                    string content = string.Format("{0}\t{1}\t{2}", item.Name.PadRight(20), item.Stock.ToString().PadRight(7), item.Production.ToString()).PadLeft(10);
                    this.ressourcesSituationLabels.Add(new Label { Content = content, FontSize = 20 });
                }
            }
            foreach (Label item in this.ressourcesSituationLabels)
            {
                this.MiddleCanvas.Children.Add(item);
                Canvas.SetTop(item, posY);
                Canvas.SetLeft(item, 1000);
                posY += 30;
            }
        }

        //MainCanvas
        private void updateActionScrollViewer()
        {
            this.actionsStackPanel.Children.Clear();
            List<ActionTouchButton> actionTouchButtonList = new List<ActionTouchButton>();

            //foreach item in actions
            foreach(Action item in this.Game.ActionManager.Actions)
            {
                actionTouchButtonList.Add(new ActionTouchButton { Action = item });
                actionTouchButtonList[actionTouchButtonList.Count - 1].Width = 200;
                actionTouchButtonList[actionTouchButtonList.Count - 1].Background = Brushes.DarkGreen;
                actionTouchButtonList[actionTouchButtonList.Count - 1].Content = item.Description;
                actionTouchButtonList[actionTouchButtonList.Count - 1].ButtonTap += new RoutedEventHandler((sender, e) => actionButton_ButtonTap(sender, e, actionTouchButtonList[actionTouchButtonList.Count - 1].Action));
                this.actionsStackPanel.Children.Add(actionTouchButtonList[actionTouchButtonList.Count - 1]);
            }

            //To be removed
            actionTouchButtonList.Add(new ActionTouchButton { Action = null });
            actionTouchButtonList[0].Width = 200;
            actionTouchButtonList[0].Background = Brushes.DarkGreen;
            actionTouchButtonList[0].Content = "Scrolling is enabled when it is necessary. Resize the Window, making it larger and smaller.Scrolling is enabled when it is necessary. Resize the Window, making it larger and smaller.";
            actionTouchButtonList[0].ButtonTap += new RoutedEventHandler((sender, e) => actionButton_ButtonTap(sender, e, actionTouchButtonList[0].Action));
            actionTouchButtonList.Add(new ActionTouchButton { Action = null });
            actionTouchButtonList[1].Width = 70;
            actionTouchButtonList[1].Background = Brushes.DarkOrange;
            actionTouchButtonList[1].Content = "Scrolling is enabled when it is necessary. This is the second text block.";
            actionTouchButtonList[1].ButtonTap += new RoutedEventHandler((sender, e) => actionButton_ButtonTap(sender, e, actionTouchButtonList[1].Action));
            actionTouchButtonList.Add(new ActionTouchButton { Action = null });
            actionTouchButtonList[2].Width = 70;
            actionTouchButtonList[2].Background = Brushes.Red;
            actionTouchButtonList[2].Content = "Scrolling is enabled when it is necessary. This is the second text block.";
            actionTouchButtonList[2].ButtonTap += new RoutedEventHandler((sender, e) => actionButton_ButtonTap(sender, e, actionTouchButtonList[2].Action));
            this.actionsStackPanel.Children.Add(actionTouchButtonList[0]);
            this.actionsStackPanel.Children.Add(actionTouchButtonList[1]);
            this.actionsStackPanel.Children.Add(actionTouchButtonList[2]);
        }

        private void actionButton_ButtonTap(object sender, RoutedEventArgs e, Action action)
        {
            //do the action (remove from the StackPanel)
            updateActionScrollViewer();
            Console.WriteLine("in ahah");
        }

        //private void IslandControlsNewBuilding_ButtonTap(object sender, RoutedEventArgs e)
        //{
        //    Console.WriteLine("New");
        //    //Event tests
        //    Random random = new Random();
        //    this.Game.Scores.increaseScore(random.Next(1, 50));
        //}
        //private void IslandControlsDeleteBuilding_ButtonTap(object sender, RoutedEventArgs e)
        //{
        //    Console.WriteLine("Delete");
        //    //Event tests
        //    Random random = new Random();
        //    this.Game.ResourceManager.changeResourceProduction(this.Game.ResourceManager.Resources[1], random.Next(1, 100));
        //}
    }
}