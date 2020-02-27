using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DesignPatterns.youtubeChannel.observerPattern.model
{
    class YouTubeVideo
    {
        private String title;
        private String description;
        private String link;
        private int length;
        
        public YouTubeVideo(String title, String description, String link, int length)
        {
            this.title = title;
            this.description = description;
            this.link = link;
            this.length = length;
        }

        public void displayVideo()
        {
            Console.WriteLine("Title: " + this.title + ", Description: " + this.description + ", Length (" + this.length + "), Link -> " + this.link + ")");
        }

        public void play()
        {
            //String path = "D:\\" + title + ".mp4";
            String path = AppDomain.CurrentDomain.BaseDirectory + @"data\" + title + ".mp4";

            if (File.Exists(path))
            {
                System.Diagnostics.Process.Start(path);
            }
            else
            {
                Console.WriteLine("Video is not on its specified path!");
            }
        }

        #region properties

        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        public String Link
        {
            get { return link; }
            set { link = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        #endregion


    }
}
