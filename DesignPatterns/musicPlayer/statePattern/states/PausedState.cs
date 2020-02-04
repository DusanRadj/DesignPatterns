using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DesignPatterns.musicPlayer.statePattern.model;

namespace DesignPatterns.musicPlayer.statePattern.states
{
    class PausedState : IState
    {
        private MusicPlayer musicPlayer;

        public PausedState(MusicPlayer musicPlayer)
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
            Song song = musicPlayer.Songs[musicPlayer.CurrentSongIndex];
            Console.WriteLine(song.Artist + " - " + song.Title + " is resuming from " + musicPlayer.PausedAt + " seconds ...");
            musicPlayer.MediaPlayer.Play();
            musicPlayer.Timer.Enabled = true;
            musicPlayer.CurrentState = musicPlayer.playingState;
        }

        public void pause()
        {
            Console.WriteLine("Song is already paused");
        }

        public void stop()
        {
            musicPlayer.stopTimerAndSound();
            Console.WriteLine("Song stopped. Device is now on stand by...");
            musicPlayer.CurrentState = musicPlayer.standbyState;
        }

        public void lockUnlock()
        {
            Console.WriteLine("Device locked...");
            musicPlayer.stopTimerAndSound();
            musicPlayer.CurrentState = musicPlayer.lockedState;
        }

        public void next()
        {
            musicPlayer.setNextSong();
            musicPlayer.stopTimerAndSound();
            Song song = musicPlayer.Songs[musicPlayer.CurrentSongIndex];
            Console.WriteLine("Current song on stand by: " + song.Artist + " - " + song.Title);
            musicPlayer.CurrentState = musicPlayer.standbyState;
        }

        public void previous()
        {
            musicPlayer.setPreviousSong();
            musicPlayer.stopTimerAndSound();
            Song song = musicPlayer.Songs[musicPlayer.CurrentSongIndex];
            Console.WriteLine("Current song on stand by: " + song.Artist + " - " + song.Title);
            musicPlayer.CurrentState = musicPlayer.standbyState;
        }
    }
}
