using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DesignPatterns.musicPlayer.statePattern.model;

namespace DesignPatterns.musicPlayer.statePattern.states
{
    class PlayingState : AbstractState
    {
        public PlayingState(MusicPlayer musicPlayer) : base(musicPlayer)
        {
        }

        public override void play()
        {
            musicPlayer.stopTimerAndSound();
            
            Song song = musicPlayer.Songs[musicPlayer.CurrentSongIndex];
            Console.WriteLine(song.Artist + " - " + song.Title + " is now playing ...");
            musicPlayer.Timer.Enabled = true;

            musicPlayer.MediaPlayer.FileName = song.Path;
            musicPlayer.MediaPlayer.Play();
        }

        public override void pause()
        {
            musicPlayer.MediaPlayer.Pause();
            musicPlayer.Timer.Enabled = false;
            Console.WriteLine("Song paused on " + musicPlayer.PausedAt + " seconds ...");
            musicPlayer.CurrentState = musicPlayer.pausedState;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("STATE CHANGED : PLAYING_STATE ---> PAUSED_STATE");
            Console.ResetColor();
        }

        public override void stop()
        {
            musicPlayer.stopTimerAndSound();
            Console.WriteLine("Song stopped. Device is now on stand by...");
            musicPlayer.CurrentState = musicPlayer.standbyState;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("STATE CHANGED : PLAYING_STATE ---> STANDBY_STATE");
            Console.ResetColor();
        }

        public override void lockUnlock()
        {
            musicPlayer.stopTimerAndSound();
            Console.WriteLine("Device locked...");
            musicPlayer.CurrentState = musicPlayer.lockedState;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("STATE CHANGED : PLAYING_STATE ---> LOCKED_STATE");
            Console.ResetColor();
        }

        public override void next()
        {
            musicPlayer.setNextSong();
            this.play();
        }

        public override void previous()
        {
            musicPlayer.setPreviousSong();
            this.play();
        }
    }
}
