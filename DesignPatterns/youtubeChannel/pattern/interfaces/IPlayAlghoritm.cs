using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.youtubeChannel.observerPattern.model;

namespace DesignPatterns.youtubeChannel.pattern.interfaces
{
    interface IPlayAlghoritm
    {
        void play(YouTubeVideo video);
    }
}
