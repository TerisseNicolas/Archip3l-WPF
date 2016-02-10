using SofthinkCore.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalArchip3l
{
    class Debug
    {
        MainWindow MainWindow;
        Game Game;

        public Debug(MainWindow window, Game game)
        {
            this.MainWindow = window;
            this.Game = game;

            //Handlers
            this.Game.Timer.FinalTick += Timer_FinalTick;
            this.Game.Timer.Dispatcher.Tick += Dispatcher_Tick;
            this.Game.Scores.ScoreUpdate += Scores_ScoreUpdate;
            this.Game.Trophies.TrophyObtained += Trophies_TrophyObtained;
            this.Game.ResourceManager.ResourceProduction += ResourceManager_ResourceProduction;
            this.Game.ResourceManager.ResourceStock += ResourceManager_ResourceStock;
            this.Game.ActionManager.PerformAction += ActionManager_PerformAction;
        }

        private void ActionManager_PerformAction(object sender, PerformActionEventArgs e)
        {
            display("Action perform : " + e.Action.Name);
        }
        private void Scores_ScoreUpdate(object sender, ScoreUpdateEventArgs e)
        {
            display("Score actuel: " + e.newScore);
        }
        private void Dispatcher_Tick(object sender, EventArgs e)
        {
            display("Temps restant : " + this.Game.Timer.ToString());
        }
        private void Timer_FinalTick(object sender, FinalTickEventArgs e)
        {
            display("Final tick");
        }
        private void Trophies_TrophyObtained(object sender, TrophyObtainedEventArgs e)
        {
            display("Trophy obtained : " + e.Trophy.Description);
        }
        private void ResourceManager_ResourceProduction(object sender, ResourceProductionEventArgs e)
        {
            display("Resource : " + e.Resource.Name + " new production : " + e.NewProduction);
        }
        private void ResourceManager_ResourceStock(object sender, ResourceStockEventArgs e)
        {
            display("Resource : " + e.Resource.Name + " new production : " + e.NewStock);
        }
        private void display(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
