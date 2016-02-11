using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VerticalArchip3l
{
    class DisturbanceRepartition
    {
        Game Game;
        Disturbance Disturbance;
        PlayingGameWindow MainWindow;
        Timer Timer;
        List<Label> labelList;
        List<TextBox> textBlockList;

        public DisturbanceRepartition(PlayingGameWindow mainWindow, Game game, Disturbance disturbance)
        {
            this.MainWindow = mainWindow;
            this.Game = game;
            this.Disturbance = disturbance;
            this.labelList = new List<Label>();
            this.textBlockList = new List<TextBox>();

            //timer
            this.Timer = new Timer(this.Game, 0, 0, 6);
            this.Timer.FinalTick += Timer_FinalTick;
            this.Timer.Dispatcher.Tick += Dispatcher_Tick;
        }

        public void show()
        {
            //Name label
            this.labelList.Add(new Label { FontSize = 60, Content = this.Disturbance.Name });
            this.MainWindow.MainCanvas.Children.Add(this.labelList[0]);
            Canvas.SetTop(this.labelList[0], 30);
            Canvas.SetLeft(this.labelList[0], 300);

            //Timer label
            this.labelList.Add(new Label { FontSize = 60, Content = this.Timer.ToStringSecondOnly() });
            this.MainWindow.MainCanvas.Children.Add(this.labelList[1]);
            Canvas.SetTop(this.labelList[1], 80);
            Canvas.SetLeft(this.labelList[1], 300);

            //Instruction textbox
            this.textBlockList.Add(new TextBox { FontSize = 60, Text = this.Disturbance.Instruction });
            this.MainWindow.MainCanvas.Children.Add(this.textBlockList[0]);
            Canvas.SetTop(this.textBlockList[0], 120);
            Canvas.SetLeft(this.textBlockList[0], 300);

            //timer
            this.Timer.start();
        }
        public void hide()
        {
            foreach(Label item in this.labelList)
            {
                this.MainWindow.MainCanvas.Children.Remove(item);
            }
            foreach (TextBox item in this.textBlockList)
            {
                this.MainWindow.MainCanvas.Children.Remove(item);
            }
        }

        //Events
        private void Timer_FinalTick(object sender, FinalTickEventArgs e)
        {
            this.hide();
        }
        private void Dispatcher_Tick(object sender, EventArgs e)
        {
            this.labelList[1].Content = this.Timer.ToStringSecondOnly();
        }
    }
}
