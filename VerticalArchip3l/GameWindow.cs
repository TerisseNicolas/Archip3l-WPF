using System;
using System.Text;
using System.Windows.Controls;

namespace VerticalArchip3l
{
    class GameWindow
    {
        Game Game;
        MainWindow MainWindow;

        public GameWindow(Game game, MainWindow mainWindow)
        {
            this.Game = game;
            this.MainWindow = mainWindow;
        }
        public void show()
        {
            //Displays the start window (enter the team name ...)
            Grid grid = new Grid();
            MainWindow.Content = grid; /*.Children.Clear();*/
        }
    }
}
