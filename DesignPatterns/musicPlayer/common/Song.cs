using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.musicPlayer.statePattern.model
{
    class Song
    {
        private String title;
        private String artist;
        private int length;
        private String path;
        
        public Song(String title, String artist, int length, String path)
        {
            this.title = title;
            this.artist = artist;
            this.length = length;
            this.path = AppDomain.CurrentDomain.BaseDirectory + @"data\" + path;
        }

        #region properties

        public String Path
        {
            get { return path; }
            set { path = value; }
        }
        
        public int Length
        {
            get { return length; }
            set { length = value; }
        }
        
        public String Artist
        {
            get { return artist; }
            set { artist = value; }
        }
        
        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        #endregion

    }
}
