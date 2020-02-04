using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.musicPlayer.withoutPattern
{
    class Song
    {
        private String title;
        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        private String artist;
        public String Artist
        {
            get { return artist; }
            set { artist = value; }
        }

        private int length;
        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        private String path;
        public String Path
        {
            get { return path; }
            set { path = value; }
        }


        public Song(String title, String artist, int length, String path)
        {
            this.title = title;
            this.artist = artist;
            this.length = length;
            this.path = AppDomain.CurrentDomain.BaseDirectory + @"data\" + path;
        }
    }
}
