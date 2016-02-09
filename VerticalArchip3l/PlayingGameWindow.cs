using SofthinkCore.UI;
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

        //Important widgets
        private ScaleTransform MainScaleTransform;
        private Grid grid;
        private Canvas MainCanvas;
        private Label timerLabel;
        private Label scoreLabel;


        public PlayingGameWindow(Game game, MainWindow mainWindow)
        {
            this.Game = game;
            this.Game.Timer.Dispatcher.Tick += Dispatcher_Tick;
            this.Game.Timer.FinalTick += Timer_FinalTick;
            this.Game.Scores.ScoreUpdate += Scores_ScoreUpdate;
            this.MainWindow = mainWindow;

            this.Game.State = GameState.Playing;
            this.Game.Sounds.playTheme();

            this.MainScaleTransform = new ScaleTransform(0.3, 0.3, 0, 0);

            show();
        }

        public void show()
        {
            //Grid=================================================================
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

            //Canvas================================================================
            Canvas UpperCanvas = new Canvas();
            UpperCanvas.Background = Brushes.Ivory;
            Canvas MiddleCanvas = new Canvas();
            MiddleCanvas.Background = Brushes.GreenYellow;
            this.MainCanvas = new Canvas();

            Grid.SetRow(UpperCanvas, 0);
            Grid.SetRow(MiddleCanvas, 1);
            Grid.SetRow(MainCanvas, 2);
            grid.Children.Add(UpperCanvas);
            grid.Children.Add(MiddleCanvas);
            grid.Children.Add(MainCanvas);

            //UpperCanvas=================================================================
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


            //Action History
            List<string> actionHistoryList = this.Game.ActionHistory.getLastActions(5);
            List<Label> actionHistoryLabels = new List<Label>();
            int posY = 0;
            foreach(string elt in actionHistoryList)
            {
                actionHistoryLabels.Add(new Label { Content = elt, FontSize = 20 });
                MiddleCanvas.Children.Add(actionHistoryLabels[actionHistoryLabels.Count - 1]);
                Canvas.SetTop(actionHistoryLabels[actionHistoryLabels.Count - 1], posY);
                Canvas.SetLeft(actionHistoryLabels[actionHistoryLabels.Count - 1], 600);
                posY += 30;
            }

            //Situation
            List<Label> ressourcesSituationLabels = new List<Label>();
            posY = 0;
            foreach(Ressource item in this.Game.RessourceManager.Ressources)
            {
                ressourcesSituationLabels.Add(new Label { Content = item.name + "\t" + item.stock.ToString(), FontSize = 20 });
                MiddleCanvas.Children.Add(ressourcesSituationLabels[ressourcesSituationLabels.Count - 1]);
                Canvas.SetTop(ressourcesSituationLabels[ressourcesSituationLabels.Count - 1], posY);
                Canvas.SetLeft(ressourcesSituationLabels[ressourcesSituationLabels.Count - 1], 1000);
                posY += 30;
            }


            //MainCanvas===================================================================

            //Tests
            //UbiContextMenu contextMenu = new UbiContextMenu();
            //contextMenu.Placement = UbiContextMenu.PlacementMode.GestureCenter;
            ////contextMenu.Template = 
            //Control control = new Control();
            //////UpperCanvas.Children.Add(contextMenu);

            //***
            //ListBox lb = new ListBox();
            //ListBoxItem item1 = new ListBoxItem();
            //ListBoxItem item2 = new ListBoxItem();
            //item1.Content = "item1";
            //item2.Content = "item2";
            //lb.Items.Add(item1);
            //lb.Items.Add(item2);
            //MainCanvas.Children.Add(lb);

            Button b1 = new Button();
            b1.Content = "click me";
            MainCanvas.Children.Add(b1);
            b1.Click += B1_Click;

            Random random = new Random();
            this.Game.Scores.increaseScore(random.Next(1, 50));
        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("coucou");
        }
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
    }
}