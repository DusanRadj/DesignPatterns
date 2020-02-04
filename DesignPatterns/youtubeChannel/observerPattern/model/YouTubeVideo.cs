using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.youtubeChannel.observerPattern.model
{
    class YouTubeVideo
    {
        private String title;
        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        private String description;
        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        private String link;
        public String Link
        {
            get { return link; }
            set { link = value; }
        }

        private int length;
        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        public YouTubeVideo(String title, String description, String link, int length)
        {
            this.title = title;
            this.description = description;
            this.link = link;
            this.length = length;
        }


    }
}
