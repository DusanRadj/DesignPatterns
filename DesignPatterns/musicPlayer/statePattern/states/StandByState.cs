using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Media;
using DesignPatterns.musicPlayer.statePattern.model;


namespace DesignPatterns.musicPlayer.statePattern.states
{
    class StandByState : IState
    {
        private MusicPlayer musicPlayer;

        public StandByState(MusicPlayer musicPlayer)
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
            Thread.Sleep(2000);
            Console.WriteLine("Device turned off.");
            musicPlayer.CurrentState = musicPlayer.turnedOffState;
        }

        public void play()
        {
            Song song = musicPlayer.Songs[musicPlayer.CurrentSongIndex];
            Console.WriteLine(song.Artist + " - " + song.Title + " is now playing...");
            musicPlayer.Timer.Enabled = true;
            musicPlayer.CurrentState = musicPlayer.playingState;

            musicPlayer.MediaPlayer.FileName = song.Path;
            musicPlayer.MediaPlayer.Play();
        }

        public void pause()
        {
            Console.WriteLine("There is no song playing!");
        }

        public void stop()
        {
            Console.WriteLine("There is no song playing!");
        }

        public void lockUnlock()
        {
            Console.WriteLine("Device locked...");
            musicPlayer.CurrentState = musicPlayer.lockedState;
        }

        public void next()
        {
            musicPlayer.setNextSong();
            Song song = musicPlayer.Songs[musicPlayer.CurrentSongIndex];
            Console.WriteLine("Current song on stand by: " + song.Artist + " - " + song.Title);
        }

        public void previous()
        {
            musicPlayer.setPreviousSong();
            Song song = musicPlayer.Songs[musicPlayer.CurrentSongIndex];
            Console.WriteLine("Current song on stand by: " + song.Artist + " - " + song.Title);
        }


    }
}
