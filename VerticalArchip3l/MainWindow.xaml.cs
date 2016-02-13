using SofthinkCore.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace VerticalArchip3l
{
    public partial class MainWindow : SofthinkWindow
    {
        private Game Game;
        private WelcomeWindow WelcomeWindow;
        private GameWindow GameWindow;
        private PlayingGameWindow PlayingGameWindow;
        private ResultWindow ResultWindow;

        private Debug Debug;

        public MainWindow()
        {
            InitializeComponent();
            this.Game = new Game("Unknown Team");
            this.Debug = new Debug(this, this.Game);
            welcomeWindow();
        }
        public void welcomeWindow()
        {
            //Clean a possible previous game
            this.WelcomeWindow = null;
            this.GameWindow = null;
            this.PlayingGameWindow = null;
            this.ResultWindow = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            this.WelcomeWindow = new WelcomeWindow(this.Game, this);
        }
        public void newGameWindow()
        {
            this.GameWindow = new GameWindow(this.Game, this);
        }
        public void playingGameWindow()
        {
            this.PlayingGameWindow = new PlayingGameWindow(this.Game, this);     
        }
        public void resultWindow()
        {
            this.ResultWindow = new ResultWindow(this.Game, this);
        }
    }
}
