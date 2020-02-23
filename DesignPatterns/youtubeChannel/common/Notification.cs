using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.youtubeChannel.observerPattern.model
{
    class Notification
    {
        private String title;
        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        private String channelName;
        public String ChannelName
        {
            get { return channelName; }
            set { channelName = value; }
        }

        private String link;
        public String Link
        {
            get { return link; }
            set { link = value; }
        }

        public Notification(String title, String link, String channelName)
        {
            this.title = title;
            this.link = link;
            this.channelName = channelName;
        }

        public override string ToString()
        {
            return "Channel " + this.ChannelName + " you subscribed to, has uploaded a new video " + this.Title + " on link (" + this.Link + ")";
        }

    }
}
