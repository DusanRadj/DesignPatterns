using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.youtubeChannel.observerPattern.model
{
    class Notification
    {
        private String title;
        private String channelName;
        private String link;
        
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

        #region properties

        public String Link
        {
            get { return link; }
            set { link = value; }
        }

        public String ChannelName
        {
            get { return channelName; }
            set { channelName = value; }
        }
        
        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        #endregion

    }
}
