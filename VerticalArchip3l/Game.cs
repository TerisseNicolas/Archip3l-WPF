using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VerticalArchip3l
{
    class Game
    {
        private Timer timer;
        public List<Trophy> Trophies;
        public ScoreManager Scores { get; private set; }
        public int Score { get; private set;  }
        public string TeamName { get; private set; } 

        public Game(string team)
        {
            this.TeamName = team;
            this.Score = 0;
            this.Trophies = new List<Trophy>();
            this.Scores = new ScoreManager();
            this.Scores.addScore("New team", 38);
            this.Scores.saveScores();

            //Managing time=================================================================================================
            this.timer = new Timer(0, 15, 0);

            //Trophies======================================================================================================
            Trophy trophy1 = new Trophy(1, "Trophée ressources", "Gain de ressources", 50, 50, null);
            Trophy trophy2 = new Trophy(2, "Trophée innovation", "Multiplication de la productivité par 1.5", 160, 50, null);
            Trophy trophy3 = new Trophy(3, "Trophée rapidité", "Multiplication de la productivité par 1.5", 270, 50, null);
            Trophy trophy4 = new Trophy(4, "Trophée stratégie", "Une description", 380, 50, null);
            Trophy trophy5 = new Trophy(5, "Trophée légende", "Une description", 490, 50, null);
            this.Trophies.Add(trophy1);
            this.Trophies.Add(trophy2);
            this.Trophies.Add(trophy3);
            this.Trophies.Add(trophy4);
            this.Trophies.Add(trophy5);
            trophy2.changeToObtained();
            trophy3.changeToObtained();
            trophy5.changeToObtained();
        }
        public void start()
        {
            this.timer.start();
        }
        public void finish()
        {
            this.Scores.addScore(this.TeamName, this.Score);
            this.Scores.saveScores();

        }
    }
}
