using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

            //this.MainWindow.newGameWindow();
        }
    }
}
