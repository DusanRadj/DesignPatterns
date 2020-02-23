using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DesignPatterns.musicPlayer.statePattern.model;

namespace DesignPatterns.musicPlayer.statePattern.states
{
    abstract class AbstractState
    {
        protected MusicPlayer musicPlayer;

        protected AbstractState(MusicPlayer musicPlayer)
        {
            this.musicPlayer = musicPlayer;
        }

        public virtual void turnOn()
        {
            Console.WriteLine("Device is already turned on!");
        }

        public virtual void turnOff()
        {
            Console.WriteLine("Device is shutting down...");
            musicPlayer.stopTimerAndSound();
            Thread.Sleep(2000);
            Console.WriteLine("Device turned off.");

            //dobijanje trentunog stanja iz konkretne child klase i formatiranje ispisa trenutnog stanja
            String[] currentStateParts = this.GetType().ToString().Split('.');
            String currentState = currentStateParts[currentStateParts.Length-1].ToUpper();
            int index = currentState.IndexOf("STATE");
            String stateName = currentState.Substring(0, index);
            String formattedCurrentState = stateName + "_STATE";

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("STATE CHANGED : {0} ---> TURNED_OFF_STATE",formattedCurrentState);
            Console.ResetColor();
            
            musicPlayer.CurrentState = musicPlayer.turnedOffState;
        }

        public abstract void play();
        public abstract void pause();
        public abstract void stop();
        public abstract void lockUnlock();
        public abstract void next();
        public abstract void previous();

    }
}
