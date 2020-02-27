using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.youtubeChannel.observerPattern.model;

namespace DesignPatterns.youtubeChannel.withoutPattern
{
    abstract class Playlist
    {
        private String name;
        protected Dictionary<String, YouTubeVideo> videos;

        public Playlist(String name)
        {
            this.name = name;
            this.videos = new Dictionary<String, YouTubeVideo>();
        }

        public void addVideo(YouTubeVideo video)
        {
            this.videos.Add(video.Title, video);
        }

        public void removeVideo()
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

        public void display()
        {
            Console.WriteLine();
            Console.WriteLine("Playlist: " + this.name);
            Console.WriteLine("Videos in this playlist: ");
            foreach (KeyValuePair<String, YouTubeVideo> pair in this.videos)
            {
                pair.Value.displayVideo();
            }
            Console.WriteLine();

        }

        public abstract void play();

        #region properties



        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion
    }
}
