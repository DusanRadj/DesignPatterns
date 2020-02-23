using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.youtubeChannel.pattern.interfaces;
using DesignPatterns.youtubeChannel.observerPattern.model;

namespace DesignPatterns.youtubeChannel.pattern
{
    class NoAdvertisingPlaying : IPlayAlghoritm
    {
        public void play(YouTubeVideo video)
        {
            video.play();
        }
    }
}
