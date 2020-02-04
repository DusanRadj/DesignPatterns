using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.musicPlayer.statePattern.states
{
    public interface IState
    {
        void turnOn();
        void turnOff();
        void play();
        void pause();
        void stop();
        void lockUnlock();
        void next();
        void previous();

    }
}
