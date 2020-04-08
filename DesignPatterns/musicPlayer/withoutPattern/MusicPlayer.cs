using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DesignPatterns.musicPlayer.statePattern.model;


namespace DesignPatterns.musicPlayer.withoutPattern
{
    class MusicPlayer
    {
        readonly static int LOCKED = 0;
        readonly static int PAUSED = 1;
        readonly static int PLAYING = 2;
        readonly static int STAND_BY = 3;
        readonly static int TURNED_OFF = 4;

        private int state = TURNED_OFF;

        private int currentSongIndex;
        public int CurrentSongIndex
        {
            get { return currentSongIndex; }
            set { currentSongIndex = value; }
        }

        private int pausedAt;
        public int PausedAt
        {
            get { return pausedAt; }
            set { pausedAt = value; }
        }

        private List<Song> songs;
        public List<Song> Songs
        {
            get { return songs; }
            set { songs = value; }
        }

        private MediaPlayer.MediaPlayer mediaPlayer;
        public MediaPlayer.MediaPlayer MediaPlayer
        {
            get { return mediaPlayer; }
            set { mediaPlayer = value; }
        }

        private System.Timers.Timer timer;


        public MusicPlayer()
        {
            this.currentSongIndex = 0;
            this.songs = new List<Song>();
            this.mediaPlayer = new MediaPlayer.MediaPlayer();

            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
        }


        public void turnOn()
        {
            if (state == TURNED_OFF)
            {
                Console.WriteLine("Device is turning on....");
                Thread.Sleep(2000);
                Console.WriteLine("Device turned on...");
                state = STAND_BY;
            }
            else if (state == STAND_BY)
            {
                Console.WriteLine("Device is already turned on!");
            }
            else if (state == PLAYING)
            {
                Console.WriteLine("Device is already turned on!");
            }
            else if (state == PAUSED)
            {
                Console.WriteLine("Device is already turned on!");
            }
            else if (state == LOCKED)
            {
                Console.WriteLine("Device is already turned on!");
            }
        }

        public void turnOff()
        {
            if (state == TURNED_OFF)
            {
                Console.WriteLine("Device is already turned off!");
            }
            else if (state == STAND_BY)
            {
                Console.WriteLine("Device is shutting down...");
                Thread.Sleep(2000);
                Console.WriteLine("Device turned off.");
                state = TURNED_OFF;
            }
            else if (state == PLAYING)
            {
                Console.WriteLine("Device is shutting down...");
                this.stopTimerAndSound();
                Thread.Sleep(2000);
                Console.WriteLine("Device turned off.");
                this.state = TURNED_OFF;
            }
            else if (state == PAUSED)
            {
                Console.WriteLine("Device is shutting down...");
                this.stopTimerAndSound();
                Thread.Sleep(2000);
                Console.WriteLine("Device turned off.");
                this.state = TURNED_OFF;
            }
            else if (state == LOCKED)
            {
                Console.WriteLine("Device is shutting down...");
                Thread.Sleep(2000);
                Console.WriteLine("Device turned off.");
                this.state = TURNED_OFF;
            }
        }

        public void play()
        {
            if (state == TURNED_OFF)
            {
                Console.WriteLine("You need to turn on your device first!");
            }
            else if (state == STAND_BY)
            {
                Song song = this.Songs[CurrentSongIndex];
                Console.WriteLine(song.Artist + " - " + song.Title + " is now playing...");
                this.timer.Enabled = true;
                this.state = PLAYING;

                this.MediaPlayer.FileName = song.Path;
                this.MediaPlayer.Play();
            }
            else if (state == PLAYING)
            {
                this.stopTimerAndSound();

                Song song = this.Songs[this.CurrentSongIndex];
                Console.WriteLine(song.Artist + " - " + song.Title + " is now playing ...");
                this.timer.Enabled = true;

                this.MediaPlayer.FileName = song.Path;
                this.MediaPlayer.Play();
            }
            else if (state == PAUSED)
            {
                Song song = this.Songs[this.CurrentSongIndex];
                Console.WriteLine(song.Artist + " - " + song.Title + " is resuming from " + this.PausedAt + " seconds ...");
                this.MediaPlayer.Play();
                this.timer.Enabled = true;
                this.state = PLAYING;
            }
            else if (state == LOCKED)
            {
                Console.WriteLine("You need to unlock your device first!");
            }

        }

        public void pause()
        {
            if (state == TURNED_OFF)
            {
                Console.WriteLine("You need to turn on your device first!");
            }
            else if (state == STAND_BY)
            {
                Console.WriteLine("There is no song playing!");
            }
            else if (state == PLAYING)
            {
                this.MediaPlayer.Pause();
                this.timer.Enabled = false;
                Console.WriteLine("Song paused on " + this.PausedAt + " seconds ...");
                state= PAUSED;
            }
            else if (state == PAUSED)
            {
                Console.WriteLine("Song is already paused");
            }
            else if (state == LOCKED)
            {
                Console.WriteLine("You need to unlock your device first!");
            }
        }

        public void stop()
        {
            if (state == TURNED_OFF)
            {
                Console.WriteLine("You need to turn on your device first!");
            }
            else if (state == STAND_BY)
            {
                Console.WriteLine("There is no song playing!");
            }
            else if (state == PLAYING)
            {
                this.stopTimerAndSound();
                Console.WriteLine("Song stopped. Device is now on stand by...");
                this.state = STAND_BY;
            }
            else if (state == PAUSED)
            {
                this.stopTimerAndSound();
                Console.WriteLine("Song stopped. Device is now on stand by...");
                this.state = STAND_BY;
            }
            else if (state == LOCKED)
            {
                Console.WriteLine("You need to unlock your device first!");
            }
        }

        public void lockUnlock()
        {
            if (state == TURNED_OFF)
            {
                Console.WriteLine("You need to turn on your device first!");
            }
            else if (state == STAND_BY)
            {
                Console.WriteLine("Device locked...");
                this.state = LOCKED;
            }
            else if (state == PLAYING)
            {
                this.stopTimerAndSound();
                Console.WriteLine("Device locked...");
                this.state = LOCKED;
            }
            else if (state == PAUSED)
            {
                Console.WriteLine("Device locked...");
                this.stopTimerAndSound();
                this.state = LOCKED;
            }
            else if (state == LOCKED)
            {
                Console.WriteLine("Device unlocked...");
                this.state = STAND_BY;
            }
        }

        public void next()
        {
            if (state == TURNED_OFF)
            {
                Console.WriteLine("You need to turn on your device first!");
            }
            else if (state == STAND_BY)
            {
                this.setNextSong();
                Song song = this.Songs[CurrentSongIndex];
                Console.WriteLine("Current song on stand by: " + song.Artist + " - " + song.Title);
            }
            else if (state == PLAYING)
            {
                this.setNextSong();
                this.play();//mozda zbog ovog ne radi jer to nije isti this kao tamo
            }
            else if (state == PAUSED)
            {
                this.setNextSong();
                this.stopTimerAndSound();
                Song song = this.Songs[this.CurrentSongIndex];
                Console.WriteLine("Current song on stand by: " + song.Artist + " - " + song.Title);
                this.state = STAND_BY;
            }
            else if (state == LOCKED)
            {
                Console.WriteLine("You need to unlock your device first!");
            }
        }

        public void previous()
        {
            if (state == TURNED_OFF)
            {
                Console.WriteLine("You need to turn on your device first!");
            }
            else if (state == STAND_BY)
            {
                this.setPreviousSong();
                Song song = this.Songs[CurrentSongIndex];
                Console.WriteLine("Current song on stand by: " + song.Artist + " - " + song.Title);
            }
            else if (state == PLAYING)
            {
                this.setPreviousSong();
                this.play();//mozda zbog ovog ne radi jer to nije isti this kao tamo
            }
            else if (state == PAUSED)
            {
                this.setPreviousSong();
                this.stopTimerAndSound();
                Song song = this.Songs[this.CurrentSongIndex];
                Console.WriteLine("Current song on stand by: " + song.Artist + " - " + song.Title);
                this.state = STAND_BY;
            }
            else if (state == LOCKED)
            {
                Console.WriteLine("You need to unlock your device first!");
            }
        }

        public void setNextSong()
        {
            if (this.CurrentSongIndex == this.Songs.Count - 1)
            {
                this.CurrentSongIndex = 0;
            }
            else
            {
                this.CurrentSongIndex++;
            }
        }

        public void setPreviousSong()
        {
            if (this.CurrentSongIndex == 0)
            {
                this.CurrentSongIndex = this.Songs.Count - 1;
            }
            else
            {
                this.CurrentSongIndex--;
            }
        }

        public void stopTimerAndSound()
        {
            this.mediaPlayer.Stop();
            timer.Enabled = false;
            this.pausedAt = 0;
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            this.PausedAt++;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine(getTimeFormatedString());
            Console.SetCursorPosition(10, Console.CursorTop - 1);
        }

        public String getTimeFormatedString()
        {
            String retVal;

            int minutes = this.pausedAt / 60;
            if (minutes < 10)
            {
                retVal = "0" + minutes;
            }
            else
            {
                retVal = minutes.ToString();
            }

            retVal += ":";

            int seconds = this.pausedAt % 60;
            if (seconds < 10)
            {
                retVal += "0";
            }
            retVal += seconds;
            retVal += "  ";

            return retVal;
        }
    }
}
