using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.youtubeChannel.observerPattern.model
{
    class Playlist
    {
        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private Dictionary<String, YouTubeVideo> videos;

        public Playlist(String name)
        {
            this.name = name;
            this.videos = new Dictionary<String, YouTubeVideo>();
        }

        public void addVideoToPlaylist(YouTubeVideo video)
        {
            this.videos.Add(video.Title,video);
        }

        public void removeVideoFromPlaylist()
        {
            Console.Write("Enter video title: ");
            String videoTitle = Console.ReadLine();

            try
            {
                this.videos.Remove(videoTitle);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Video with given title is not in the playlist!");
            }
        }

    }
}
