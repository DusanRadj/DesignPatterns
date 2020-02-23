using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Media;
using DesignPatterns.musicPlayer.statePattern.model;


namespace DesignPatterns.musicPlayer.statePattern.states
{
    class StandByState : AbstractState
    {
        public StandByState(MusicPlayer musicPlayer) : base(musicPlayer){ }

        public override void play()
        {
            Song song = musicPlayer.Songs[musicPlayer.CurrentSongIndex];
            Console.WriteLine(song.Artist + " - " + song.Title + " is now playing...");
            musicPlayer.Timer.Enabled = true;
            musicPlayer.CurrentState = musicPlayer.playingState;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("STATE CHANGED : STANDBY_STATE ---> PLAYING_STATE");
            Console.ResetColor();
            
            musicPlayer.MediaPlayer.FileName = song.Path;
            musicPlayer.MediaPlayer.Play();
        }

        public override void pause()
        {
            Console.WriteLine("There is no song playing!");
        }

        public override void stop()
        {
            Console.WriteLine("There is no song playing!");
        }

        public override void lockUnlock()
        {
            Console.WriteLine("Device locked...");
            musicPlayer.CurrentState = musicPlayer.lockedState;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("STATE CHANGED : STANDBY_STATE ---> LOCKED_STATE");
            Console.ResetColor();
        }

        public override void next()
        {
            musicPlayer.setNextSong();
            Song song = musicPlayer.Songs[musicPlayer.CurrentSongIndex];
            Console.WriteLine("Current song on stand by: " + song.Artist + " - " + song.Title);
        }

        public override void previous()
        {
            musicPlayer.setPreviousSong();
            Song song = musicPlayer.Songs[musicPlayer.CurrentSongIndex];
            Console.WriteLine("Current song on stand by: " + song.Artist + " - " + song.Title);
        }


    }
}
