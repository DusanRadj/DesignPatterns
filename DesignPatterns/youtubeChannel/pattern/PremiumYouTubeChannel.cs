﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.youtubeChannel.observerPattern.model;

namespace DesignPatterns.youtubeChannel.pattern
{
    class PremiumYouTubeChannel : YouTubeChannel
    {
        public PremiumYouTubeChannel(String name) : base(name)
        {
            this.PlayAlghoritm = new NoAdvertisingPlaying();
            //za playlistu
        }


    }
}
