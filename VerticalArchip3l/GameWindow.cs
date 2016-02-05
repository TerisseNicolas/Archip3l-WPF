using SofthinkCore.UI.Controls;
using System;
using System.Text;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VerticalArchip3l
{
    class GameWindow
    {
        Game Game;
        MainWindow MainWindow;
        private ScaleTransform MainScaleTransform;

        public GameWindow(Game game, MainWindow mainWindow)
        {
            this.Game = game;
            this.MainWindow = mainWindow;
            this.MainScaleTransform = new ScaleTransform(0.3, 0.3, 0, 0);
            this.Game.Sounds.playNameSelection();
            show();
        }
        public void show()
        { 
            Canvas canvas = new Canvas();
            this.MainWindow.Content = canvas;
            Image backgroundImage = new Image { Name = "background", Source = new BitmapImage(new Uri("C:/tempConcours/newGameBackground.png", UriKind.Absolute)), };
            backgroundImage.RenderTransform = MainScaleTransform;
            canvas.Children.Add(backgroundImage);
            Canvas.SetLeft(backgroundImage, 0);
            Canvas.SetTop(backgroundImage, 0);

            Label teamNameLabel = new Label { Name = "teamNameLabel", FontSize = 60, Content = "Nom de l'équipe" };
            canvas.Children.Add(teamNameLabel);
            Canvas.SetTop(teamNameLabel, 650);
            Canvas.SetRight(teamNameLabel, 800);

            UbiTextBox teamNameTextBox = new UbiTextBox { Name = "teamNameTextBox", Text = "nom", FontSize = 40, Width = 500, Height = 70 };
            canvas.Children.Add(teamNameTextBox);
            Canvas.SetTop(teamNameTextBox, 670);
            Canvas.SetRight(teamNameTextBox, 250);

            TouchButton startButton = new TouchButton { Content = "Lancer le jeu", Width = 200, Height = 69 };
            startButton.Background = Brushes.YellowGreen;
            startButton.ButtonTap += startButton_Tap;

            canvas.Children.Add(startButton);
            Canvas.SetTop(startButton, 661);
            Canvas.SetRight(startButton, 50);

            //this.startButton_Tap(null, null);
        }
        private void startButton_Tap(object sender, EventArgs e)
        {
            this.Game.Sounds.playMainTheme();
            this.MainWindow.playingGameWindow();
        }
    }
}
