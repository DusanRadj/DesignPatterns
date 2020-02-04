using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DesignPatterns.musicPlayer.statePattern.model;

namespace DesignPatterns.musicPlayer.statePattern.states
{
    class LockedState : IState
    {
        private MusicPlayer musicPlayer;

        public LockedState(MusicPlayer musicPlayer)
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
            Console.WriteLine("You need to unlock your device first!");
        }

        public void pause()
        {
            Console.WriteLine("You need to unlock your device first!");
        }

        public void stop()
        {
            Console.WriteLine("You need to unlock your device first!");
        }

        public void lockUnlock()
        {
            Console.WriteLine("Device unlocked...");
            musicPlayer.CurrentState = musicPlayer.standbyState;
        }

        public void next()
        {
            Console.WriteLine("You need to unlock your device first!");
        }

        public void previous()
        {
            Console.WriteLine("You need to unlock your device first!");
        }
    }
}
