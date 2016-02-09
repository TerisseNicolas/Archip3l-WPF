using SofthinkCore.UI.Controls;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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
            List<Tuple<int, string, int>> result = this.Game.Scores.getFinalResult(this.Game.TeamName);
            int max = result.Count;
            if(max > 10)
            {
                max = 10;
            }

            Canvas canvas = new Canvas();
            this.MainWindow.Content = canvas;
            canvas.Background = Brushes.LavenderBlush;

            Grid grid = new Grid();
            grid.Background = Brushes.LightCyan;
            grid.ShowGridLines = true;
            grid.Width = 500;
            grid.Height = 500;

            canvas.Children.Add(grid);
            Canvas.SetTop(grid, 200);
            Canvas.SetRight(grid, 100);

            List <RowDefinition> ScoreRows = new List<RowDefinition>();
            List<Tuple<Label, Label, Label>> Labels = new List<Tuple<Label, Label, Label>>();

            ColumnDefinition col0 = new ColumnDefinition();
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            grid.ColumnDefinitions.Add(col0);
            grid.ColumnDefinitions.Add(col1);
            grid.ColumnDefinitions.Add(col2);

            for (int i = 0; i < max; i++)
            {
                ScoreRows.Add(new RowDefinition());
                Labels.Add(new Tuple<Label, Label, Label>(new Label { Content = result[i].Item1.ToString(), FontSize = 20 },
                                                          new Label { Content = result[i].Item2, FontSize = 20 },
                                                          new Label { Content = result[i].Item3.ToString(), FontSize = 20 }));
                grid.RowDefinitions.Add(ScoreRows[i]);
                if(result[i].Item2 == this.Game.TeamName)
                {
                    //Change color of the row
                    Border border1 = new Border { Background = Brushes.Red};
                    Border border2 = new Border { Background = Brushes.Red };
                    Border border3 = new Border { Background = Brushes.Red };
                    Grid.SetRow(border1, i);
                    Grid.SetRow(border2, i);
                    Grid.SetRow(border3, i);
                    Grid.SetColumn(border1, 0);
                    Grid.SetColumn(border2, 1);
                    Grid.SetColumn(border3, 2);
                    grid.Children.Add(border1);
                    grid.Children.Add(border2);
                    grid.Children.Add(border3);
                }

                Grid.SetRow(Labels[i].Item1, i);
                Grid.SetColumn(Labels[i].Item1, 0);
                grid.Children.Add(Labels[i].Item1);
                Labels[i].Item1.HorizontalAlignment = HorizontalAlignment.Center;
                Labels[i].Item1.VerticalAlignment = VerticalAlignment.Center;

                Grid.SetRow(Labels[i].Item2, i);
                Grid.SetColumn(Labels[i].Item2, 1);
                grid.Children.Add(Labels[i].Item2);
                Labels[i].Item2.HorizontalAlignment = HorizontalAlignment.Center;
                Labels[i].Item2.VerticalAlignment = VerticalAlignment.Center;

                Grid.SetRow(Labels[i].Item3, i);
                Grid.SetColumn(Labels[i].Item3, 2);
                grid.Children.Add(Labels[i].Item3);
                Labels[i].Item3.HorizontalAlignment = HorizontalAlignment.Center;
                Labels[i].Item3.VerticalAlignment = VerticalAlignment.Center;
            }

            TouchButton finishButton = new TouchButton { Content = "Terminer", Width = 200, Height = 69 };
            finishButton.Background = Brushes.YellowGreen;
            finishButton.ButtonTap += FinishButton_ButtonTap;
            canvas.Children.Add(finishButton);
            Canvas.SetTop(finishButton, 700);
            Canvas.SetRight(finishButton, 90);
        }
        private void FinishButton_ButtonTap(object sender, RoutedEventArgs e)
        {
            this.MainWindow.welcomeWindow();
        }
    }
}
