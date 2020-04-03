using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.youtubeChannel.observerPattern.model;

namespace DesignPatterns.youtubeChannel.withoutPattern
{
    class BasicPlaylist : Playlist
    {
        public BasicPlaylist(String name) : base(name) { }

        public override void play()
        {
            foreach (KeyValuePair<String, YouTubeVideo> video in videos)
            {
                YouTubeApp.Advertisements[0].play();
                video.Value.play();
            }
        }
    }
}
