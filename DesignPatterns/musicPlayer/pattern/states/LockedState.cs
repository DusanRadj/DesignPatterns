using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DesignPatterns.musicPlayer.statePattern.model;

namespace DesignPatterns.musicPlayer.statePattern.states
{
    class LockedState : AbstractState
    {

        public LockedState(MusicPlayer musicPlayer) : base(musicPlayer)
        {
            
        }

        public override void play()
        {
            Console.WriteLine("You need to unlock your device first!");
        }

        public override void pause()
        {
            Console.WriteLine("You need to unlock your device first!");
        }

        public override void stop()
        {
            Console.WriteLine("You need to unlock your device first!");
        }

        public override void lockUnlock()
        {
            Console.WriteLine("Device unlocked...");
            musicPlayer.CurrentState = musicPlayer.standbyState;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("STATE CHANGED : LOCKED_STATE ---> STANDBY_STATE");
            Console.ResetColor();
        }

        public override void next()
        {
            Console.WriteLine("You need to unlock your device first!");
        }

        public override void previous()
        {
            Console.WriteLine("You need to unlock your device first!");
        }

       
       
    }
}
