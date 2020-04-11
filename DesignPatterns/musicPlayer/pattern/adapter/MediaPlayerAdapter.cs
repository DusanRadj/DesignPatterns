using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.musicPlayer.pattern.adapter
{
    class MediaPlayerAdapter : IMyMediaPlayer
    {
        private MediaPlayer.MediaPlayer mediaPlayer;

        public MediaPlayerAdapter()
        {
            this.mediaPlayer = new MediaPlayer.MediaPlayer();
        }

        public void play(string path)
        {
            this.mediaPlayer.FileName = path;
            this.mediaPlayer.Play();
        }

        public void pause()
        {
            this.mediaPlayer.Pause();
        }

        public void stop()
        {
            this.mediaPlayer.Stop();
        }

        public void resume()
        {
            this.mediaPlayer.Play();
        }
    }
}
