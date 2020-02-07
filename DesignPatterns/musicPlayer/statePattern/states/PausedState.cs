using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DesignPatterns.musicPlayer.statePattern.model;

namespace DesignPatterns.musicPlayer.statePattern.states
{
    class PausedState : AbstractState
    {
        public PausedState(MusicPlayer musicPlayer) : base(musicPlayer)
        {
        }

        public override void play()
        {
            Song song = musicPlayer.Songs[musicPlayer.CurrentSongIndex];
            Console.WriteLine(song.Artist + " - " + song.Title + " is resuming from " + musicPlayer.PausedAt + " seconds ...");
            musicPlayer.MediaPlayer.Play();
            musicPlayer.Timer.Enabled = true;
            musicPlayer.CurrentState = musicPlayer.playingState;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("STATE CHANGED : PAUSED_STATE ---> PLAYING_STATE");
            Console.ResetColor();
        }

        public override void pause()
        {
            Console.WriteLine("Song is already paused");
        }

        public override void stop()
        {
            musicPlayer.stopTimerAndSound();
            Console.WriteLine("Song stopped. Device is now on stand by...");
            musicPlayer.CurrentState = musicPlayer.standbyState;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("STATE CHANGED : PAUSED_STATE ---> STANDBY_STATE");
            Console.ResetColor();
        }

        public override void lockUnlock()
        {
            Console.WriteLine("Device locked...");
            musicPlayer.stopTimerAndSound();
            musicPlayer.CurrentState = musicPlayer.lockedState;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("STATE CHANGED : PAUSED_STATE ---> LOCKED_STATE");
            Console.ResetColor();
        }

        public override void next()
        {
            musicPlayer.setNextSong();
            musicPlayer.stopTimerAndSound();
            Song song = musicPlayer.Songs[musicPlayer.CurrentSongIndex];
            Console.WriteLine("Current song on stand by: " + song.Artist + " - " + song.Title);
            musicPlayer.CurrentState = musicPlayer.standbyState;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("STATE CHANGED : PAUSED_STATE ---> STANDBY_STATE");
            Console.ResetColor();
        }

        public override void previous()
        {
            musicPlayer.setPreviousSong();
            musicPlayer.stopTimerAndSound();
            Song song = musicPlayer.Songs[musicPlayer.CurrentSongIndex];
            Console.WriteLine("Current song on stand by: " + song.Artist + " - " + song.Title);
            musicPlayer.CurrentState = musicPlayer.standbyState;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("STATE CHANGED : PAUSED_STATE ---> STANDBY_STATE");
            Console.ResetColor();
        }
    }
}
