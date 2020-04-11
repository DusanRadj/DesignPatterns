using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.musicPlayer.statePattern.states;
using DesignPatterns.musicPlayer.pattern.adapter;
using System.Timers;

namespace DesignPatterns.musicPlayer.statePattern.model
{
    class MusicPlayer
    {
        public AbstractState turnedOffState;
        public AbstractState standbyState;
        public AbstractState lockedState;
        public AbstractState playingState;
        public AbstractState pausedState;
        private AbstractState currentState;

        private int currentSongIndex;
        private int pausedAt;

        private IMyMediaPlayer myMediaPlayer;
        private Timer timer;

        private List<Song> songs;
        
        public MusicPlayer()
        {
            this.turnedOffState = new TurnedOffState(this);
            this.standbyState = new StandByState(this);
            this.playingState = new PlayingState(this);
            this.pausedState = new PausedState(this);
            this.lockedState = new LockedState(this);
            this.currentState = turnedOffState;

            this.currentSongIndex = 0;
            this.songs = new List<Song>();
            this.myMediaPlayer = new NAudioAdapter();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;     
        }

        public void turnOn()
        {
            this.currentState.turnOn();
        }

        public void turnOff()
        {
            this.currentState.turnOff();
        }

        public void play()
        {
            this.currentState.play();
        }

        public void pause()
        {
            this.currentState.pause();
        }

        public void stop()
        {
            this.currentState.stop();
        }

        public void lockUnlock()
        {
            this.currentState.lockUnlock();
        }

        public void next()
        {
            this.currentState.next();
        }

        public void previous()
        {
            this.currentState.previous();
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
            this.myMediaPlayer.stop();
            timer.Enabled = false; 
            this.pausedAt = 0;
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            this.PausedAt++;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine(getTimeFormatedString());
            Console.SetCursorPosition(10, Console.CursorTop - 1);
            if (this.pausedAt == this.songs[currentSongIndex].Length - 1)
                this.currentState.next();
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

        public void switchToAnotherPlayer()
        {
            if (this.myMediaPlayer.GetType() == typeof(MediaPlayerAdapter))
            {
                this.myMediaPlayer = new NAudioAdapter();
                Console.WriteLine("Switching to NAudio...");
            }
            else
            {
                this.myMediaPlayer = new MediaPlayerAdapter();
                Console.WriteLine("Switching to MediaPlayer...");
            }
        }

        #region properties

        public Timer Timer
        {
            get { return timer; }
            set { timer = value; }
        }
        public IMyMediaPlayer MyMediaPlayer
        {
            get { return myMediaPlayer; }
            set { myMediaPlayer = value; }
        }
        public List<Song> Songs
        {
            get { return songs; }
            set { songs = value; }
        }
        public int PausedAt
        {
            get { return pausedAt; }
            set { pausedAt = value; }
        }
        public int CurrentSongIndex
        {
            get { return currentSongIndex; }
            set { currentSongIndex = value; }
        }
        public AbstractState CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        #endregion
    }
}
