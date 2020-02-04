using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DesignPatterns.musicPlayer.statePattern.model;

namespace DesignPatterns.musicPlayer.statePattern.states
{
    class TurnedOffState : IState
    {
        private MusicPlayer musicPlayer;

        public TurnedOffState(MusicPlayer musicPlayer)
        {
            this.musicPlayer = musicPlayer;
        }

        public void turnOn()
        {
            Console.WriteLine("Device is turning on....");
            Thread.Sleep(2000);
            Console.WriteLine("Device turned on...");
            musicPlayer.CurrentState = musicPlayer.standbyState;
        }

        public void turnOff()
        {
            
        }

        public void play()
        {
            
        }

        public void pause()
        {
            
        }

        public void stop()
        {
            
        }

        public void lockUnlock()
        {
            
        }

        public void next()
        {
            
        }

        public void previous()
        {
            
        }
    }
}
