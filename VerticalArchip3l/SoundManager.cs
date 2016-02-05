using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace VerticalArchip3l
{
    class SoundManager
    {
        private SoundPlayer Player;
        private Dictionary<GameState, string> Playlist;

        public SoundManager()
        {
            this.Playlist = new Dictionary<GameState, string>();
            this.Playlist.Add(GameState.Sleeping, "C:/tempConcours/welcomeMusic.wav");
            this.Playlist.Add(GameState.NameFilling, "C:/tempConcours/gameWindow.wav");
            this.Playlist.Add(GameState.Playing, "C:/tempConcours/mainTheme.wav");
            this.Playlist.Add(GameState.ScoreViewing, "C:/tempConcours/gameWindow.wav");

            this.Player = new SoundPlayer();    
        }
        public void playWelcome()
        {
            this.Player.SoundLocation = Playlist[GameState.Sleeping];
            this.start();
        }
        public void playNameSelection()
        {
            this.Player.SoundLocation = Playlist[GameState.NameFilling];
            this.start();
        }
        public void playMainTheme()
        {
            this.Player.SoundLocation = Playlist[GameState.Playing];
            this.start();
        }
        private void start()
        {
            this.Player.Load();
            this.Player.PlayLooping();
        }
        private void stop()
        {
            this.Player.Stop();
        }
    }
}
