using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.youtubeChannel.pattern.interfaces;
using DesignPatterns.youtubeChannel.observerPattern.model;
using DesignPatterns.youtubeChannel.observerPattern;

namespace DesignPatterns.youtubeChannel.pattern
{
    class AdvertisingPlaying : IPlayAlghoritm
    {
        public void play(YouTubeVideo video)
        {
            YouTubeApp.getInstance().Advertisements[0].play();
            video.play();
        }
    }
}
