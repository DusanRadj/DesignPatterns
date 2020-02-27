using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.youtubeChannel.observerPattern.model;

namespace DesignPatterns.youtubeChannel.withoutPattern
{
    class PremiumPlaylist : Playlist
    {
        public PremiumPlaylist(String name) : base(name) { }

        public override void play()
        {
            foreach (KeyValuePair<String, YouTubeVideo> video in videos)
            {
                video.Value.play();
            }
        }
    }
}
