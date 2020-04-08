using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DesignPatterns.musicPlayer.statePattern.model;

namespace DesignPatterns.musicPlayer.statePattern.states
{
    class TurnedOffState : AbstractState
    {

        public TurnedOffState(MusicPlayer musicPlayer) : base(musicPlayer){ }

        public override void turnOn()
        {
            Console.WriteLine("Device is turning on....");
            Thread.Sleep(2000);
            Console.WriteLine("Device turned on...");
            musicPlayer.CurrentState = musicPlayer.standbyState;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("STATE CHANGED : TURNED_OFF_STATE ---> STANDBY_STATE");
            Console.ResetColor();
        }

        public override void turnOff()
        {
            Console.WriteLine("Device is already turned off!");
        }

        public override void play()
        {
            Console.WriteLine("You need to turn on your device first!");
        }

        public override void pause()
        {
            Console.WriteLine("You need to turn on your device first!");
        }

        public override void stop()
        {
            Console.WriteLine("You need to turn on your device first!");
        }

        public override void lockUnlock()
        {
            Console.WriteLine("You need to turn on your device first!");
        }

        public override void next()
        {
            Console.WriteLine("You need to turn on your device first!");
        }

        public override void previous()
        {
            Console.WriteLine("You need to turn on your device first!");
        }
    
    }
}
