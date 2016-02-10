using System;
using System.Collections.Generic;
using System.Timers;

namespace VerticalArchip3l
{
    class Game
    {
        public Timer Timer { get; private set; }
        public TrophyManager Trophies;
        public SoundManager Sounds;
        public GameState State { get; set; }
        public ScoreManager Scores { get; private set; }
        public ActionHistoryManager ActionHistory { get; private set; }
        public ResourceManager ResourceManager { get; private set; }
        public ActionManager ActionManager { get; private set; }
        public string TeamName { get; set; } 

        public Game(string team)
        {
            this.TeamName = team;
            this.State = GameState.Sleeping;
            this.Trophies = new TrophyManager();
            this.Scores = new ScoreManager();
            this.Sounds = new SoundManager(this);
            this.ActionHistory = new ActionHistoryManager();
            this.ResourceManager = new ResourceManager();
            this.ActionManager = new ActionManager();
            this.Scores.saveScores();

            //Managing time=================================================================================================
            //this.Timer = new Timer(this, 0, 15, 0);          
            this.Timer = new Timer(this, 0, 0, 13);

            this.start();
        }
        public void start()
        {
            this.Timer.start();
        }
        public void finish()
        {
            this.Scores.addScore(this.TeamName);
            this.Scores.saveScores();
        }
    }
}
