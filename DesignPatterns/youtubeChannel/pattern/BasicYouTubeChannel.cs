using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.youtubeChannel.observerPattern.model;

namespace DesignPatterns.youtubeChannel.pattern
{
    class BasicYouTubeChannel : YouTubeChannel
    {

        public BasicYouTubeChannel(String name) : base(name)
        {
            this.PlayAlghoritm = new AdvertisingPlaying();
            //za playlistu
        }
    }
}
