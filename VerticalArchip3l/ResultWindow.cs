using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;

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
            Grid grid = new Grid();
            this.MainWindow.Content = grid;
            grid.Background = Brushes.LavenderBlush;
            grid.ShowGridLines = true;
            grid.Width = 300;
            grid.Height = 500;
            grid.HorizontalAlignment = HorizontalAlignment.Center;
            grid.VerticalAlignment = VerticalAlignment.Center;

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
                //Console.WriteLine(result[i].Item2);
                ScoreRows.Add(new RowDefinition());
                Labels.Add(new Tuple<Label, Label, Label>(new Label { Content = result[i].Item1.ToString(), FontSize = 20 },
                                                          new Label { Content = result[i].Item2, FontSize = 20 },
                                                          new Label { Content = result[i].Item3.ToString(), FontSize = 20 }));
                grid.RowDefinitions.Add(ScoreRows[i]);

                Grid.SetRow(Labels[i].Item1, i);
                Grid.SetColumn(Labels[i].Item1, 0);
                grid.Children.Add(Labels[i].Item1);

                Grid.SetRow(Labels[i].Item2, i);
                Grid.SetColumn(Labels[i].Item2, 1);
                grid.Children.Add(Labels[i].Item2);

                Grid.SetRow(Labels[i].Item3, i);
                Grid.SetColumn(Labels[i].Item3, 2);
                grid.Children.Add(Labels[i].Item3);
            }
        }
    }
}
