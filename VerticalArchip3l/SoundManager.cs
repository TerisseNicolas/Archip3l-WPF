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
        private List<string> Playlist;

        public SoundManager()
        {
            this.Playlist = new List<string>();
            this.Playlist.Add("C:/tempConcours/welcomeMusic.wav");
            this.Playlist.Add("C:/tempConcours/gameWindow.wav");
            this.Playlist.Add("C:/tempConcours/mainTheme.wav");

            this.Player = new SoundPlayer();    
        }
        public void playWelcome()
        {
            this.Player.SoundLocation = Playlist[0];
            this.start();
        }
        public void playNameSelection()
        {
            this.Player.SoundLocation = Playlist[1];
            this.start();
        }
        public void playMainTheme()
        {
            this.Player.SoundLocation = Playlist[2];
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
