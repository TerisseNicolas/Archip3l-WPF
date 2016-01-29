using SofthinkCore.Gestures;
using SofthinkCore.Gestures.Processor;
using SofthinkCore.UI.Controls;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VerticalArchip3l
{
    class WelcomeWindow
    {
        private Game Game;
        private MainWindow MainWindow;
        private ScaleTransform MainScaleTransform;

        public WelcomeWindow(Game game, MainWindow mainWindow)
        {
            this.Game = game;
            this.MainWindow = mainWindow;
            this.MainScaleTransform = new ScaleTransform(0.3, 0.3, 0, 0);

            //test gesture
            var border = new Border();
            var tap = new TapProcessor();
            border.AddGesture(tap);
        }
        public void show()
        {
            Canvas canvas = new Canvas();
            this.MainWindow.Content = canvas;
            Image backgroundImage = new Image { Name = "background", Source = new BitmapImage(new Uri("C:/tempConcours/welcomeBackground.png", UriKind.Absolute)), };
            backgroundImage.RenderTransform = MainScaleTransform;
            canvas.Children.Add(backgroundImage);
            Canvas.SetLeft(backgroundImage, 0);
            Canvas.SetTop(backgroundImage, 0);

            TouchButton startButton = new TouchButton();
            startButton.Content = "Demarrer le jeu";
            startButton.Width = 400;
            startButton.Height = 75;
            //startButton.Tap += EventHandler(launchGame);
            startButton.Background = Brushes.YellowGreen;

            canvas.Children.Add(startButton);
            Canvas.SetTop(startButton, 700);
            Canvas.SetRight(startButton, 560);

            this.startButton_Tap(null, null);

            
        }
        private void startButton_Tap(object sender, EventArgs e)
        {
            Console.WriteLine("start button tapped");
            this.MainWindow.newGameWindow();
        }
    }
}
