using System;
using System.Collections.Generic;
using System.Media;

namespace VerticalArchip3l
{
    class SoundManager
    {
        private SoundPlayer Player;
        private Dictionary<GameState, string> Playlist;
        private Game Game;

        public SoundManager(Game game)
        {
            this.Game = game;

            this.Playlist = new Dictionary<GameState, string>();
            this.Playlist.Add(GameState.Sleeping, "C:/tempConcours/welcomeMusic.wav");
            this.Playlist.Add(GameState.NameFilling, "C:/tempConcours/gameWindow.wav");
            this.Playlist.Add(GameState.Playing, "C:/tempConcours/mainTheme.wav");
            this.Playlist.Add(GameState.ScoreViewing, "C:/tempConcours/gameWindow.wav");

            this.Player = new SoundPlayer();    
        }
        public void playTheme()
        {
            this.Player.SoundLocation = Playlist[this.Game.State];
            this.Player.Load();
            this.Player.PlayLooping();
        }
        private void stop()
        {
            this.Player.Stop();
        }
    }
}
