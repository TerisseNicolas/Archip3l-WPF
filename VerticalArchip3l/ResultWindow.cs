using System;
using System.Windows.Media;
using System.Windows.Controls;

namespace VerticalArchip3l
{
    class ResultWindow
    {
        Game Game;
        MainWindow MainWindow;

        public ResultWindow(Game game, MainWindow mainWindow)
        {
            this.Game = game;
            this.MainWindow = mainWindow;

            this.Game.State = GameState.ScoreViewing;
            this.Game.Sounds.playTheme();

            this.show();
        }
        public void show()
        {
            Grid grid = new Grid();
            this.MainWindow.Content = grid;
            grid.Background = Brushes.LavenderBlush;
        }
    }
}
