using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DesignPatterns.musicPlayer.statePattern.model;

namespace DesignPatterns.musicPlayer.statePattern.states
{
    class PlayingState : IState
    {
        private MusicPlayer musicPlayer;

        public PlayingState(MusicPlayer musicPlayer)
        {
            this.musicPlayer = musicPlayer;
        }

        public void turnOn()
        {
            Console.WriteLine("Device is already turned on!");
        }

        public void turnOff()
        {
            Console.WriteLine("Device is shutting down...");
            musicPlayer.stopTimerAndSound();
            Thread.Sleep(2000);
            Console.WriteLine("Device turned off.");
            musicPlayer.CurrentState = musicPlayer.turnedOffState;
        }

        public void play()
        {
            musicPlayer.stopTimerAndSound();
            
            Song song = musicPlayer.Songs[musicPlayer.CurrentSongIndex];
            Console.WriteLine(song.Artist + " - " + song.Title + " is now playing ...");
            musicPlayer.Timer.Enabled = true;

            musicPlayer.MediaPlayer.FileName = song.Path;
            musicPlayer.MediaPlayer.Play();
        }

        public void pause()
        {
            musicPlayer.MediaPlayer.Pause();
            musicPlayer.Timer.Enabled = false;
            Console.WriteLine("Song paused on " + musicPlayer.PausedAt + " seconds ...");
            musicPlayer.CurrentState = musicPlayer.pausedState;
        }

        public void stop()
        {
            musicPlayer.stopTimerAndSound();
            Console.WriteLine("Song stopped. Device is now on stand by...");
            musicPlayer.CurrentState = musicPlayer.standbyState;
        }

        public void lockUnlock()
        {
            musicPlayer.stopTimerAndSound();
            Console.WriteLine("Device locked...");
            musicPlayer.CurrentState = musicPlayer.lockedState;
        }

        public void next()
        {
            musicPlayer.setNextSong();
            this.play();
        }

        public void previous()
        {
            musicPlayer.setPreviousSong();
            this.play();
        }
    }
}
