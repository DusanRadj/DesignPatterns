using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.youtubeChannel.observerPattern.model;
using DesignPatterns.youtubeChannel.pattern.interfaces;

namespace DesignPatterns.youtubeChannel.observerPattern.model
{
    class Playlist
    {
        private String name;
        private Dictionary<String, YouTubeVideo> videos;
        private IPlayAlghoritm playAlghoritm;

        public Playlist(String name, IPlayAlghoritm playAlghoritm)
        {
            this.name = name;
            this.videos = new Dictionary<String, YouTubeVideo>();
            this.playAlghoritm = playAlghoritm;
        }

        public void addVideo(YouTubeVideo video)
        {
            this.videos.Add(video.Title,video);
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

        public void play()
        {
            foreach (KeyValuePair<String,YouTubeVideo> video in videos)
            {
                playAlghoritm.play(video.Value);
            }
        }

        #region properties

        internal IPlayAlghoritm PlayAlghoritm
        {
            get { return playAlghoritm; }
            set { playAlghoritm = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion

    }
}
