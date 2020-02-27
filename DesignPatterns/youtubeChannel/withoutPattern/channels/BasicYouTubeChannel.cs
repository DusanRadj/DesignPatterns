using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.youtubeChannel.observerPattern.model;

namespace DesignPatterns.youtubeChannel.withoutPattern
{
    class BasicYouTubeChannel : YouTubeChannel
    {
        public BasicYouTubeChannel(String name) : base(name) { }

        public override void playVideo()
        {
            Console.Write("Enter video title: ");
            String videoTitle = Console.ReadLine();

            try
            {
                YouTubeVideo video = this.Videos[videoTitle];
                YouTubeApp.getAdvertisements()[0].play();
                video.play();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("This channel do not have video with given title!");
            }

            
        }

        public override void createPlaylist()
        {
            Console.Write("Enter playlist name: ");
            String playlistName = Console.ReadLine();
            Playlist playlist = new BasicPlaylist(playlistName);
            this.playlists.Add(playlistName, playlist);
        
        }
    }
}
