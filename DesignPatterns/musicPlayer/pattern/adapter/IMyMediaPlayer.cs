using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.musicPlayer.pattern.adapter
{
    interface IMyMediaPlayer
    {
        void play(string path);
        void pause();
        void stop();
        void resume();
    }
}
